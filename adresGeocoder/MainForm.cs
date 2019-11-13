﻿using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using BruTile.Web;
using BruTile;
using NetTopologySuite;
using NetTopologySuite.IO;
using SharpMap.Layers;
using SharpMap.Data.Providers;

namespace adresGeocoder
{
   public partial class MainForm : Form
   {
      crsFactory crs;
      GeoAPI.Geometries.IGeometryFactory gf;
      GeometryProvider geoprov;

      int maxRows = Int32.MaxValue;
      int straatCol;
      int huisnrCol;
      int gemeenteCol;
      int pcCol;

      VectorLayer vlay;
      DataGridViewRow[] rows2validate;

      bool dataloaded = false;
      bool prikLoc = false;
      bool isBuzy = false;
      bool canceling = false;

      gewest currentGewest = gewest.vl;

      public MainForm()
      {
         InitializeComponent();
         initMap();
         sepCbx.SelectedIndex = 0;
         encodingCbx.SelectedIndex = 0;

         //extra events
         this.closeBtn.Click += (sender, e) => this.Close();
         this.FormClosing += MainForm_FormClosing;
         this.vlGeocoderRadio.CheckedChanged += (sender, e) => { if (vlGeocoderRadio.Checked) currentGewest = gewest.vl; };
         this.walGeocoderRadio.CheckedChanged += (sender, e) => { if (walGeocoderRadio.Checked) currentGewest = gewest.wal; };
       }

      #region save
      private void saveBtn_Click(object sender, EventArgs e)
      {
         if (saveShapeDlg.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel) return;

         bool result = false; 
         var ext = Path.GetExtension(saveShapeDlg.FileName);
         if (ext == ".shp")
         {
            result = saveShp(saveShapeDlg.FileName);
         }
         else if (ext == ".csv")
         {
            result = saveCsv(saveShapeDlg.FileName);
         }
         if (result) 
            MessageBox.Show(Path.GetFileName(saveShapeDlg.FileName) + " is opgeslagen.");
         else
            MessageBox.Show(Path.GetFileName(saveShapeDlg.FileName) + " werd niet opgeslagen, mogelijk zijn er geen records met een geometrie");
         
      }

      private bool saveCsv(string flName)
      {
         var sb = new StringBuilder();
         var headers = csvDataGrid.Columns.Cast<DataGridViewColumn>();
         sb.AppendLine(string.Join(";", headers.Select(column => "\""+ column.HeaderText +"\"" ).ToArray()));

         foreach (DataGridViewRow row in csvDataGrid.Rows)
         {
            var cells = row.Cells.Cast<DataGridViewCell>();
            sb.AppendLine(string.Join(";", cells.Select(cell => "\""+ cell.Value +"\"" ).ToArray()));
         }
         var utf8bytes = Encoding.UTF8.GetBytes(sb.ToString());
         var win1252Bytes = Encoding.Convert(Encoding.UTF8, Encoding.GetEncoding("windows-1252"), utf8bytes);
         File.WriteAllBytes(flName , win1252Bytes);

         return true;
      }
      
      private bool saveShp(string shpFile)
      {
         var features = new List<NetTopologySuite.Features.Feature>();
         foreach (DataGridViewRow row in csvDataGrid.Rows)
         {
            double X; double Y;
            if (row.Cells["X"].Value is double && row.Cells["Y"].Value is double)
            {
               X = (double)row.Cells["X"].Value;
               Y = (double)row.Cells["Y"].Value;
            }
            else continue;

            var geom = gf.CreatePoint(new GeoAPI.Geometries.Coordinate(X, Y));
            var attr = new NetTopologySuite.Features.AttributesTable();
            var headerNamesCLean = new List<string>();

            for (int i = 0; i < row.Cells.Count; i++)
            {
               //if (row.Cells[i].Value == null) continue;
               string val = row.Cells[i].Value != null ?  row.Cells[i].Value.ToString() : "";
               var name = launderShpName(csvDataGrid.Columns[i].HeaderText, headerNamesCLean);
               headerNamesCLean.Add(name);
               attr.AddAttribute(name, val);
            }
            var feat = new NetTopologySuite.Features.Feature(geom, attr);
            features.Add(feat);
         }
         if( features.Count == 0) return false;

         var outFileNoExt = Path.GetDirectoryName(shpFile) + @"\" + Path.GetFileNameWithoutExtension(shpFile);

         var writer = new ShapefileDataWriter(outFileNoExt) {Header = ShapefileDataWriter.GetHeader(features[0], features.Count)};
         writer.Write(features);
         File.WriteAllText(outFileNoExt + ".prj", crs.lam72.WKT);
         return true;
      }

