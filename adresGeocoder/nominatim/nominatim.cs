using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;
using System.Globalization;


namespace adressenGeocoder
{
   class nominatim
   {
      private const string URL = "https://nominatim.openstreetmap.org/search";
      private NameValueCollection qryValues;

      public nominatim()
      {
         qryValues = new NameValueCollection();
      }

      public async void search(string houseNr, string street, string city, string postalcode)
      {
         setQueryValues(houseNr, street, city, postalcode);
         var data = await GetData();
         System.Windows.Forms.MessageBox.Show( data.ToString() );
      }

      private void setQueryValues(string houseNr, string street, string city, string postalcode, int limit=5)
      {
          qryValues.Clear(); //remove existing
          qryValues.Add("format", "json");
          qryValues.Add("street", houseNr +" "+ street );
          qryValues.Add("city", city);
          qryValues.Add("postalcode", postalcode);
          qryValues.Add("limit", limit.ToString() );
          qryValues.Add("countrycodes", "be");
      }

      private async Task<List<nominatimResult>> GetData()
      { 
         string response;
         string q = String.Join("&",
             qryValues.AllKeys.Select(a => a + "=" + System.Web.HttpUtility.UrlEncode(qryValues[a])));
         Uri url = new Uri(URL + "?" + q);
 
         using (var httpClient = new HttpClient())
         {
            response = await httpClient.GetStringAsync(url);
         }
         response = response.Replace("class:", "class_:");
         var result = JsonConvert.DeserializeObject<List<nominatimResult>>(response);
         return result;
      }

   }
}
