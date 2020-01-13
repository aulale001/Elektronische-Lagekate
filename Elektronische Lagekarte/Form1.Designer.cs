namespace Elektronische_Lagekarte
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitterleft = new System.Windows.Forms.Splitter();
            this.panelmiddel = new System.Windows.Forms.Panel();
            this.map = new GMap.NET.WindowsForms.GMapControl();
            this.buttonload = new System.Windows.Forms.Button();
            this.buttonsave = new System.Windows.Forms.Button();
            this.buttonnew = new System.Windows.Forms.Button();
            this.textBoxwarning = new System.Windows.Forms.TextBox();
            this.buttonreloadmap = new System.Windows.Forms.Button();
            this.comboBoxmap = new System.Windows.Forms.ComboBox();
            this.taballg = new System.Windows.Forms.TabControl();
            this.panelleft = new System.Windows.Forms.Panel();
            this.buttonnavigate = new System.Windows.Forms.Button();
            this.richTextBoxplace = new System.Windows.Forms.RichTextBox();
            this.textBoxradius = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonrightturn = new System.Windows.Forms.Button();
            this.buttonnorth = new System.Windows.Forms.Button();
            this.buttonleftturn = new System.Windows.Forms.Button();
            this.splitterright = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonjump = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabplacedicons = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxname = new System.Windows.Forms.RichTextBox();
            this.buttonmove = new System.Windows.Forms.Button();
            this.buttonsetchanges = new System.Windows.Forms.Button();
            this.richTextBoxPos = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelposition = new System.Windows.Forms.Label();
            this.listBoxplacedIcons = new System.Windows.Forms.ListBox();
            this.txtsearchbar = new System.Windows.Forms.RichTextBox();
            this.tabhoselines = new System.Windows.Forms.TabPage();
            this.buttonsavehose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBoxdistance = new System.Windows.Forms.RichTextBox();
            this.richTextBoxnamehose = new System.Windows.Forms.RichTextBox();
            this.listBoxhoselines = new System.Windows.Forms.ListBox();
            this.tabareas = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.richTextBoxaream = new System.Windows.Forms.RichTextBox();
            this.buttonsavearea = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBoxarea = new System.Windows.Forms.RichTextBox();
            this.richTextBoxnamearea = new System.Windows.Forms.RichTextBox();
            this.listBoxareas = new System.Windows.Forms.ListBox();
            this.tabconfigs = new System.Windows.Forms.TabPage();
            this.checkBoxaltimages = new System.Windows.Forms.CheckBox();
            this.checkedListBoxlayers = new System.Windows.Forms.CheckedListBox();
            this.panelmiddel.SuspendLayout();
            this.panelleft.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabplacedicons.SuspendLayout();
            this.tabhoselines.SuspendLayout();
            this.tabareas.SuspendLayout();
            this.tabconfigs.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitterleft
            // 
            this.splitterleft.Location = new System.Drawing.Point(250, 0);
            this.splitterleft.Name = "splitterleft";
            this.splitterleft.Size = new System.Drawing.Size(3, 611);
            this.splitterleft.TabIndex = 1;
            this.splitterleft.TabStop = false;
            // 
            // panelmiddel
            // 
            this.panelmiddel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelmiddel.Controls.Add(this.map);
            this.panelmiddel.Controls.Add(this.buttonload);
            this.panelmiddel.Controls.Add(this.buttonsave);
            this.panelmiddel.Controls.Add(this.buttonnew);
            this.panelmiddel.Controls.Add(this.textBoxwarning);
            this.panelmiddel.Controls.Add(this.buttonreloadmap);
            this.panelmiddel.Controls.Add(this.comboBoxmap);
            this.panelmiddel.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelmiddel.Location = new System.Drawing.Point(253, 0);
            this.panelmiddel.MinimumSize = new System.Drawing.Size(770, 2);
            this.panelmiddel.Name = "panelmiddel";
            this.panelmiddel.Size = new System.Drawing.Size(897, 611);
            this.panelmiddel.TabIndex = 2;
            // 
            // map
            // 
            this.map.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.map.Bearing = 0F;
            this.map.CanDragMap = true;
            this.map.EmptyTileColor = System.Drawing.Color.Navy;
            this.map.GrayScaleMode = false;
            this.map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.map.LevelsKeepInMemmory = 5;
            this.map.Location = new System.Drawing.Point(3, 33);
            this.map.MarkersEnabled = true;
            this.map.MaxZoom = 2;
            this.map.MinZoom = 2;
            this.map.MouseWheelZoomEnabled = true;
            this.map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.map.Name = "map";
            this.map.NegativeMode = false;
            this.map.PolygonsEnabled = true;
            this.map.RetryLoadTile = 0;
            this.map.RoutesEnabled = true;
            this.map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.map.ShowTileGridLines = false;
            this.map.Size = new System.Drawing.Size(883, 565);
            this.map.TabIndex = 6;
            this.map.Zoom = 0D;
            this.map.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.Map_OnMarkerClick);
            this.map.OnPolygonClick += new GMap.NET.WindowsForms.PolygonClick(this.Map_OnPolygonClick);
            this.map.OnRouteClick += new GMap.NET.WindowsForms.RouteClick(this.Map_OnRouteClick);
            this.map.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Map_MouseDown);
            this.map.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Map_MouseUp);
            // 
            // buttonload
            // 
            this.buttonload.Location = new System.Drawing.Point(684, 5);
            this.buttonload.Name = "buttonload";
            this.buttonload.Size = new System.Drawing.Size(75, 23);
            this.buttonload.TabIndex = 5;
            this.buttonload.Text = "button3";
            this.buttonload.UseVisualStyleBackColor = true;
            // 
            // buttonsave
            // 
            this.buttonsave.Location = new System.Drawing.Point(603, 5);
            this.buttonsave.Name = "buttonsave";
            this.buttonsave.Size = new System.Drawing.Size(75, 23);
            this.buttonsave.TabIndex = 4;
            this.buttonsave.Text = "button2";
            this.buttonsave.UseVisualStyleBackColor = true;
            // 
            // buttonnew
            // 
            this.buttonnew.Location = new System.Drawing.Point(522, 5);
            this.buttonnew.Name = "buttonnew";
            this.buttonnew.Size = new System.Drawing.Size(75, 23);
            this.buttonnew.TabIndex = 3;
            this.buttonnew.Text = "Neu";
            this.buttonnew.UseVisualStyleBackColor = true;
            this.buttonnew.Click += new System.EventHandler(this.Buttonnew_Click);
            // 
            // textBoxwarning
            // 
            this.textBoxwarning.Location = new System.Drawing.Point(215, 5);
            this.textBoxwarning.Multiline = true;
            this.textBoxwarning.Name = "textBoxwarning";
            this.textBoxwarning.ReadOnly = true;
            this.textBoxwarning.Size = new System.Drawing.Size(301, 20);
            this.textBoxwarning.TabIndex = 2;
            // 
            // buttonreloadmap
            // 
            this.buttonreloadmap.Location = new System.Drawing.Point(133, 5);
            this.buttonreloadmap.Name = "buttonreloadmap";
            this.buttonreloadmap.Size = new System.Drawing.Size(75, 23);
            this.buttonreloadmap.TabIndex = 1;
            this.buttonreloadmap.Text = "Neuladen";
            this.buttonreloadmap.UseVisualStyleBackColor = true;
            this.buttonreloadmap.Click += new System.EventHandler(this.Buttonreloadmap_Click);
            // 
            // comboBoxmap
            // 
            this.comboBoxmap.FormattingEnabled = true;
            this.comboBoxmap.Items.AddRange(new object[] {
            "Openstreet+Radwege",
            "Google Hybrid",
            "Google Karte",
            "Openstreetmap"});
            this.comboBoxmap.Location = new System.Drawing.Point(5, 5);
            this.comboBoxmap.Name = "comboBoxmap";
            this.comboBoxmap.Size = new System.Drawing.Size(121, 21);
            this.comboBoxmap.TabIndex = 0;
            this.comboBoxmap.SelectedIndexChanged += new System.EventHandler(this.ComboBoxmap_SelectedIndexChanged);
            // 
            // taballg
            // 
            this.taballg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.taballg.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.taballg.Location = new System.Drawing.Point(4, 5);
            this.taballg.Multiline = true;
            this.taballg.Name = "taballg";
            this.taballg.SelectedIndex = 0;
            this.taballg.Size = new System.Drawing.Size(239, 369);
            this.taballg.TabIndex = 0;
            // 
            // panelleft
            // 
            this.panelleft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelleft.Controls.Add(this.buttonnavigate);
            this.panelleft.Controls.Add(this.richTextBoxplace);
            this.panelleft.Controls.Add(this.textBoxradius);
            this.panelleft.Controls.Add(this.label1);
            this.panelleft.Controls.Add(this.buttonrightturn);
            this.panelleft.Controls.Add(this.buttonnorth);
            this.panelleft.Controls.Add(this.buttonleftturn);
            this.panelleft.Controls.Add(this.taballg);
            this.panelleft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelleft.Location = new System.Drawing.Point(0, 0);
            this.panelleft.MinimumSize = new System.Drawing.Size(250, 2);
            this.panelleft.Name = "panelleft";
            this.panelleft.Size = new System.Drawing.Size(250, 611);
            this.panelleft.TabIndex = 0;
            // 
            // buttonnavigate
            // 
            this.buttonnavigate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonnavigate.Location = new System.Drawing.Point(4, 567);
            this.buttonnavigate.Name = "buttonnavigate";
            this.buttonnavigate.Size = new System.Drawing.Size(241, 23);
            this.buttonnavigate.TabIndex = 7;
            this.buttonnavigate.Text = "Navigieren";
            this.buttonnavigate.UseVisualStyleBackColor = true;
            this.buttonnavigate.Click += new System.EventHandler(this.Buttonnavigate_Click);
            // 
            // richTextBoxplace
            // 
            this.richTextBoxplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBoxplace.Location = new System.Drawing.Point(7, 499);
            this.richTextBoxplace.Name = "richTextBoxplace";
            this.richTextBoxplace.Size = new System.Drawing.Size(234, 61);
            this.richTextBoxplace.TabIndex = 6;
            this.richTextBoxplace.Text = "";
            this.richTextBoxplace.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBoxplace_KeyPress);
            this.richTextBoxplace.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBoxplace_KeyUp);
            // 
            // textBoxradius
            // 
            this.textBoxradius.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxradius.Location = new System.Drawing.Point(4, 443);
            this.textBoxradius.Name = "textBoxradius";
            this.textBoxradius.Size = new System.Drawing.Size(237, 20);
            this.textBoxradius.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 426);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kreisradius";
            // 
            // buttonrightturn
            // 
            this.buttonrightturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonrightturn.Location = new System.Drawing.Point(166, 380);
            this.buttonrightturn.Name = "buttonrightturn";
            this.buttonrightturn.Size = new System.Drawing.Size(75, 39);
            this.buttonrightturn.TabIndex = 3;
            this.buttonrightturn.Text = "Im Uhrzeigersinn";
            this.buttonrightturn.UseVisualStyleBackColor = true;
            this.buttonrightturn.Click += new System.EventHandler(this.Buttonrightturn_Click);
            // 
            // buttonnorth
            // 
            this.buttonnorth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonnorth.Location = new System.Drawing.Point(85, 380);
            this.buttonnorth.Name = "buttonnorth";
            this.buttonnorth.Size = new System.Drawing.Size(75, 39);
            this.buttonnorth.TabIndex = 2;
            this.buttonnorth.Text = "Norden";
            this.buttonnorth.UseVisualStyleBackColor = true;
            this.buttonnorth.Click += new System.EventHandler(this.Buttonnorth_Click);
            // 
            // buttonleftturn
            // 
            this.buttonleftturn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonleftturn.Location = new System.Drawing.Point(4, 380);
            this.buttonleftturn.Name = "buttonleftturn";
            this.buttonleftturn.Size = new System.Drawing.Size(75, 39);
            this.buttonleftturn.TabIndex = 1;
            this.buttonleftturn.Text = "Gegen Uhrzeigersinn";
            this.buttonleftturn.UseVisualStyleBackColor = true;
            this.buttonleftturn.Click += new System.EventHandler(this.Buttonleftturn_Click);
            // 
            // splitterright
            // 
            this.splitterright.Location = new System.Drawing.Point(1150, 0);
            this.splitterright.Name = "splitterright";
            this.splitterright.Size = new System.Drawing.Size(3, 611);
            this.splitterright.TabIndex = 3;
            this.splitterright.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonjump);
            this.panel1.Controls.Add(this.tabControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(1153, 0);
            this.panel1.MinimumSize = new System.Drawing.Size(300, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 611);
            this.panel1.TabIndex = 4;
            // 
            // buttonjump
            // 
            this.buttonjump.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonjump.Location = new System.Drawing.Point(11, 568);
            this.buttonjump.Name = "buttonjump";
            this.buttonjump.Size = new System.Drawing.Size(279, 23);
            this.buttonjump.TabIndex = 21;
            this.buttonjump.Text = "Zu Objekt springen";
            this.buttonjump.UseVisualStyleBackColor = true;
            this.buttonjump.Click += new System.EventHandler(this.Buttonjump_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabplacedicons);
            this.tabControl.Controls.Add(this.tabhoselines);
            this.tabControl.Controls.Add(this.tabareas);
            this.tabControl.Controls.Add(this.tabconfigs);
            this.tabControl.Location = new System.Drawing.Point(7, 6);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(283, 555);
            this.tabControl.TabIndex = 0;
            // 
            // tabplacedicons
            // 
            this.tabplacedicons.Controls.Add(this.label8);
            this.tabplacedicons.Controls.Add(this.textBoxname);
            this.tabplacedicons.Controls.Add(this.buttonmove);
            this.tabplacedicons.Controls.Add(this.buttonsetchanges);
            this.tabplacedicons.Controls.Add(this.richTextBoxPos);
            this.tabplacedicons.Controls.Add(this.label2);
            this.tabplacedicons.Controls.Add(this.labelposition);
            this.tabplacedicons.Controls.Add(this.listBoxplacedIcons);
            this.tabplacedicons.Controls.Add(this.txtsearchbar);
            this.tabplacedicons.Location = new System.Drawing.Point(4, 22);
            this.tabplacedicons.Name = "tabplacedicons";
            this.tabplacedicons.Padding = new System.Windows.Forms.Padding(3);
            this.tabplacedicons.Size = new System.Drawing.Size(275, 529);
            this.tabplacedicons.TabIndex = 0;
            this.tabplacedicons.Text = "Platzierte Zeichen";
            this.tabplacedicons.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "0";
            // 
            // textBoxname
            // 
            this.textBoxname.Location = new System.Drawing.Point(58, 440);
            this.textBoxname.Name = "textBoxname";
            this.textBoxname.Size = new System.Drawing.Size(211, 20);
            this.textBoxname.TabIndex = 24;
            this.textBoxname.Text = "";
            // 
            // buttonmove
            // 
            this.buttonmove.Location = new System.Drawing.Point(152, 496);
            this.buttonmove.Name = "buttonmove";
            this.buttonmove.Size = new System.Drawing.Size(117, 23);
            this.buttonmove.TabIndex = 23;
            this.buttonmove.Text = "Bewegen";
            this.buttonmove.UseVisualStyleBackColor = true;
            this.buttonmove.Click += new System.EventHandler(this.Buttonmove_Click);
            // 
            // buttonsetchanges
            // 
            this.buttonsetchanges.Location = new System.Drawing.Point(3, 496);
            this.buttonsetchanges.Name = "buttonsetchanges";
            this.buttonsetchanges.Size = new System.Drawing.Size(124, 23);
            this.buttonsetchanges.TabIndex = 22;
            this.buttonsetchanges.Text = "Speichern";
            this.buttonsetchanges.UseVisualStyleBackColor = true;
            this.buttonsetchanges.Click += new System.EventHandler(this.Buttonsetchanges_Click);
            // 
            // richTextBoxPos
            // 
            this.richTextBoxPos.Location = new System.Drawing.Point(58, 470);
            this.richTextBoxPos.Name = "richTextBoxPos";
            this.richTextBoxPos.ReadOnly = true;
            this.richTextBoxPos.Size = new System.Drawing.Size(211, 20);
            this.richTextBoxPos.TabIndex = 21;
            this.richTextBoxPos.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 443);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Name";
            // 
            // labelposition
            // 
            this.labelposition.AutoSize = true;
            this.labelposition.Location = new System.Drawing.Point(6, 472);
            this.labelposition.Name = "labelposition";
            this.labelposition.Size = new System.Drawing.Size(44, 13);
            this.labelposition.TabIndex = 19;
            this.labelposition.Text = "Position";
            // 
            // listBoxplacedIcons
            // 
            this.listBoxplacedIcons.FormatString = "True";
            this.listBoxplacedIcons.FormattingEnabled = true;
            this.listBoxplacedIcons.Location = new System.Drawing.Point(9, 33);
            this.listBoxplacedIcons.Name = "listBoxplacedIcons";
            this.listBoxplacedIcons.Size = new System.Drawing.Size(260, 394);
            this.listBoxplacedIcons.TabIndex = 18;
            this.listBoxplacedIcons.SelectedIndexChanged += new System.EventHandler(this.ListBoxplacedIcons_SelectedIndexChanged);
            // 
            // txtsearchbar
            // 
            this.txtsearchbar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtsearchbar.Location = new System.Drawing.Point(42, 3);
            this.txtsearchbar.Name = "txtsearchbar";
            this.txtsearchbar.Size = new System.Drawing.Size(227, 24);
            this.txtsearchbar.TabIndex = 17;
            this.txtsearchbar.Text = "";
            this.txtsearchbar.TextChanged += new System.EventHandler(this.txtsearchbar_TextChanged);
            // 
            // tabhoselines
            // 
            this.tabhoselines.Controls.Add(this.buttonsavehose);
            this.tabhoselines.Controls.Add(this.label3);
            this.tabhoselines.Controls.Add(this.label4);
            this.tabhoselines.Controls.Add(this.richTextBoxdistance);
            this.tabhoselines.Controls.Add(this.richTextBoxnamehose);
            this.tabhoselines.Controls.Add(this.listBoxhoselines);
            this.tabhoselines.Location = new System.Drawing.Point(4, 22);
            this.tabhoselines.Name = "tabhoselines";
            this.tabhoselines.Padding = new System.Windows.Forms.Padding(3);
            this.tabhoselines.Size = new System.Drawing.Size(275, 529);
            this.tabhoselines.TabIndex = 1;
            this.tabhoselines.Text = "Strecken";
            this.tabhoselines.UseVisualStyleBackColor = true;
            // 
            // buttonsavehose
            // 
            this.buttonsavehose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonsavehose.Location = new System.Drawing.Point(6, 500);
            this.buttonsavehose.Name = "buttonsavehose";
            this.buttonsavehose.Size = new System.Drawing.Size(259, 23);
            this.buttonsavehose.TabIndex = 12;
            this.buttonsavehose.Text = "Speichern";
            this.buttonsavehose.UseVisualStyleBackColor = true;
            this.buttonsavehose.Click += new System.EventHandler(this.Buttonsavehose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 479);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Länge";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 449);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Name";
            // 
            // richTextBoxdistance
            // 
            this.richTextBoxdistance.Location = new System.Drawing.Point(56, 479);
            this.richTextBoxdistance.Name = "richTextBoxdistance";
            this.richTextBoxdistance.ReadOnly = true;
            this.richTextBoxdistance.Size = new System.Drawing.Size(209, 20);
            this.richTextBoxdistance.TabIndex = 9;
            this.richTextBoxdistance.Text = "";
            // 
            // richTextBoxnamehose
            // 
            this.richTextBoxnamehose.Location = new System.Drawing.Point(56, 449);
            this.richTextBoxnamehose.Name = "richTextBoxnamehose";
            this.richTextBoxnamehose.Size = new System.Drawing.Size(209, 20);
            this.richTextBoxnamehose.TabIndex = 8;
            this.richTextBoxnamehose.Text = "";
            // 
            // listBoxhoselines
            // 
            this.listBoxhoselines.FormattingEnabled = true;
            this.listBoxhoselines.Location = new System.Drawing.Point(6, 6);
            this.listBoxhoselines.Name = "listBoxhoselines";
            this.listBoxhoselines.Size = new System.Drawing.Size(259, 433);
            this.listBoxhoselines.TabIndex = 7;
            this.listBoxhoselines.SelectedIndexChanged += new System.EventHandler(this.ListBoxhoselines_SelectedIndexChanged);
            // 
            // tabareas
            // 
            this.tabareas.Controls.Add(this.label7);
            this.tabareas.Controls.Add(this.richTextBoxaream);
            this.tabareas.Controls.Add(this.buttonsavearea);
            this.tabareas.Controls.Add(this.label5);
            this.tabareas.Controls.Add(this.label6);
            this.tabareas.Controls.Add(this.richTextBoxarea);
            this.tabareas.Controls.Add(this.richTextBoxnamearea);
            this.tabareas.Controls.Add(this.listBoxareas);
            this.tabareas.Location = new System.Drawing.Point(4, 22);
            this.tabareas.Name = "tabareas";
            this.tabareas.Size = new System.Drawing.Size(275, 529);
            this.tabareas.TabIndex = 2;
            this.tabareas.Text = "Gebiete";
            this.tabareas.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 475);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Fläche";
            // 
            // richTextBoxaream
            // 
            this.richTextBoxaream.Location = new System.Drawing.Point(47, 472);
            this.richTextBoxaream.Name = "richTextBoxaream";
            this.richTextBoxaream.ReadOnly = true;
            this.richTextBoxaream.Size = new System.Drawing.Size(225, 21);
            this.richTextBoxaream.TabIndex = 21;
            this.richTextBoxaream.Text = "";
            // 
            // buttonsavearea
            // 
            this.buttonsavearea.Location = new System.Drawing.Point(6, 503);
            this.buttonsavearea.Name = "buttonsavearea";
            this.buttonsavearea.Size = new System.Drawing.Size(266, 23);
            this.buttonsavearea.TabIndex = 20;
            this.buttonsavearea.Text = "Speichern";
            this.buttonsavearea.UseVisualStyleBackColor = true;
            this.buttonsavearea.Click += new System.EventHandler(this.Buttonsavearea_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 449);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Fläche";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 422);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Name";
            // 
            // richTextBoxarea
            // 
            this.richTextBoxarea.Location = new System.Drawing.Point(47, 446);
            this.richTextBoxarea.Name = "richTextBoxarea";
            this.richTextBoxarea.ReadOnly = true;
            this.richTextBoxarea.Size = new System.Drawing.Size(225, 20);
            this.richTextBoxarea.TabIndex = 17;
            this.richTextBoxarea.Text = "";
            // 
            // richTextBoxnamearea
            // 
            this.richTextBoxnamearea.Location = new System.Drawing.Point(47, 420);
            this.richTextBoxnamearea.Name = "richTextBoxnamearea";
            this.richTextBoxnamearea.Size = new System.Drawing.Size(225, 20);
            this.richTextBoxnamearea.TabIndex = 16;
            this.richTextBoxnamearea.Text = "";
            // 
            // listBoxareas
            // 
            this.listBoxareas.FormattingEnabled = true;
            this.listBoxareas.Location = new System.Drawing.Point(4, 6);
            this.listBoxareas.Name = "listBoxareas";
            this.listBoxareas.Size = new System.Drawing.Size(268, 407);
            this.listBoxareas.TabIndex = 15;
            this.listBoxareas.SelectedIndexChanged += new System.EventHandler(this.ListBoxareas_SelectedIndexChanged);
            // 
            // tabconfigs
            // 
            this.tabconfigs.Controls.Add(this.checkBoxaltimages);
            this.tabconfigs.Controls.Add(this.checkedListBoxlayers);
            this.tabconfigs.Location = new System.Drawing.Point(4, 22);
            this.tabconfigs.Name = "tabconfigs";
            this.tabconfigs.Size = new System.Drawing.Size(275, 529);
            this.tabconfigs.TabIndex = 3;
            this.tabconfigs.Text = "Einstellungen";
            this.tabconfigs.UseVisualStyleBackColor = true;
            // 
            // checkBoxaltimages
            // 
            this.checkBoxaltimages.AutoSize = true;
            this.checkBoxaltimages.Location = new System.Drawing.Point(4, 122);
            this.checkBoxaltimages.Name = "checkBoxaltimages";
            this.checkBoxaltimages.Size = new System.Drawing.Size(171, 17);
            this.checkBoxaltimages.TabIndex = 2;
            this.checkBoxaltimages.Text = "Taktische Zeichen verwenden";
            this.checkBoxaltimages.UseVisualStyleBackColor = true;
            this.checkBoxaltimages.CheckedChanged += new System.EventHandler(this.CheckBoxaltimages_CheckedChanged);
            // 
            // checkedListBoxlayers
            // 
            this.checkedListBoxlayers.FormattingEnabled = true;
            this.checkedListBoxlayers.Items.AddRange(new object[] {
            "Fahrzeuge",
            "Orte",
            "Strecken",
            "Gefahren",
            "Gebiete",
            "Personen",
            "Einheiten"});
            this.checkedListBoxlayers.Location = new System.Drawing.Point(3, 6);
            this.checkedListBoxlayers.Name = "checkedListBoxlayers";
            this.checkedListBoxlayers.Size = new System.Drawing.Size(266, 109);
            this.checkedListBoxlayers.TabIndex = 1;
            this.checkedListBoxlayers.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.CheckedListBoxlayers_ItemCheck);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1452, 611);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitterright);
            this.Controls.Add(this.panelmiddel);
            this.Controls.Add(this.splitterleft);
            this.Controls.Add(this.panelleft);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelmiddel.ResumeLayout(false);
            this.panelmiddel.PerformLayout();
            this.panelleft.ResumeLayout(false);
            this.panelleft.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabplacedicons.ResumeLayout(false);
            this.tabplacedicons.PerformLayout();
            this.tabhoselines.ResumeLayout(false);
            this.tabhoselines.PerformLayout();
            this.tabareas.ResumeLayout(false);
            this.tabareas.PerformLayout();
            this.tabconfigs.ResumeLayout(false);
            this.tabconfigs.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.Splitter splitterleft;
        private System.Windows.Forms.Panel panelmiddel;
        private System.Windows.Forms.Button buttonload;
        private System.Windows.Forms.Button buttonsave;
        private System.Windows.Forms.Button buttonnew;
        private System.Windows.Forms.TextBox textBoxwarning;
        private System.Windows.Forms.Button buttonreloadmap;
        private System.Windows.Forms.ComboBox comboBoxmap;
        private System.Windows.Forms.TabControl taballg;
        private System.Windows.Forms.Panel panelleft;
        private System.Windows.Forms.Button buttonleftturn;
        private System.Windows.Forms.Button buttonnavigate;
        private System.Windows.Forms.RichTextBox richTextBoxplace;
        private System.Windows.Forms.TextBox textBoxradius;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonrightturn;
        private System.Windows.Forms.Button buttonnorth;
        private GMap.NET.WindowsForms.GMapControl map;
        private System.Windows.Forms.Splitter splitterright;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabplacedicons;
        private System.Windows.Forms.TabPage tabhoselines;
        private System.Windows.Forms.Button buttonjump;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox textBoxname;
        private System.Windows.Forms.Button buttonmove;
        private System.Windows.Forms.Button buttonsetchanges;
        private System.Windows.Forms.RichTextBox richTextBoxPos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelposition;
        private System.Windows.Forms.ListBox listBoxplacedIcons;
        private System.Windows.Forms.RichTextBox txtsearchbar;
        private System.Windows.Forms.TabPage tabareas;
        private System.Windows.Forms.TabPage tabconfigs;
        private System.Windows.Forms.Button buttonsavehose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBoxdistance;
        private System.Windows.Forms.RichTextBox richTextBoxnamehose;
        private System.Windows.Forms.ListBox listBoxhoselines;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox richTextBoxaream;
        private System.Windows.Forms.Button buttonsavearea;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richTextBoxarea;
        private System.Windows.Forms.RichTextBox richTextBoxnamearea;
        private System.Windows.Forms.ListBox listBoxareas;
        private System.Windows.Forms.CheckedListBox checkedListBoxlayers;
        private System.Windows.Forms.CheckBox checkBoxaltimages;
    }
}