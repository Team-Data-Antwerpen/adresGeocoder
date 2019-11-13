namespace adresGeocoder
{
   partial class MainForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this.mapBox = new SharpMap.Forms.MapBox();
         this.saveBtn = new System.Windows.Forms.Button();
         this.saveShapeDlg = new System.Windows.Forms.SaveFileDialog();
         this.splitContainer = new System.Windows.Forms.SplitContainer();
         this.progressLbl = new System.Windows.Forms.Label();
         this.progressBar = new System.Windows.Forms.ProgressBar();
         this.closeBtn = new System.Windows.Forms.Button();
         this.gridPanel = new System.Windows.Forms.Panel();
         this.csvDataGrid = new System.Windows.Forms.DataGridView();
         this.gridTools = new System.Windows.Forms.ToolStrip();
         this.validateAllBtn = new System.Windows.Forms.ToolStripButton();
         this.validateSelBtn = new System.Windows.Forms.ToolStripButton();
         this.cancelValidationBtn = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.manualLocBtn = new System.Windows.Forms.ToolStripButton();
         this.zoom2selBtn = new System.Windows.Forms.ToolStripButton();
         this.adresSettingsBox = new System.Windows.Forms.GroupBox();
         this.label4 = new System.Windows.Forms.Label();
         this.walGeocoderRadio = new System.Windows.Forms.RadioButton();
         this.vlGeocoderRadio = new System.Windows.Forms.RadioButton();
         this.postcodeColCbx = new System.Windows.Forms.ComboBox();
         this.gemeenteColCbx = new System.Windows.Forms.ComboBox();
         this.HuisNrCbx = new System.Windows.Forms.ComboBox();
         this.huisNrColLbl = new System.Windows.Forms.Label();
         this.GemeenteColLbl = new System.Windows.Forms.Label();
         this.straatColCbx = new System.Windows.Forms.ComboBox();
         this.adresColLbl = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this.csvBox = new System.Windows.Forms.GroupBox();
         this.label3 = new System.Windows.Forms.Label();
         this.encodingCbx = new System.Windows.Forms.ComboBox();
         this.otherSepBox = new System.Windows.Forms.TextBox();
         this.csvPathTxt = new System.Windows.Forms.TextBox();
         this.sepCbx = new System.Windows.Forms.ComboBox();
         this.openBtn = new System.Windows.Forms.Button();
         this.sepLbl = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.basemapCbx = new System.Windows.Forms.ComboBox();
         this.fullExtendBtn = new System.Windows.Forms.Button();
         this.zoomOUTBtn = new System.Windows.Forms.Button();
         this.zoomINBtn = new System.Windows.Forms.Button();
         this.openTableDlg = new System.Windows.Forms.OpenFileDialog();
         this.linkLabel1 = new System.Windows.Forms.LinkLabel();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
         this.splitContainer.Panel1.SuspendLayout();
         this.splitContainer.Panel2.SuspendLayout();
         this.splitContainer.SuspendLayout();
         this.gridPanel.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.csvDataGrid)).BeginInit();
         this.gridTools.SuspendLayout();
         this.adresSettingsBox.SuspendLayout();
         this.csvBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // mapBox
         // 
         this.mapBox.ActiveTool = SharpMap.Forms.MapBox.Tools.Pan;
         this.mapBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.mapBox.BackColor = System.Drawing.Color.White;
         this.mapBox.Cursor = System.Windows.Forms.Cursors.Hand;
         this.mapBox.FineZoomFactor = 10D;
         this.mapBox.Location = new System.Drawing.Point(0, -2);
         this.mapBox.MapQueryMode = SharpMap.Forms.MapBox.MapQueryType.TopMostLayer;
         this.mapBox.Name = "mapBox";
         this.mapBox.QueryGrowFactor = 5F;
         this.mapBox.QueryLayerIndex = 0;
         this.mapBox.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
         this.mapBox.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(244)))));
         this.mapBox.ShowProgressUpdate = false;
         this.mapBox.Size = new System.Drawing.Size(338, 618);
         this.mapBox.TabIndex = 0;
         this.mapBox.Text = "mapBox";
         this.mapBox.WheelZoomMagnitude = -2D;
         this.mapBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mapBox_MouseClick);
         // 
         // saveBtn
         // 
         this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.saveBtn.Location = new System.Drawing.Point(600, 655);
         this.saveBtn.Name = "saveBtn";
         this.saveBtn.Size = new System.Drawing.Size(104, 28);
         this.saveBtn.TabIndex = 10;
         this.saveBtn.TabStop = false;
         this.saveBtn.Text = "Opslaan";
         this.saveBtn.UseVisualStyleBackColor = true;
         this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
         // 
         // saveShapeDlg
         // 
         this.saveShapeDlg.DefaultExt = "shp";
         this.saveShapeDlg.Filter = "Shapefile|*.shp|CSV-file|*.csv";
         // 
         // splitContainer
         // 
         this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
         this.splitContainer.Location = new System.Drawing.Point(0, 0);
         this.splitContainer.MinimumSize = new System.Drawing.Size(200, 0);
         this.splitContainer.Name = "splitContainer";
         // 
         // splitContainer.Panel1
         // 
         this.splitContainer.Panel1.Controls.Add(this.progressLbl);
         this.splitContainer.Panel1.Controls.Add(this.progressBar);
         this.splitContainer.Panel1.Controls.Add(this.closeBtn);
         this.splitContainer.Panel1.Controls.Add(this.gridPanel);
         this.splitContainer.Panel1.Controls.Add(this.adresSettingsBox);
         this.splitContainer.Panel1.Controls.Add(this.csvBox);
         this.splitContainer.Panel1.Controls.Add(this.saveBtn);
         // 
         // splitContainer.Panel2
         // 
         this.splitContainer.Panel2.Controls.Add(this.linkLabel1);
         this.splitContainer.Panel2.Controls.Add(this.label2);
         this.splitContainer.Panel2.Controls.Add(this.basemapCbx);
         this.splitContainer.Panel2.Controls.Add(this.fullExtendBtn);
         this.splitContainer.Panel2.Controls.Add(this.zoomOUTBtn);
         this.splitContainer.Panel2.Controls.Add(this.zoomINBtn);
         this.splitContainer.Panel2.Controls.Add(this.mapBox);
         this.splitContainer.Size = new System.Drawing.Size(1176, 690);
         this.splitContainer.SplitterDistance = 830;
         this.splitContainer.TabIndex = 2;
         // 
         // progressLbl
         // 
         this.progressLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.progressLbl.AutoSize = true;
         this.progressLbl.BackColor = System.Drawing.Color.Transparent;
         this.progressLbl.Location = new System.Drawing.Point(342, 661);
         this.progressLbl.Name = "progressLbl";
         this.progressLbl.Size = new System.Drawing.Size(20, 17);
         this.progressLbl.TabIndex = 16;
         this.progressLbl.Text = "...";
         // 
         // progressBar
         // 
         this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
         this.progressBar.Location = new System.Drawing.Point(11, 656);
         this.progressBar.Name = "progressBar";
         this.progressBar.Size = new System.Drawing.Size(325, 23);
         this.progressBar.TabIndex = 13;
         // 
         // closeBtn
         // 
         this.closeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.closeBtn.Location = new System.Drawing.Point(710, 655);
         this.closeBtn.Name = "closeBtn";
         this.closeBtn.Size = new System.Drawing.Size(113, 28);
         this.closeBtn.TabIndex = 14;
         this.closeBtn.Text = "Afsluiten";
         this.closeBtn.UseVisualStyleBackColor = true;
         // 
         // gridPanel
         // 
         this.gridPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.gridPanel.Controls.Add(this.csvDataGrid);
         this.gridPanel.Controls.Add(this.gridTools);
         this.gridPanel.Location = new System.Drawing.Point(11, 229);
         this.gridPanel.Margin = new System.Windows.Forms.Padding(4);
         this.gridPanel.Name = "gridPanel";
         this.gridPanel.Size = new System.Drawing.Size(811, 419);
         this.gridPanel.TabIndex = 12;
         // 
         // csvDataGrid
         // 
         this.csvDataGrid.AllowUserToAddRows = false;
         this.csvDataGrid.AllowUserToDeleteRows = false;
         this.csvDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.csvDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
         this.csvDataGrid.Location = new System.Drawing.Point(0, 27);
         this.csvDataGrid.Margin = new System.Windows.Forms.Padding(4);
         this.csvDataGrid.Name = "csvDataGrid";
         this.csvDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
         this.csvDataGrid.Size = new System.Drawing.Size(811, 392);
         this.csvDataGrid.TabIndex = 6;
         this.csvDataGrid.SelectionChanged += new System.EventHandler(this.csvDataGrid_SelectionChanged);
         // 
         // gridTools
         // 
         this.gridTools.ImageScalingSize = new System.Drawing.Size(20, 20);
         this.gridTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.validateAllBtn,
            this.validateSelBtn,
            this.cancelValidationBtn,
            this.toolStripSeparator1,
            this.manualLocBtn,
            this.zoom2selBtn});
         this.gridTools.Location = new System.Drawing.Point(0, 0);
         this.gridTools.Name = "gridTools";
         this.gridTools.Size = new System.Drawing.Size(811, 27);
         this.gridTools.TabIndex = 5;
         this.gridTools.Text = "Tabel tools";
         // 
         // validateAllBtn
         // 
         this.validateAllBtn.Image = ((System.Drawing.Image)(resources.GetObject("validateAllBtn.Image")));
         this.validateAllBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.validateAllBtn.Name = "validateAllBtn";
         this.validateAllBtn.Size = new System.Drawing.Size(121, 24);
         this.validateAllBtn.Text = "Valideer alles";
         this.validateAllBtn.ToolTipText = "Valideer alle records";
         this.validateAllBtn.Click += new System.EventHandler(this.validateAllBtn_Click);
         // 
         // validateSelBtn
         // 
         this.validateSelBtn.Image = ((System.Drawing.Image)(resources.GetObject("validateSelBtn.Image")));
         this.validateSelBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.validateSelBtn.Name = "validateSelBtn";
         this.validateSelBtn.Size = new System.Drawing.Size(141, 24);
         this.validateSelBtn.Text = "Valideer selectie";
         this.validateSelBtn.ToolTipText = "Valideer alleen de geselecteerde records";
         this.validateSelBtn.Click += new System.EventHandler(this.validateSelBtn_Click);
         // 
         // cancelValidationBtn
         // 
         this.cancelValidationBtn.Image = ((System.Drawing.Image)(resources.GetObject("cancelValidationBtn.Image")));
         this.cancelValidationBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.cancelValidationBtn.Name = "cancelValidationBtn";
         this.cancelValidationBtn.Size = new System.Drawing.Size(92, 24);
         this.cancelValidationBtn.Text = "Annuleer";
         this.cancelValidationBtn.ToolTipText = "Annuleer validatie, onderbreek uitvoering";
         this.cancelValidationBtn.Click += new System.EventHandler(this.cancelValidationBtn_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
         // 
         // manualLocBtn
         // 
         this.manualLocBtn.Image = ((System.Drawing.Image)(resources.GetObject("manualLocBtn.Image")));
         this.manualLocBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.manualLocBtn.Name = "manualLocBtn";
         this.manualLocBtn.Size = new System.Drawing.Size(186, 24);
         this.manualLocBtn.Text = "Prik de locatie op kaart";
         this.manualLocBtn.ToolTipText = "Duid de locatie van de geselecteerde records op de kaart aan";
         this.manualLocBtn.Click += new System.EventHandler(this.manualLocBtn_Click);
         // 
         // zoom2selBtn
         // 
         this.zoom2selBtn.Image = ((System.Drawing.Image)(resources.GetObject("zoom2selBtn.Image")));
         this.zoom2selBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.zoom2selBtn.Name = "zoom2selBtn";
         this.zoom2selBtn.Size = new System.Drawing.Size(162, 24);
         this.zoom2selBtn.Text = "Zoom naar Selectie";
         this.zoom2selBtn.ToolTipText = "Zoom naar Selectie (Maximaal 30 rijen)";
         this.zoom2selBtn.Click += new System.EventHandler(this.zoom2selBtn_Click);
         // 
         // adresSettingsBox
         // 
         this.adresSettingsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.adresSettingsBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.adresSettingsBox.Controls.Add(this.label4);
         this.adresSettingsBox.Controls.Add(this.walGeocoderRadio);
         this.adresSettingsBox.Controls.Add(this.vlGeocoderRadio);
         this.adresSettingsBox.Controls.Add(this.postcodeColCbx);
         this.adresSettingsBox.Controls.Add(this.gemeenteColCbx);
         this.adresSettingsBox.Controls.Add(this.HuisNrCbx);
         this.adresSettingsBox.Controls.Add(this.huisNrColLbl);
         this.adresSettingsBox.Controls.Add(this.GemeenteColLbl);
         this.adresSettingsBox.Controls.Add(this.straatColCbx);
         this.adresSettingsBox.Controls.Add(this.adresColLbl);
         this.adresSettingsBox.Controls.Add(this.label1);
         this.adresSettingsBox.Location = new System.Drawing.Point(11, 104);
         this.adresSettingsBox.Margin = new System.Windows.Forms.Padding(4);
         this.adresSettingsBox.MaximumSize = new System.Drawing.Size(5000, 190);
         this.adresSettingsBox.MinimumSize = new System.Drawing.Size(400, 80);
         this.adresSettingsBox.Name = "adresSettingsBox";
         this.adresSettingsBox.Padding = new System.Windows.Forms.Padding(4);
         this.adresSettingsBox.Size = new System.Drawing.Size(803, 117);
         this.adresSettingsBox.TabIndex = 11;
         this.adresSettingsBox.TabStop = false;
         this.adresSettingsBox.Text = "Adres Instellingen";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(6, 22);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(133, 17);
         this.label4.TabIndex = 19;
         this.label4.Text = "Gewest (geocoder):";
         // 
         // walGeocoderRadio
         // 
         this.walGeocoderRadio.AutoSize = true;
         this.walGeocoderRadio.Location = new System.Drawing.Point(263, 20);
         this.walGeocoderRadio.Name = "walGeocoderRadio";
         this.walGeocoderRadio.Size = new System.Drawing.Size(150, 21);
         this.walGeocoderRadio.TabIndex = 17;
         this.walGeocoderRadio.Text = "Wallonië of Brussel";
         this.walGeocoderRadio.UseVisualStyleBackColor = true;
         // 
         // vlGeocoderRadio
         // 
         this.vlGeocoderRadio.AutoSize = true;
         this.vlGeocoderRadio.Checked = true;
         this.vlGeocoderRadio.Location = new System.Drawing.Point(155, 22);
         this.vlGeocoderRadio.Name = "vlGeocoderRadio";
         this.vlGeocoderRadio.Size = new System.Drawing.Size(102, 21);
         this.vlGeocoderRadio.TabIndex = 16;
         this.vlGeocoderRadio.TabStop = true;
         this.vlGeocoderRadio.Text = "Vlaanderen";
         this.vlGeocoderRadio.UseVisualStyleBackColor = true;
         // 
         // postcodeColCbx
         // 
         this.postcodeColCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.postcodeColCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.postcodeColCbx.FormattingEnabled = true;
         this.postcodeColCbx.Location = new System.Drawing.Point(616, 52);
         this.postcodeColCbx.Margin = new System.Windows.Forms.Padding(4);
         this.postcodeColCbx.MaximumSize = new System.Drawing.Size(260, 0);
         this.postcodeColCbx.MinimumSize = new System.Drawing.Size(60, 0);
         this.postcodeColCbx.Name = "postcodeColCbx";
         this.postcodeColCbx.Size = new System.Drawing.Size(179, 24);
         this.postcodeColCbx.TabIndex = 15;
         // 
         // gemeenteColCbx
         // 
         this.gemeenteColCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.gemeenteColCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.gemeenteColCbx.FormattingEnabled = true;
         this.gemeenteColCbx.Location = new System.Drawing.Point(616, 84);
         this.gemeenteColCbx.Margin = new System.Windows.Forms.Padding(4);
         this.gemeenteColCbx.MaximumSize = new System.Drawing.Size(260, 0);
         this.gemeenteColCbx.MinimumSize = new System.Drawing.Size(60, 0);
         this.gemeenteColCbx.Name = "gemeenteColCbx";
         this.gemeenteColCbx.Size = new System.Drawing.Size(179, 24);
         this.gemeenteColCbx.TabIndex = 10;
         // 
         // HuisNrCbx
         // 
         this.HuisNrCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.HuisNrCbx.FormattingEnabled = true;
         this.HuisNrCbx.Location = new System.Drawing.Point(146, 84);
         this.HuisNrCbx.Margin = new System.Windows.Forms.Padding(4);
         this.HuisNrCbx.MaximumSize = new System.Drawing.Size(260, 0);
         this.HuisNrCbx.MinimumSize = new System.Drawing.Size(60, 0);
         this.HuisNrCbx.Name = "HuisNrCbx";
         this.HuisNrCbx.Size = new System.Drawing.Size(179, 24);
         this.HuisNrCbx.TabIndex = 12;
         // 
         // huisNrColLbl
         // 
         this.huisNrColLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.huisNrColLbl.AutoSize = true;
         this.huisNrColLbl.Location = new System.Drawing.Point(8, 87);
         this.huisNrColLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
         this.huisNrColLbl.Name = "huisNrColLbl";
         this.huisNrColLbl.Size = new System.Drawing.Size(136, 17);
         this.huisNrColLbl.TabIndex = 11;
         this.huisNrColLbl.Text = "Huisnummer kolom: ";
         // 
         // GemeenteColLbl
         // 
         this.GemeenteColLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.GemeenteColLbl.AutoSize = true;
         this.GemeenteColLbl.Location = new System.Drawing.Point(485, 87);
         this.GemeenteColLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
         this.GemeenteColLbl.Name = "GemeenteColLbl";
         this.GemeenteColLbl.Size = new System.Drawing.Size(123, 17);
         this.GemeenteColLbl.TabIndex = 9;
         this.GemeenteColLbl.Text = "Gemeente kolom: \r\n";
         // 
         // straatColCbx
         // 
         this.straatColCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.straatColCbx.FormattingEnabled = true;
         this.straatColCbx.Location = new System.Drawing.Point(146, 52);
         this.straatColCbx.Margin = new System.Windows.Forms.Padding(4);
         this.straatColCbx.MaximumSize = new System.Drawing.Size(260, 0);
         this.straatColCbx.MinimumSize = new System.Drawing.Size(60, 0);
         this.straatColCbx.Name = "straatColCbx";
         this.straatColCbx.Size = new System.Drawing.Size(179, 24);
         this.straatColCbx.TabIndex = 8;
         // 
         // adresColLbl
         // 
         this.adresColLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.adresColLbl.AutoSize = true;
         this.adresColLbl.Location = new System.Drawing.Point(9, 59);
         this.adresColLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
         this.adresColLbl.Name = "adresColLbl";
         this.adresColLbl.Size = new System.Drawing.Size(130, 17);
         this.adresColLbl.TabIndex = 7;
         this.adresColLbl.Text = "Straatnaam kolom: ";
         // 
         // label1
         // 
         this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(485, 55);
         this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(116, 17);
         this.label1.TabIndex = 12;
         this.label1.Text = "Postcode kolom: \r\n";
         // 
         // csvBox
         // 
         this.csvBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.csvBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
         this.csvBox.Controls.Add(this.label3);
         this.csvBox.Controls.Add(this.encodingCbx);
         this.csvBox.Controls.Add(this.otherSepBox);
         this.csvBox.Controls.Add(this.csvPathTxt);
         this.csvBox.Controls.Add(this.sepCbx);
         this.csvBox.Controls.Add(this.openBtn);
         this.csvBox.Controls.Add(this.sepLbl);
         this.csvBox.Location = new System.Drawing.Point(11, 11);
         this.csvBox.Margin = new System.Windows.Forms.Padding(4);
         this.csvBox.MinimumSize = new System.Drawing.Size(400, 80);
         this.csvBox.Name = "csvBox";
         this.csvBox.Padding = new System.Windows.Forms.Padding(4);
         this.csvBox.Size = new System.Drawing.Size(811, 85);
         this.csvBox.TabIndex = 10;
         this.csvBox.TabStop = false;
         this.csvBox.Text = "CSV instellingen";
         // 
         // label3
         // 
         this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(613, 52);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(71, 17);
         this.label3.TabIndex = 15;
         this.label3.Text = "Encoding:";
         // 
         // encodingCbx
         // 
         this.encodingCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.encodingCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.encodingCbx.FormattingEnabled = true;
         this.encodingCbx.Items.AddRange(new object[] {
            "Default",
            "UTF-8",
            "ANSI"});
         this.encodingCbx.Location = new System.Drawing.Point(690, 49);
         this.encodingCbx.Name = "encodingCbx";
         this.encodingCbx.Size = new System.Drawing.Size(113, 24);
         this.encodingCbx.TabIndex = 14;
         // 
         // otherSepBox
         // 
         this.otherSepBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.otherSepBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
         this.otherSepBox.Location = new System.Drawing.Point(579, 49);
         this.otherSepBox.Margin = new System.Windows.Forms.Padding(4);
         this.otherSepBox.Name = "otherSepBox";
         this.otherSepBox.Size = new System.Drawing.Size(22, 26);
         this.otherSepBox.TabIndex = 12;
         // 
         // csvPathTxt
         // 
         this.csvPathTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this.csvPathTxt.Location = new System.Drawing.Point(12, 17);
         this.csvPathTxt.Margin = new System.Windows.Forms.Padding(4);
         this.csvPathTxt.Name = "csvPathTxt";
         this.csvPathTxt.ReadOnly = true;
         this.csvPathTxt.Size = new System.Drawing.Size(700, 22);
         this.csvPathTxt.TabIndex = 6;
         this.csvPathTxt.Text = "< input CSV-file >";
         this.csvPathTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
         // 
         // sepCbx
         // 
         this.sepCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.sepCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.sepCbx.FormattingEnabled = true;
         this.sepCbx.Items.AddRange(new object[] {
            "Puntcomma",
            "Comma",
            "Spatie",
            "Tab",
            "Ander:"});
         this.sepCbx.Location = new System.Drawing.Point(453, 49);
         this.sepCbx.Margin = new System.Windows.Forms.Padding(4);
         this.sepCbx.Name = "sepCbx";
         this.sepCbx.Size = new System.Drawing.Size(118, 24);
         this.sepCbx.TabIndex = 11;
         // 
         // openBtn
         // 
         this.openBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.openBtn.Location = new System.Drawing.Point(720, 14);
         this.openBtn.Margin = new System.Windows.Forms.Padding(4);
         this.openBtn.Name = "openBtn";
         this.openBtn.Size = new System.Drawing.Size(83, 28);
         this.openBtn.TabIndex = 2;
         this.openBtn.Text = "Open";
         this.openBtn.UseVisualStyleBackColor = true;
         this.openBtn.Click += new System.EventHandler(this.openBtn_Click);
         // 
         // sepLbl
         // 
         this.sepLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.sepLbl.AutoSize = true;
         this.sepLbl.Location = new System.Drawing.Point(366, 52);
         this.sepLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
         this.sepLbl.Name = "sepLbl";
         this.sepLbl.Size = new System.Drawing.Size(79, 17);
         this.sepLbl.TabIndex = 10;
         this.sepLbl.Text = "Separator: ";
         // 
         // label2
         // 
         this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(103, 631);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(122, 17);
         this.label2.TabIndex = 11;
         this.label2.Text = "Achtergrondkaart:";
         // 
         // basemapCbx
         // 
         this.basemapCbx.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.basemapCbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.basemapCbx.FormattingEnabled = true;
         this.basemapCbx.Items.AddRange(new object[] {
            "GRB",
            "Luchtfoto",
            "Antwerpen",
            "Openstreetmap"});
         this.basemapCbx.Location = new System.Drawing.Point(231, 628);
         this.basemapCbx.Name = "basemapCbx";
         this.basemapCbx.Size = new System.Drawing.Size(104, 24);
         this.basemapCbx.TabIndex = 8;
         this.basemapCbx.TabStop = false;
         this.basemapCbx.SelectedIndexChanged += new System.EventHandler(this.basemapCbx_SelectedIndexChanged);
         // 
         // fullExtendBtn
         // 
         this.fullExtendBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.fullExtendBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
         this.fullExtendBtn.Location = new System.Drawing.Point(300, 40);
         this.fullExtendBtn.Name = "fullExtendBtn";
         this.fullExtendBtn.Size = new System.Drawing.Size(28, 28);
         this.fullExtendBtn.TabIndex = 4;
         this.fullExtendBtn.Text = "H";
         this.fullExtendBtn.UseVisualStyleBackColor = true;
         this.fullExtendBtn.Click += new System.EventHandler(this.fullExtendBtn_Click);
         // 
         // zoomOUTBtn
         // 
         this.zoomOUTBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.zoomOUTBtn.Location = new System.Drawing.Point(300, 74);
         this.zoomOUTBtn.Name = "zoomOUTBtn";
         this.zoomOUTBtn.Size = new System.Drawing.Size(28, 23);
         this.zoomOUTBtn.TabIndex = 3;
         this.zoomOUTBtn.Text = "-";
         this.zoomOUTBtn.UseVisualStyleBackColor = true;
         this.zoomOUTBtn.Click += new System.EventHandler(this.zoomOUTBtn_Click);
         // 
         // zoomINBtn
         // 
         this.zoomINBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
         this.zoomINBtn.Location = new System.Drawing.Point(300, 10);
         this.zoomINBtn.Name = "zoomINBtn";
         this.zoomINBtn.Size = new System.Drawing.Size(28, 23);
         this.zoomINBtn.TabIndex = 2;
         this.zoomINBtn.Text = "+";
         this.zoomINBtn.UseVisualStyleBackColor = true;
         this.zoomINBtn.Click += new System.EventHandler(this.zoomINBtn_Click);
         // 
         // openTableDlg
         // 
         this.openTableDlg.Filter = "CSV-file|*.csv|Text-file|*.txt|All files|*.*";
         this.openTableDlg.Title = "Open CSV";
         // 
         // linkLabel1
         // 
         this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this.linkLabel1.AutoSize = true;
         this.linkLabel1.Location = new System.Drawing.Point(191, 669);
         this.linkLabel1.Name = "linkLabel1";
         this.linkLabel1.Size = new System.Drawing.Size(147, 17);
         this.linkLabel1.TabIndex = 12;
         this.linkLabel1.TabStop = true;
         this.linkLabel1.Text = "Over deze toepassing";
         this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(1176, 690);
         this.Controls.Add(this.splitContainer);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "MainForm";
         this.Text = "Adressen Geocoderen";
         this.splitContainer.Panel1.ResumeLayout(false);
         this.splitContainer.Panel1.PerformLayout();
         this.splitContainer.Panel2.ResumeLayout(false);
         this.splitContainer.Panel2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
         this.splitContainer.ResumeLayout(false);
         this.gridPanel.ResumeLayout(false);
         this.gridPanel.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.csvDataGrid)).EndInit();
         this.gridTools.ResumeLayout(false);
         this.gridTools.PerformLayout();
         this.adresSettingsBox.ResumeLayout(false);
         this.adresSettingsBox.PerformLayout();
         this.csvBox.ResumeLayout(false);
         this.csvBox.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private SharpMap.Forms.MapBox mapBox;
      private System.Windows.Forms.Button saveBtn;
      private System.Windows.Forms.SaveFileDialog saveShapeDlg;
      private System.Windows.Forms.SplitContainer splitContainer;
      private System.Windows.Forms.Button fullExtendBtn;
      private System.Windows.Forms.ComboBox basemapCbx;
      private System.Windows.Forms.GroupBox csvBox;
      private System.Windows.Forms.ComboBox encodingCbx;
      private System.Windows.Forms.TextBox otherSepBox;
      private System.Windows.Forms.TextBox csvPathTxt;
      private System.Windows.Forms.ComboBox sepCbx;
      private System.Windows.Forms.Button openBtn;
      private System.Windows.Forms.Label sepLbl;
      private System.Windows.Forms.GroupBox adresSettingsBox;
      private System.Windows.Forms.ComboBox HuisNrCbx;
      private System.Windows.Forms.Label huisNrColLbl;
      private System.Windows.Forms.ComboBox gemeenteColCbx;
      private System.Windows.Forms.Label GemeenteColLbl;
      private System.Windows.Forms.ComboBox straatColCbx;
      private System.Windows.Forms.Label adresColLbl;
      private System.Windows.Forms.ComboBox postcodeColCbx;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Panel gridPanel;
      private System.Windows.Forms.DataGridView csvDataGrid;
      private System.Windows.Forms.ToolStrip gridTools;
      private System.Windows.Forms.ToolStripButton validateAllBtn;
      private System.Windows.Forms.ToolStripButton validateSelBtn;
      private System.Windows.Forms.ToolStripButton cancelValidationBtn;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripButton manualLocBtn;
      private System.Windows.Forms.ToolStripButton zoom2selBtn;
      private System.Windows.Forms.OpenFileDialog openTableDlg;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.ProgressBar progressBar;
      private System.Windows.Forms.Button zoomOUTBtn;
      private System.Windows.Forms.Button zoomINBtn;
      private System.Windows.Forms.Button closeBtn;
      private System.Windows.Forms.Label progressLbl;
      private System.Windows.Forms.RadioButton walGeocoderRadio;
      private System.Windows.Forms.RadioButton vlGeocoderRadio;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.LinkLabel linkLabel1;
   }
}