      private string launderShpName(string inCellName, List<string> existingNames )
      {
         var outCellName = Regex.Replace(inCellName, @"[^a-zA-Z0-9 -]", "");
         outCellName = outCellName.Replace(@" ", @"_");
         outCellName = Regex.IsMatch(outCellName, @"^\d") ? "c" + outCellName : outCellName;
         outCellName = outCellName.Length > 10 ? outCellName.Substring(0, 10) : outCellName;
         if(existingNames.Contains(outCellName) )
         {
            outCellName = outCellName.Length > 8 ? outCellName.Substring(0, 8) : outCellName;
            outCellName = outCellName.Substring(0, 8) + existingNames.Count.ToString("00"); //let asume no more then 100 fields
         }
         return outCellName;
      }

      #endregion

      #region map interaction;
      private void initMap()
      {
         crs = new crsFactory();
         //create geometry collection
         GeoAPI.GeometryServiceProvider.Instance = new NtsGeometryServices();
         gf = GeoAPI.GeometryServiceProvider.Instance.CreateGeometryFactory();

         SharpMap.Data.FeatureDataTable feats = new SharpMap.Data.FeatureDataTable();
         geoprov = new GeometryProvider(feats);
         geoprov.SRID = 3857;

         //create layers
         vlay = new SharpMap.Layers.VectorLayer("Points");
         vlay.DataSource = geoprov;

         var grb = new TileAsyncLayer(new TmsTileSource("http://tile.informatievlaanderen.be/ws/raadpleegdiensten/tms/1.0.0/grb_bsk@GoogleMapsVL",
                                           new BruTile.PreDefined.SphericalMercatorWorldSchema()), "GRB") { Enabled = true };
         var lufo = new TileAsyncLayer(new TmsTileSource("http://tile.informatievlaanderen.be/ws/raadpleegdiensten/tms/1.0.0/omwrgbmrvl@GoogleMapsVL",
                                           new BruTile.PreDefined.SphericalMercatorWorldSchema()), "Luchtfoto") { Enabled = false,  };
         var antTile = new BruTile.PreDefined.SphericalMercatorInvertedWorldSchema();
         antTile.Resolutions.Add(new Resolution() { Id = "19", UnitsPerPixel = 0.298582141647617 });
         var ant = new TileAsyncLayer(new ArcGisTileSource("https://tiles.arcgis.com/tiles/1KSVSmnHT2Lw9ea6/arcgis/rest/services/basemap_stadsplan_v5/MapServer",
                                        antTile ), "Antwerpen") { Enabled = false };
         var osm = new TileAsyncLayer(new BruTile.Web.OsmTileSource(), "OSM") { Enabled = false };
         //Add layers to map
         mapBox.Map.Layers.Add(vlay);
         mapBox.Map.BackgroundLayer.Add(grb);
         mapBox.Map.BackgroundLayer.Add(lufo);
         mapBox.Map.BackgroundLayer.Add(ant);
         mapBox.Map.BackgroundLayer.Add(osm);
         basemapCbx.SelectedIndex = 3;

         mapBox.Map.SRID = 3857;
         mapBox.ActiveTool = SharpMap.Forms.MapBox.Tools.Pan;
         mapBox.Map.ZoomToBox(new GeoAPI.Geometries.Envelope(458235.9, 515348.5, 6689330.3, 6646648.0));
         mapBox.Refresh();
      }

      private void zoomINBtn_Click(object sender, EventArgs e)
      {
         mapBox.Map.Zoom = mapBox.Map.Zoom / 2;
         mapBox.Refresh();
      }

