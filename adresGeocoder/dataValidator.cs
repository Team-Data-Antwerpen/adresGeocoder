using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using vlaanderen.informatie;
using adresGeocoder.walGeocoderService;

namespace adresGeocoder
{
   class dataValidator
   {
      private AdresMatchClient adresMatch;
      private GeolocalisationSoapWSClient walClient;

      public dataValidator()
      {
         adresMatch = new AdresMatchClient();
         walClient = new GeolocalisationSoapWSClient();
      }

      public async Task< List<adres>> findAdres(adres inputAdres, bool nearNr = false, gewest gw = gewest.vl)
      {
         List<adres> adr;
         switch (gw)
         {
            case gewest.vl:
               adr = await findVlAdres(inputAdres, nearNr);
               break;
            case gewest.bxl:  //TODO
               adr = await findBxlAdres(inputAdres, nearNr);
               break;
            case gewest.wal:
               adr = await findWalAdres(inputAdres, nearNr);
               break;
            default:
              throw new Exception("Invalid gewest");
         }
         return adr;
      }

      public async Task<List<adres>> findVlAdres(adres inputAdres, bool nearNr = false)
      {
         List<AdresMatchItem> adresmatches;
         List<adres> addresses= new List<adres>();
         try
         {
            var adresResult = await adresMatch.GetAsync("1", inputAdres.municapalname, adresMatchRequest_straatnaam: inputAdres.street,
                                 adresMatchRequest_postcode: inputAdres.pc, adresMatchRequest_huisnummer: inputAdres.housnr);
            adresmatches = adresResult.AdresMatches.ToList();
         }
         catch (SwaggerException e)
         {
            System.Diagnostics.Debug.WriteLine(e.Message);
            addresses.Add( new adres() { info = "0 | Error: " + e.Message } );
            return addresses; //empty list
         }

         if ((from n in adresmatches where n.VolledigAdres != null select n).Count() >= 1)  //+1 adres found 
         {
            foreach (var adresMatch in adresmatches.Where(n => n.Straatnaam != null) )
            {
               var adr = new adres();
               adr.x = adresMatch.AdresPositie.Point1.Coordinates[0];
               adr.y = adresMatch.AdresPositie.Point1.Coordinates[1];
               adr.adresID = adresMatch.Identificator.Id;
               adr.validadres = adresMatch.VolledigAdres.GeografischeNaam.Spelling;
               adr.info = (adresMatch.Score != null ? ((double)adresMatch.Score).ToString("000.0") : "") +
                  " | " + adresMatch.PositieGeometrieMethode + " | " + adresMatch.PositieSpecificatie;

               adr.colorCode = ColorTranslator.FromHtml("#D0F5A9");
               //add to list
               addresses.Add(adr);
            }
         }
         else  //adres not found
	      {
            var adr = new adres() { info = "0 | Geen overeenkomstige adressen gevonden." };
            addresses.Add(adr);
	      }
         return addresses;
      }

      public async Task<List<adres>> findBxlAdres(adres inputAdres, bool nearNr = false)
      {
         //PLACEHOLDER, TODO
         return await Task.FromResult(new List<adres>() );
      }

      public async Task<List<adres>> findWalAdres(adres inputAdres, bool nearNr = false)
      {
         
         List<adres> addresses= new List<adres>();
         var adrResult = await walClient.getListPositionsBySmartGeocodingAsync(
                  inputAdres.pc, inputAdres.municapalname, inputAdres.street, inputAdres.housnr);

         if (adrResult.@return.positions != null)
         {
            foreach (var i in adrResult.@return.positions)
            {

               var adr = new adres();
               adr.street = i.rue.nom;
               adr.municapalname = i.rue.commune;
               adr.pc = i.rue.cps.First().ToString();
               adr.housnr = i.num;
               adr.adresID = i.idTroncon.ToString();
               adr.validadres = i.adresse;

               adr.x = i.x; adr.y = i.y;
               adr.colorCode = ColorTranslator.FromHtml("#D0F5A9");

               adr.info = i.score.ToString() + " | " +
                  (i.infoMsg != null ? i.infoMsg : "<geen info>") + " | " +
                  (i.errorMsg != null ? i.errorMsg : "<geen error>");

               addresses.Add(adr);
            }
         }
         else
         {
            var adr = new adres() { info = "0 | " + (adrResult.@return.errorMsg != null ? adrResult.@return.errorMsg : "Onbekende Error") };
            addresses.Add(adr);
         }

         return  addresses;
      }

   }
}