      private void zoomOUTBtn_Click(object sender, EventArgs e)
      {
         mapBox.Map.Zoom = mapBox.Map.Zoom * 2;
         mapBox.Refresh();
      }

      private void fullExtendBtn_Click(object sender, EventArgs e)
      {
         mapBox.Map.ZoomToBox(new GeoAPI.Geometries.Envelope(458235.9, 515348.5, 6689330.3, 6646648.0));
         mapBox.Refresh();
      }
      private void basemapCbx_SelectedIndexChanged(object sender, EventArgs e)
      {
         switch (basemapCbx.SelectedIndex)
         {
            case 0:
               mapBox.Map.BackgroundLayer[0].Enabled = true;
               mapBox.Map.BackgroundLayer[1].Enabled = false;
               mapBox.Map.BackgroundLayer[2].Enabled = false;
               mapBox.Map.BackgroundLayer[3].Enabled = false;
               break;
            case 1:
               mapBox.Map.BackgroundLayer[0].Enabled = false;
               mapBox.Map.BackgroundLayer[1].Enabled = true;
               mapBox.Map.BackgroundLayer[2].Enabled = false;
               mapBox.Map.BackgroundLayer[3].Enabled = false;
               break;
            case 2:
               mapBox.Map.BackgroundLayer[0].Enabled = false;
               mapBox.Map.BackgroundLayer[1].Enabled = false;
               mapBox.Map.BackgroundLayer[2].Enabled = true;
               mapBox.Map.BackgroundLayer[3].Enabled = false;
               break;
            case 3:
               mapBox.Map.BackgroundLayer[0].Enabled = false;
               mapBox.Map.BackgroundLayer[1].Enabled = false;
               mapBox.Map.BackgroundLayer[2].Enabled = false;
               mapBox.Map.BackgroundLayer[3].Enabled = true;
               break;
            default:
               break;
         }
         mapBox.Refresh();
      }

      #endregion

      #region load CSV
      private void openBtn_Click(object sender, EventArgs e)
      {
         if (openTableDlg.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel) return;
         var csv = openTableDlg.FileName;
         var sep = sepCbx.Text == "Ander:" ? otherSepBox.Text : sepCbx.Text;
         csvPathTxt.Text = csv;
         DataTable csvTable;

         csvDataGrid.Columns.Clear();
         dataloaded = false;

         if (encodingCbx.Text == "UTF-8") {
            csvTable = csvReader.loadCSV2datatable(csv, sep, maxRows, Encoding.UTF8);
         }
         else if (encodingCbx.Text == "ANSI") {
            csvTable = csvReader.loadCSV2datatable(csv, sep, maxRows, Encoding.ASCII);
         }
         else {
            csvTable = csvReader.loadCSV2datatable(csv, sep, maxRows);
         }

         straatColCbx.Items.Clear();
         straatColCbx.Items.Add("");
         HuisNrCbx.Items.Clear();
         HuisNrCbx.Items.Add("");
         postcodeColCbx.Items.Clear();
         postcodeColCbx.Items.Add("");
         gemeenteColCbx.Items.Clear();
         gemeenteColCbx.Items.Add("");

         //set extra columns
         var validatedRow = new DataGridViewTextBoxColumn() { HeaderText = "validAdres", Name = "validAdres", Width = 120, ReadOnly = true}; //DataGridViewComboBoxColumn
         var infoRow = new DataGridViewTextBoxColumn() { HeaderText = "info", Name = "info", Width = 120, ReadOnly = true};
         var idRow = new DataGridViewTextBoxColumn() { HeaderText = "adresID", Name = "adresID", Width = 60, ReadOnly = true };
         var xRow = new DataGridViewTextBoxColumn() { HeaderText = "X", Name = "X", Width = 60, ReadOnly = true};
         xRow.DefaultCellStyle.Format = "F0";
         var yRow = new DataGridViewTextBoxColumn() { HeaderText = "Y", Name = "Y", Width = 60 , ReadOnly = true};
         yRow.DefaultCellStyle.Format = "F0";

         foreach (DataColumn column in csvTable.Columns)
         {
            csvDataGrid.Columns.Add(column.ColumnName, column.ColumnName);
            csvDataGrid.Columns[column.ColumnName].SortMode = DataGridViewColumnSortMode.Automatic;
            straatColCbx.Items.Add(column.ColumnName);
            HuisNrCbx.Items.Add(column.ColumnName);
            postcodeColCbx.Items.Add(column.ColumnName);
            gemeenteColCbx.Items.Add(column.ColumnName);
         }
         foreach (DataRow row in csvTable.Rows)
         {
            csvDataGrid.Rows.Add(row.ItemArray);
         }
         csvDataGrid.Columns.Add(validatedRow);
         csvDataGrid.Columns.Add(infoRow);
         csvDataGrid.Columns.Add(idRow);
         csvDataGrid.Columns.Add(xRow);
         csvDataGrid.Columns.Add(yRow);
         dataloaded = true;
      }   
      #endregion 

      #region validation 

      private void validateAllBtn_Click(object sender, EventArgs e)
      {
         if (csvDataGrid.RowCount == 0) return;

         if (straatColCbx.Text == "")
         {
            MessageBox.Show(this, "Stel eerst de adres kolommen in.", "Waarschuwing");
            return;
         }
         if (isBuzy == false)
         {
            setCols();
            rows2validate = new DataGridViewRow[csvDataGrid.Rows.Count];
            csvDataGrid.Rows.CopyTo(rows2validate, 0);
            doGeocode(rows2validate);
         }
      }

      private void validateSelBtn_Click(object sender, EventArgs e)
      {
         if (csvDataGrid.SelectedRows.Count == 0) return;

         if (straatColCbx.Text == "")
         {
            MessageBox.Show(this, "Stel eerst de adres kolommen in.", "Waarschuwing");
            return;
         }
         
         if (isBuzy == false)
         {
            setCols();
            rows2validate = new DataGridViewRow[csvDataGrid.SelectedRows.Count];
            csvDataGrid.SelectedRows.CopyTo(rows2validate, 0);
            csvDataGrid.ClearSelection();
            doGeocode(rows2validate);
         }
      }
      #endregion

      #region worker

      async void doGeocode(DataGridViewRow[] rows)
      {
         toggleInteraction(false);

         progressBar.Maximum = rows.Count();
         progressBar.Value = 0;

         var dVal = new dataValidator();

         foreach (DataGridViewRow row in rows)
         {
            if (canceling)
            {
               canceling = false;
               break;
            }

            var inAdres = new adres();
            inAdres.street = straatCol >= 0 ? (string)row.Cells[straatCol].Value : "";
            inAdres.housnr = huisnrCol >= 0 ? (string)row.Cells[huisnrCol].Value : "";
            inAdres.municapalname = gemeenteCol >= 0 ? (string)row.Cells[gemeenteCol].Value : "";
            inAdres.pc = pcCol >= 0 ? (string)row.Cells[pcCol].Value : "";
            
            var adresses = await dVal.findAdres(inAdres, false, currentGewest);
            if (adresses.Count == 0)
            {
               row.Cells["info"].Value = "Geen adres gevonden";
               continue;
            }
            var adr = adresses.First();  //TODO: multiple results

            row.Cells["validAdres"].Value = adr.validadres;
            row.Cells["info"].Value = adr.info;
            row.Cells["adresID"].Value = adr.adresID;
            row.Cells["X"].Value = adr.x;
            row.Cells["Y"].Value = adr.y;

            foreach (DataGridViewCell cel in row.Cells) cel.Style.BackColor = adr.colorCode;

            progressBar.Value++;
         }
         progressBar.Value = 0;
         toggleInteraction(true);
      }

      private void cancelValidationBtn_Click(object sender, EventArgs e)
      {
         canceling = true;
      }
      #endregion

      #region set values
      private void toggleInteraction(bool active)
      {
         isBuzy = !active; 
         csvBox.Enabled = active;
         adresSettingsBox.Enabled = active;
         manualLocBtn.Enabled = active;
         validateSelBtn.Enabled = active;
         validateAllBtn.Enabled = active;
      }

      private void setCols()
      {
         straatCol = straatColCbx.SelectedIndex - 1;
         huisnrCol = HuisNrCbx.SelectedIndex - 1;
         gemeenteCol = gemeenteColCbx.SelectedIndex - 1;
         pcCol = postcodeColCbx.SelectedIndex - 1;
      }
      #endregion

      #region gridinteraction
      private void zoom2selBtn_Click(object sender, EventArgs e)
      {
         var minx = double.MaxValue;
         var maxx = 0.0;
         var miny = double.MaxValue;
         var maxy = 0.0;

         foreach (DataGridViewRow row in csvDataGrid.SelectedRows)
         {
            var hasx = row.Cells["X"].Value is double; 
            var hasy = row.Cells["Y"].Value is double;
            if(hasx && hasy){
               var X = (double)row.Cells["X"].Value;
               var Y = (double)row.Cells["Y"].Value;
               if (X < minx) minx = X;
               if (X > maxx) maxx = X;
               if (Y < miny) miny = Y;
               if (Y > maxy) maxy = Y;
            }
         }
         var top = crs.transformlam72Merc(maxx + 100, maxy + 100);
         var bottom = crs.transformlam72Merc(minx - 100, miny - 100);
         var bbox = new GeoAPI.Geometries.Envelope(top, bottom);
         mapBox.Map.ZoomToBox(bbox);
         mapBox.Refresh();
      }

      private void csvDataGrid_SelectionChanged(object sender, EventArgs e)
      {
         if ( !dataloaded || csvDataGrid.SelectedRows.Count == 0) return;
         geoprov.Geometries.Clear();

         foreach (DataGridViewRow row in csvDataGrid.SelectedRows)
         {
            var hasx = row.Cells["X"].Value is double;
            var hasy = row.Cells["Y"].Value is double;
            if (hasx && hasy)
            {
               var X = (double)row.Cells["X"].Value;
               var Y = (double)row.Cells["Y"].Value;
               var pt = crs.transformlam72Merc(X, Y);
               geoprov.Geometries.Add(gf.CreatePoint(pt));
            }
         }
         mapBox.Refresh();

      }

      private void manualLocBtn_Click(object sender, EventArgs e)
      {
         if (csvDataGrid.SelectedRows.Count == 1) prikLoc = true;
         else if (csvDataGrid.SelectedRows.Count > 1) MessageBox.Show("Meer dan 1 rij geselecteerd: Selecteer 1 rij in de tabel.", "Meer dan 1 rij geselecteerd");
         else MessageBox.Show("Geen rij geselecteerd: Selecteer een rij in de tabel.", "Geen rij geselecteerd");
      }

      private void mapBox_MouseClick(object sender, MouseEventArgs e)
      {
         if (!prikLoc) return;

         var pt = mapBox.Map.ImageToWorld(e.Location);
         geoprov.Geometries.Add(gf.CreatePoint(pt));
         var ptlam = crs.transformMerc2lam72(pt);

         var row = csvDataGrid.SelectedRows[0];
         row.Cells["info"].Value = "0 | Manueel geplaatst";
         row.Cells["X"].Value = ptlam.X;
         row.Cells["Y"].Value = ptlam.Y;

         Color clr = ColorTranslator.FromHtml("#D0F5A9");
         foreach (DataGridViewCell cel in row.Cells)
         {
            cel.Style.BackColor = clr;
         }
         prikLoc = false;
      }
      #endregion

      #region extra events
      void MainForm_FormClosing(object sender, FormClosingEventArgs e)
      {
         var window = MessageBox.Show(
             "Ben u zeker dat wilt afsluiten?", "Afsluiten", MessageBoxButtons.YesNo);
         e.Cancel = (window == DialogResult.No);
      }
      private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
      {
         MessageBox.Show(@"
Geocodeer adressen gebaseerd op: 
http://geoservices.wallonie.be/geolocalisation/doc/ws/index.xhtml (Wallonia and brussels)
en: 
https://overheid.vlaanderen.be/producten-diensten/gebouwen-adressenregister (Flanders)
         ", "Adres geocoder");
      }
      #endregion

   }
}
