using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Elektronische_Lagekarte
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region public stuff
        public List<GMarkerGoogle> Icons = new List<GMarkerGoogle>();
        public List<GMapRoute> Strecken = new List<GMapRoute>();
        public List<GMapPolygon> Gebiete = new List<GMapPolygon>();
        public List<PointLatLng> pointsline = new List<PointLatLng>();
        public List<PointLatLng> pointsul = new List<PointLatLng>();
        public List<PointLatLng> pointsspul = new List<PointLatLng>();
        public List<PointLatLng> pointsareafeuer = new List<PointLatLng>();
        public List<PointLatLng> pointswasser = new List<PointLatLng>();
        public List<PointLatLng> pointsstrom = new List<PointLatLng>();
        public List<PointLatLng> pointskonta = new List<PointLatLng>();
        public GMapOverlay overlayjunk = new GMapOverlay();
        public GMapOverlay overlayfrz = new GMapOverlay("Fahrzeuge");
        public GMapOverlay overlaylines = new GMapOverlay("Strecken");
        public GMapOverlay overlayplaces = new GMapOverlay("Orte");
        public GMapOverlay overlaydanger = new GMapOverlay("Gefahren");
        public GMapOverlay overlayareas = new GMapOverlay("Gebiete");
        public GMapOverlay overlayunits = new GMapOverlay("Einheiten");
        public GMapOverlay overlaypersons = new GMapOverlay("Personen");
        public List<GMapOverlay> overlays = new List<GMapOverlay>();
        private List<Item.Items> items = new List<Item.Items>();
        public ListBox listBox = new ListBox();
        public string selectedItem;
        public PointLatLng befor, after;
        public bool imagekind = true;
        public int ID = 1;
        public bool move = false;
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadZeichen();
            Setupmap();
        }
        #region Linke Seite
        public void LoadZeichen()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            List<string> Category = new List<string>();
            List<string> type = new List<string>();
            DirectoryInfo directoryInfo = new DirectoryInfo(workingDirectory + @"\Taktische Zeichen");

            taballg.TabPages.Clear();
            foreach (DirectoryInfo f in directoryInfo.GetDirectories())
            {
                Category.Add(f.Name);
            }
            foreach (string c in Category)
            {
                TabPage tabpage = new TabPage(c);
                taballg.TabPages.Add(tabpage);
                TabControl tabcontrol = new TabControl
                {
                    Name = "tab" + c,
                    Dock = DockStyle.Fill,
                    Multiline = true,
                    HotTrack = false,
                    Appearance = TabAppearance.FlatButtons
                };
                tabpage.Controls.Add(tabcontrol);
                directoryInfo = new DirectoryInfo(workingDirectory + @"\Taktische Zeichen" + @"\" + c);
                foreach (DirectoryInfo f in directoryInfo.GetDirectories())
                {
                    type.Add(f.Name);
                }
                int i = 0;
                foreach (string t in type)
                {
                    TabPage tabpage1 = new TabPage(t)
                    {
                        Name = "tab" + c + t
                    };
                    tabcontrol.TabPages.Add(tabpage1);
                    TabControl tabControl1 = new TabControl();
                    ListBox listbox = new ListBox
                    {
                        Name = "box" + c + t,
                        Tag = c,
                        Dock = DockStyle.Fill,
                        Sorted = true,
                        ScrollAlwaysVisible = true
                    };
                    tabpage1.Controls.Add(listbox);
                    directoryInfo = new DirectoryInfo(workingDirectory + @"\Taktische Zeichen" + @"\" + c + @"\" + t);
                    DirectoryInfo directoryInfoalt = new DirectoryInfo(workingDirectory + @"\Alternative Zeichen" + @"\" + c + @"\" + t);
                    foreach (FileInfo f in directoryInfo.GetFiles())
                    {
                        Item.Items item = new Item.Items(f.ToString().Split('.')[0], directoryInfo.ToString() + @"\" + f, directoryInfoalt.ToString() + @"\" + f, i);
                        items.Add(item);
                        listbox.Items.Add(f.ToString().Split('.')[0]);
                        listbox.SelectedIndexChanged += new EventHandler(Listbox_SelectedIndexChanged);
                    }
                    i++;
                }
                type.Clear();
            }
        }
        public void Listbox_SelectedIndexChanged(object sender, EventArgs e)
        {

            listBox = ((ListBox)sender);
            if (listBox.SelectedItem != null)
            {
                if (listBox.SelectedItem.ToString() == "Kreis")
                {
                    textBoxradius.Select();
                }
                selectedItem = listBox.SelectedItem.ToString();
            }
            else
            {
                selectedItem = "";
            }

        }
        private void ComboBoxmap_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxmap.SelectedIndex)
            {
                case 0:
                    map.MapProvider = GMapProviders.OpenCycleLandscapeMap;
                    break;
                case 1:
                    map.MapProvider = GMapProviders.GoogleHybridMap;
                    break;
                case 2:
                    map.MapProvider = GMapProviders.GoogleMap;
                    break;
                case 3:
                    map.MapProvider = GMapProviders.OpenStreetMap;
                    break;
            }
            map.ReloadMap();
        }
        private void Buttonnavigate_Click(object sender, EventArgs e)
        {
            if (richTextBoxplace.Text != "")
            {
                string text = richTextBoxplace.Text;
                textBoxwarning.Text = "";
                string url = @"https://www.google.de/maps/search/" + text.Replace(" ", "%20");
                GetUrlResponsev(url);

            }
            else
            {
                textBoxwarning.Text = "Keine Adresse Eingetragen!";
            }
        }
        private void GetUrlResponsev(string url)
        {
            string content = null;
            PointLatLng point = new PointLatLng(0, 0);
            int i = 0;
            string[] coords = new string[2];
            WebRequest webRequest = WebRequest.Create(url);
            WebResponse webResponse = webRequest.GetResponse();
            StreamReader sr = new StreamReader(webResponse.GetResponseStream(), Encoding.ASCII);
            StringBuilder contentBuilder = new StringBuilder();
            while (-1 != sr.Peek())
            {
                string line = sr.ReadLine();
                if (line.Contains("place"))
                {
                    contentBuilder.Append(line);
                    contentBuilder.Append("\r\n");
                }
            }
            content = contentBuilder.ToString();
            foreach (string s in content.Split('/'))
            {
                if (s.Contains('.') && !s.Contains(".com") && !s.Contains("https") && s.Contains("null") && !s.Contains("photo"))
                {
                    foreach (string a in s.Split('\\'))
                    {
                        if (a.Contains('.') && a.Contains('[') && !a.Contains(';') && !a.Contains('"'))
                        {
                            foreach (string b in a.Split(','))
                            {
                                if (b.Length > 5 && !b.Contains("u") && !b.Contains("b") && !b.Contains("k") && i != 2)
                                {
                                    coords[i] = b.Replace("]", "");
                                    Console.WriteLine(coords[i]);
                                    i++;
                                }
                                if (i == 2 || i > 2)
                                {
                                    var d1 = double.Parse(coords[1]);
                                    var d2 = double.Parse(coords[0]);
                                    double pow1;
                                    double pow2;
                                    if (d1.ToString().Contains("E"))
                                    {
                                        pow1 = Math.Pow(10, double.Parse(d1.ToString().Split('E')[1]) - 1);
                                    }
                                    else
                                    {
                                        pow1 = Math.Pow(10, d1.ToString().Length - 2);
                                    }
                                    var cord1 = d1 / pow1;
                                    if (d2.ToString().Contains("E"))
                                    {
                                        pow2 = Math.Pow(10, double.Parse(d2.ToString().Split('E')[1]) - 1);
                                    }
                                    else
                                    {
                                        pow2 = Math.Pow(10, d2.ToString().Length - 2);
                                    }
                                    var cord2 = d2 / pow2;
                                    if (cord1 > cord2)
                                    {
                                        point = new PointLatLng(cord1, cord2);
                                    }
                                    else
                                    {
                                        point = new PointLatLng(cord2, cord1);
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            if (point == new PointLatLng(0, 0))
            {
                textBoxwarning.Text = "Addresse nicht gefunden. Bitte genauer eingeben.";

            }
            else
            {
                map.Position = point;
                map.Zoom = 16;
                richTextBoxplace.Text = "";
            }
        }
        private void richTextBoxplace_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
            else
            {
                e.SuppressKeyPress = false;
            }
        }
        private void richTextBoxplace_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (richTextBoxplace.Text != "")
                {
                    textBoxwarning.Text = "";
                    string text = richTextBoxplace.Text;
                    string url = @"https://www.google.de/maps/search/" + text.Replace(" ", "%20");
                    GetUrlResponsev(url);
                }
                else
                {
                    textBoxwarning.Text = "Keine Adresse Eingetragen!";
                }
            }
        }
        private void Buttonleftturn_Click(object sender, EventArgs e)
        {
            map.Bearing += 10;
        }
        private void Buttonrightturn_Click(object sender, EventArgs e)
        {
            map.Bearing -= 10;
        }
        private void Buttonnorth_Click(object sender, EventArgs e)
        {
            map.Bearing = 0;
        }
        #endregion
        #region Mitte
        private void Buttonnew_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Wollen Sie die Karte Zurücksetzen?", "", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                foreach (GMapOverlay o in map.Overlays)
                {
                    o.Clear();
                }
                Icons.Clear();
                Strecken.Clear();
                Gebiete.Clear();
                LoadData();
                map.ReloadMap();
                ID = 1;
            }
        }
        #region Map
        public void Setupmap()
        {
            map.DragButton = MouseButtons.Left;
            map.MapProvider = GMapProviders.GoogleHybridMap;
            map.Position = new PointLatLng(48.3473694, 12.130470599999999);
            map.ShowCenter = false;
            map.IgnoreMarkerOnMouseWheel = true;
            map.MaxZoom = 20;
            map.MinZoom = 5;
            map.Zoom = 10;
            map.Overlays.Add(overlayjunk);
            comboBoxmap.SelectedIndex = 1;
            checkedListBoxlayers.SetItemChecked(0, true);
            checkedListBoxlayers.SetItemChecked(1, true);
            checkedListBoxlayers.SetItemChecked(2, true);
            checkedListBoxlayers.SetItemChecked(3, true);
            checkedListBoxlayers.SetItemChecked(4, true);
            checkedListBoxlayers.SetItemChecked(5, true);
            checkedListBoxlayers.SetItemChecked(6, true);
            overlays.Add(overlayfrz);
            overlays.Add(overlayareas);
            overlays.Add(overlaylines);
            overlays.Add(overlaypersons);
            overlays.Add(overlayunits);
            overlays.Add(overlaydanger);
            overlays.Add(overlayplaces);
            checkBoxaltimages.Checked = true;
            map.Overlays.Add(overlayjunk);
        }
        private void Buttonreloadmap_Click(object sender, EventArgs e)
        {
            map.ReloadMap();
        }
        private void Map_MouseDown(object sender, MouseEventArgs e)
        {
            befor = map.Position;
        }
        private void Map_MouseUp(object sender, MouseEventArgs e)
        {
            double lat = map.FromLocalToLatLng(e.X, e.Y).Lat;
            double lng = map.FromLocalToLatLng(e.X, e.Y).Lng;
            PointLatLng point = new PointLatLng(lat, lng);
            after = map.Position;
            if (befor == after)
            {
                if (e.Button == MouseButtons.Right && move == true)
                {
                    move = false;

                }
                if (move)
                {
                    
                    foreach (GMarkerGoogle g in Icons)
                    {
                        if (listBoxplacedIcons.SelectedItem != null)
                        {
                            if (listBoxplacedIcons.SelectedItem.ToString() == g.Tag.ToString() + ": " + g.ToolTipText.ToString())
                            {
                                foreach (GMapOverlay o in overlays)
                                {
                                    foreach (GMapMarker gMapMarker in o.Markers)
                                    {
                                        if (g == gMapMarker)
                                        {
                                            g.Position = point;
                                            gMapMarker.Position = point;
                                            move = false;
                                            break;
                                        }
                                    }
                                    if (!move)
                                    {
                                        break;
                                    }
                                }
                                if (!move)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (!map.IsMouseOverMarker)
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            if (selectedItem != "" && selectedItem != null)
                            {
                                switch (selectedItem)
                                {
                                    case "Schlauchstrecke":
                                        placeLinepoints(point, 0);
                                        break;
                                    case "Umleitung":
                                        placeLinepoints(point, 1);
                                        break;
                                    case "Straßensperre(mit UL)":
                                        placeLinepoints(point, 2);
                                        break;
                                    case "Flächenbrand":
                                        placeAreapoints(point, 0);
                                        break;
                                    case "Kontamination":
                                        placeAreapoints(point, 1);
                                        break;
                                    case "Kreis":
                                        placeCircle(point);
                                        break;
                                    case "Stromausfall":
                                        placeAreapoints(point, 2);
                                        break;
                                    case "Überschwemmung":
                                        placeAreapoints(point, 3);
                                        break;
                                    default:
                                        placeMarker(point);
                                        break;
                                }
                            }
                        }
                    }
                }
            }
        }
        private void Map_OnMarkerClick(GMapMarker sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (sender.Overlay == overlayjunk)
                    {
                        switch (sender.ToolTipText)
                        {
                            case "Schlauchstrecke":
                                createLine(0);
                                break;
                            case "Umleitung":
                                createLine(1);
                                break;
                            case "Straßensperre(mit UL)":
                                createLine(2);
                                break;
                            case "Flächenbrand":
                                createArea(0);
                                break;
                            case "Kontamination":
                                createArea(1);
                                break;
                            case "Stromausfall":
                                createArea(2);
                                break;
                            case "Überschwemmung":
                                createArea(3);
                                break;
                            default:
                                break;
                        }
                    }
                    else if (sender.Overlay != overlayareas)
                    {
                        tabControl.SelectTab(tabplacedicons);
                        listBoxplacedIcons.SelectedItem = sender.Tag + ": " + sender.ToolTipText;
                    }
                    break;
                case MouseButtons.Right:
                    bool removed = false;
                    foreach (GMapOverlay o in overlays)
                    {
                        if (o == overlayfrz || o == overlaydanger || o == overlayplaces || o == overlayunits || o == overlaypersons)
                        {
                            foreach (GMarkerGoogle m in o.Markers)
                            {
                                if (m == sender)
                                {
                                    Icons.Remove(m);
                                    o.Markers.Remove(m);
                                    LoadData(listBoxplacedIcons, 0);
                                    map.ReloadMap();
                                    removed = true;
                                    break;
                                }
                            }
                            if (removed)
                            {
                                break;
                            }
                        }
                        else if (o == overlayareas)
                        {
                            GMarkerGoogle temp = new GMarkerGoogle(new PointLatLng(), new Bitmap(1, 1));
                            foreach (GMarkerGoogle m in o.Markers)
                            {
                                if (m == sender)
                                {
                                    temp = m;
                                    break;
                                }
                            }
                            if (temp.Type == GMarkerGoogleType.yellow_pushpin)
                            {
                                foreach (GMapMarker m in o.Markers)
                                {
                                    if (m.Position == sender.Position)
                                    {
                                        foreach (GMapPolygon p in o.Polygons)
                                        {
                                            if (p.ErrorMessage == m.Position.Lat.ToString() + m.Position.Lng.ToString())
                                            {
                                                o.Polygons.Remove(p);
                                                o.Markers.Remove(m);
                                                removed = true;
                                                break;
                                            }
                                        }
                                        if (removed)
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                foreach (GMapMarker m in overlayareas.Markers)
                                {
                                    foreach (GMapPolygon p in overlayareas.Polygons)
                                    {
                                        if (p.Tag.ToString() == sender.Tag.ToString())
                                        {
                                            overlayareas.Markers.Remove(sender);
                                            overlayareas.Polygons.Remove(p);
                                            Gebiete.Remove(p);
                                            LoadData(listBoxareas, 1);
                                            map.ReloadMap();
                                            removed = true;
                                            break;
                                        }
                                    }
                                    if (removed)
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                        }
                    }
                    break;
            }
        }
        private void Map_OnRouteClick(GMapRoute sender, MouseEventArgs e)
        {
            List<GMarkerGoogle> temp = new List<GMarkerGoogle>();
            switch (e.Button)
            {
                case MouseButtons.Right:
                    foreach (GMapRoute r in overlaylines.Routes)
                    {
                        if (r == sender)
                        {
                            foreach (PointLatLng p in r.Points)
                            {
                                foreach (GMarkerGoogle g in overlaylines.Markers)
                                {
                                    if (g.Position == p)
                                    {
                                        temp.Add(g);
                                    }
                                }
                            }
                            overlaylines.Routes.Remove(r);
                            Strecken.Remove(sender);
                            LoadData(listBoxhoselines, 2);
                            foreach (GMarkerGoogle g in temp)
                            {
                                overlaylines.Markers.Remove(g);
                            }
                            break;
                        }
                    }
                    break;
                case MouseButtons.Left:
                    tabControl.SelectTab(tabhoselines);
                    listBoxhoselines.SelectedItem = sender.Tag;
                    break;
            }
        }
        private void Map_OnPolygonClick(GMapPolygon sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    tabControl.SelectTab(tabareas);
                    listBoxareas.SelectedItem = sender.Name + ": " + sender.Tag;
                    break;
                case MouseButtons.Right:
                    break;
            }
        }      
        #endregion
        #region SaveLoad
        #endregion
        #endregion
        #region Rechte Seite
        public void LoadData()
        {
            LoadData(listBoxplacedIcons, 0);
            LoadData(listBoxareas, 1);
            LoadData(listBoxhoselines, 2);
        }
        public void LoadData(string text)
        {
            if (text.Trim().Length > 0)
            {
                listBoxplacedIcons.BeginUpdate();
                listBoxplacedIcons.Items.Clear();

                foreach (var item in Icons)
                {
                    if ((item.Tag + ": " + item.ToolTipText).ToUpper().Contains(text.ToUpper()))
                    {
                        listBoxplacedIcons.Items.Add(item.Tag + ": " + item.ToolTipText);
                    }
                }
                listBoxplacedIcons.EndUpdate();
                label8.Text = listBoxplacedIcons.Items.Count.ToString();
            }
            else
            {
                LoadData(listBoxplacedIcons, 0);
            }
        }
        public void LoadData(ListBox listbox, int i)
        {
            switch (i)
            {
                case 0:
                    listbox.BeginUpdate();
                    listbox.Items.Clear();
                    foreach (var item in Icons)
                    {
                        listbox.Items.Add(item.Tag + ": " + item.ToolTipText);
                    }
                    listbox.EndUpdate();
                    label8.Text = listBoxplacedIcons.Items.Count.ToString();
                    break;
                case 1:
                    listbox.BeginUpdate();
                    listbox.Items.Clear();
                    foreach (var item in Gebiete)
                    {
                        listbox.Items.Add(item.Name + ": " + item.Tag);
                    }
                    listbox.EndUpdate();
                    break;
                case 2:
                    listbox.BeginUpdate();
                    listbox.Items.Clear();
                    foreach (var item in Strecken)
                    {
                        item.Tag = item.Name + "," + item.Distance + "KM";
                        listbox.Items.Add(item.Tag);
                    }
                    listbox.EndUpdate();
                    break;
            }
        }
        private void CheckBoxaltimages_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxaltimages.Checked)
            {
                imagekind = true;
            }
            else
            {
                imagekind = false;
            }
        }
        private void CheckedListBoxlayers_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            switch (e.Index)
            {
                case 0:
                    if (e.NewValue == CheckState.Unchecked)
                    {
                        map.Overlays.Remove(overlayfrz);
                    }
                    else
                    {
                        map.Overlays.Add(overlayfrz);
                    }
                    break;
                case 1:
                    if (e.NewValue == CheckState.Unchecked)
                    {
                        map.Overlays.Remove(overlayplaces);
                    }
                    else
                    {
                        map.Overlays.Add(overlayplaces);
                    }
                    break;
                case 2:
                    if (e.NewValue == CheckState.Unchecked)
                    {
                        map.Overlays.Remove(overlaylines);
                    }
                    else
                    {
                        map.Overlays.Add(overlaylines);
                    }
                    break;
                case 5:
                    if (e.NewValue == CheckState.Unchecked)
                    {
                        map.Overlays.Remove(overlaypersons);
                    }
                    else
                    {
                        map.Overlays.Add(overlaypersons);
                    }
                    break;
                case 4:
                    if (e.NewValue == CheckState.Unchecked)
                    {
                        map.Overlays.Remove(overlayareas);
                    }
                    else
                    {
                        map.Overlays.Add(overlayareas);
                    }
                    break;
                case 6:
                    if (e.NewValue == CheckState.Unchecked)
                    {
                        map.Overlays.Remove(overlayunits);
                    }
                    else
                    {
                        map.Overlays.Add(overlayunits);
                    }
                    break;
                case 3:
                    if (e.NewValue == CheckState.Unchecked)
                    {
                        map.Overlays.Remove(overlaydanger);
                    }
                    else
                    {
                        map.Overlays.Add(overlaydanger);
                    }
                    break;
            }
            map.ReloadMap();
        }
        private void txtsearchbar_TextChanged(object sender, EventArgs e)
        {
            RichTextBox text = ((RichTextBox)sender);
            LoadData(text.Text);
        }
        private void ListBoxplacedIcons_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GMarkerGoogle g in Icons)
            {
                if (listBoxplacedIcons.SelectedItem.ToString() == g.Tag.ToString() + ": " + g.ToolTipText.ToString())
                {
                    textBoxname.Text = g.ToolTipText.ToString();
                    richTextBoxPos.Text = g.Position.Lat.ToString() + " " + g.Position.Lng.ToString();
                }
            }
        }
        private void ListBoxhoselines_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GMapRoute r in Strecken)
            {
                if (listBoxhoselines.SelectedItem.ToString() == r.Tag.ToString())
                {
                    richTextBoxnamehose.Text = r.Name;
                    richTextBoxdistance.Text = r.Distance.ToString() + " Km";
                }
            }
        }
        private void ListBoxareas_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GMapPolygon p in Gebiete)
            {
                if (listBoxareas.SelectedItem.ToString() == p.Name + ": " + p.Tag.ToString())
                {
                    richTextBoxnamearea.Text = p.Name;
                    double m = double.Parse(p.ErrorMessage) * 1000000;
                    richTextBoxarea.Text = p.ErrorMessage + " KM²";
                    richTextBoxaream.Text = m.ToString() + " M²";
                }
            }
        }
        private void Buttonsavearea_Click(object sender, EventArgs e)
        {
            string text = richTextBoxnamearea.Text;
            bool done = false;
            if (text.Length > 0)
            {
                foreach (var i in Gebiete)
                {
                    if (listBoxareas.SelectedItem.ToString() == i.Name + ": " + i.Tag.ToString())
                    {
                        foreach (var m in overlayareas.Polygons)
                        {
                            if (m == i)
                            {
                                m.Name = text;
                                i.Name = text;
                                done = true;
                                break;
                            }
                        }
                        if (done)
                        {
                            done = false;
                            break;
                        }
                    }
                }
                LoadData();
            }
        }
        private void Buttonsetchanges_Click(object sender, EventArgs e)
        {
            string text = textBoxname.Text;
            bool done = false;
            if (text.Length > 0)
            {
                foreach (var i in Icons)
                {
                    if (listBoxplacedIcons.SelectedItem.ToString() == i.Tag.ToString() + ": " + i.ToolTipText.ToString())
                    {
                        foreach (var o in map.Overlays)
                        {
                            foreach (var m in o.Markers)
                            {
                                if (m == i)
                                {
                                    m.ToolTipText = text;
                                    done = true;
                                    break;
                                }
                            }
                            if (done)
                            {
                                done = false;
                                break;
                            }
                        }
                        i.ToolTipText = text;
                        done = true;
                    }
                    if (done)
                    {
                        LoadData();
                        break;
                    }
                }
            }
        }
        private void Buttonsavehose_Click(object sender, EventArgs e)
        {
            string text = richTextBoxnamehose.Text;
            bool done = false;
            if (text.Length > 0)
            {
                foreach (var i in Strecken)
                {
                    if (listBoxhoselines.SelectedItem.ToString() == i.Tag.ToString())
                    {
                        foreach (var m in overlaylines.Routes)
                        {
                            if (m == i)
                            {
                                m.Name = text;
                                m.Tag = text + "," + m.Distance.ToString();
                                i.Tag = m.Tag;
                                i.Name = m.Name;
                                done = true;
                                break;
                            }
                        }
                        if (done)
                        {
                            done = false;
                            break;
                        }
                    }
                }
                LoadData();
            }
        }
        private void Buttonjump_Click(object sender, EventArgs e)
        {
            switch (tabControl.SelectedTab.Name)
            {
                case "tabhoselines":
                    if (listBoxhoselines.SelectedItem != null)
                    {
                        foreach (GMapRoute r in Strecken)
                        {
                            if (listBoxhoselines.SelectedItem.ToString() == r.Tag.ToString())
                            {
                                map.Position = r.Points[0];
                                break;
                            }
                        }
                    }
                    break;
                case "tabplacedicons":
                    if (listBoxplacedIcons.SelectedItem != null)
                    {
                        foreach (GMarkerGoogle g in Icons)
                        {
                            if (listBoxplacedIcons.SelectedItem.ToString() == g.Tag.ToString() + ": " + g.ToolTipText.ToString())
                            {
                                map.Position = g.Position;
                                break;
                            }
                        }
                    }
                    break;
                case "tabareas":
                    if (listBoxareas.SelectedItem != null)
                    {
                        foreach (GMapPolygon p in Gebiete)
                        {
                            if (listBoxareas.SelectedItem.ToString() == p.Name + ": " + p.Tag.ToString())
                            {
                                map.Position = p.Points[0];
                                break;
                            }
                        }
                    }
                    break;
            }
        }
        private void Buttonmove_Click(object sender, EventArgs e)
        {           
            move = true;
        }
        #endregion
        #region Markers Strecken Gebiete
        #region Icons
        private void placeMarker(PointLatLng pointLatLng)
        {
            Bitmap bitmap = new Bitmap(1, 1);
            Item.Items item = new Item.Items();
            foreach (Item.Items i in items)
            {
                if (selectedItem == i.Name)
                {
                    item = i;
                    break;
                }
            }
            switch (imagekind)
            {
                case true:
                    bitmap = new Bitmap(item.imagepath.ToString());
                    break;
                case false:
                    bitmap = new Bitmap(item.altpath.ToString());
                    break;
            }
            GMarkerGoogle marker = new GMarkerGoogle(pointLatLng, bitmap);
            marker.Tag = ID;
            marker.ToolTipText = selectedItem;
            switch (item.Kategorie)
            {
                case 0:
                    overlayfrz.Markers.Add(marker);
                    break;
                case 1:
                    overlayplaces.Markers.Add(marker);
                    break;
                case 2:
                    overlaypersons.Markers.Add(marker);
                    break;
                case 3:
                    overlayunits.Markers.Add(marker);
                    break;
                case 4:
                    overlaydanger.Markers.Add(marker);
                    break;
            }
            Icons.Add(marker);
            ID++;
            tabControl.SelectTab(tabplacedicons);
            LoadData(listBoxplacedIcons, 0);
            listBox.SelectedItem = null;
        }
        #endregion
        #region Strecken
        private void placeLinepoints(PointLatLng pointLatLng, int type)
        {
            Bitmap bitmap = new Bitmap(1, 1);
            foreach (Item.Items i in items)
            {
                if (i.Name == selectedItem && selectedItem != "Schlauchstrecke")
                {
                    switch (imagekind)
                    {
                        case true:
                            bitmap = new Bitmap(i.imagepath.ToString());
                            break;
                        case false:
                            bitmap = new Bitmap(i.altpath.ToString());
                            break;
                    }
                    break;
                }
            }
            GMarkerGoogle gMarkerGoogle = new GMarkerGoogle(pointLatLng, GMarkerGoogleType.red);
            switch (type)
            {
                case 0:
                    gMarkerGoogle = new GMarkerGoogle(pointLatLng, GMarkerGoogleType.red_pushpin);
                    gMarkerGoogle.ToolTipText = selectedItem;
                    pointsline.Add(pointLatLng);
                    break;
                case 1:
                    gMarkerGoogle = new GMarkerGoogle(pointLatLng, bitmap);
                    gMarkerGoogle.ToolTipText = selectedItem;
                    pointsspul.Add(pointLatLng);
                    break;
                case 2:
                    gMarkerGoogle = new GMarkerGoogle(pointLatLng, bitmap);
                    gMarkerGoogle.ToolTipText = selectedItem;
                    pointsul.Add(pointLatLng);
                    break;
            }
            overlayjunk.Markers.Add(gMarkerGoogle);
        }
        private void createLine(int type)
        {
            List<GMarkerGoogle> temp = new List<GMarkerGoogle>();
            string name = "";
            Color color = new Color();
            GMapRoute gMapRoute = new GMapRoute(name);
            switch (type)
            {

                case 0:
                    if (pointsline.Count > 1)
                    {
                        name = "Schlauchstrecke";
                        color = Color.FromName("Blue");
                        gMapRoute = new GMapRoute(pointsline, name)
                        {
                            Stroke = new Pen(color, 3),
                            IsHitTestVisible = true
                        };
                        foreach (GMarkerGoogle g in overlayjunk.Markers)
                        {
                            if (g.ToolTipText == name)
                            {

                                temp.Add(g);
                            }
                        }
                        pointsline.Clear();
                        map.UpdateRouteLocalPosition(gMapRoute);
                        listBox.SelectedItem = null;
                        Strecken.Add(gMapRoute);
                        overlaylines.Routes.Add(gMapRoute);
                    }

                    break;
                case 1:
                    if (pointsspul.Count > 1)
                    {
                        name = "Umleitung";
                        color = Color.FromName("Yellow");
                        gMapRoute = new GMapRoute(pointsspul, name)
                        {
                            Stroke = new Pen(color, 3),
                            IsHitTestVisible = true
                        };
                        foreach (GMarkerGoogle g in overlayjunk.Markers)
                        {
                            if (g.ToolTipText == name)
                            {
                                overlaylines.Markers.Add(g);
                                temp.Add(g);
                            }
                        }
                        pointsspul.Clear();
                        map.UpdateRouteLocalPosition(gMapRoute);
                        listBox.SelectedItem = null;
                        Strecken.Add(gMapRoute);
                        overlaylines.Routes.Add(gMapRoute);
                    }
                    break;
                case 2:
                    if (pointsul.Count > 1)
                    {
                        name = "Straßensperre(mit UL)";
                        color = Color.FromName("Yellow");
                        gMapRoute = new GMapRoute(pointsul, name)
                        {
                            Stroke = new Pen(color, 3),
                            IsHitTestVisible = true
                        };
                        foreach (GMarkerGoogle g in overlayjunk.Markers)
                        {
                            if (g.ToolTipText == name)
                            {
                                overlaylines.Markers.Add(g);
                                temp.Add(g);
                            }

                        }
                        pointsul.Clear();
                        map.UpdateRouteLocalPosition(gMapRoute);
                        listBox.SelectedItem = null;
                        Strecken.Add(gMapRoute);
                        overlaylines.Routes.Add(gMapRoute);
                    }

                    break;

            }
            foreach (GMarkerGoogle g in temp)
            {
                overlayjunk.Markers.Remove(g);
            }

            tabControl.SelectTab(tabhoselines);
            LoadData(listBoxhoselines, 2);
        }
        #endregion
        #region Areas
        #region Gebiete
        private void placeAreapoints(PointLatLng pointLatLng, int type)
        {
            switch (type)
            {
                case 0:
                    pointsareafeuer.Add(pointLatLng);
                    break;
                case 1:
                    pointskonta.Add(pointLatLng);
                    break;
                case 2:
                    pointsstrom.Add(pointLatLng);
                    break;
                case 3:
                    pointswasser.Add(pointLatLng);
                    break;
            }
            GMarkerGoogle gMarkerGoogle = new GMarkerGoogle(pointLatLng, GMarkerGoogleType.red_pushpin);
            gMarkerGoogle.ToolTipText = selectedItem;
            overlayjunk.Markers.Add(gMarkerGoogle);
        }
        private void createArea(int type)
        {
            listBox.SelectedItem = null;
            string name = "";
            bool falsch = false;
            Bitmap bitmap = new Bitmap(1, 1);
            SolidBrush solidBrush = new SolidBrush(Color.White);
            GMapPolygon gMapPolygon = new GMapPolygon(new List<PointLatLng>(), "");
            List<PointLatLng> points = new List<PointLatLng>();
            double area;
            switch (type)
            {
                case 0:
                    name = "Flächenbrand";
                    points = pointsareafeuer;
                    if (points.Count < 3)
                    {
                        falsch = true;
                        break;
                    }
                    solidBrush = new SolidBrush(Color.FromArgb(50, new Pen(Color.Red).Color));
                    gMapPolygon = new GMapPolygon(points, name)
                    {
                        Fill = solidBrush,
                        IsHitTestVisible = true,
                        Stroke = new Pen(Color.Red)
                    };
                    break;
                case 1:
                    name = "Kontamination";
                    points = pointskonta;
                    if (points.Count < 3)
                    {
                        falsch = true;
                        break;
                    }
                    solidBrush = new SolidBrush(Color.FromArgb(50, new Pen(Color.Violet).Color));
                    gMapPolygon = new GMapPolygon(points, name)
                    {
                        Fill = solidBrush,
                        IsHitTestVisible = true,
                        Stroke = new Pen(Color.Violet)
                    };
                    break;
                case 2:
                    name = "Stromausfall";
                    points = pointsstrom;
                    if (points.Count < 3)
                    {
                        falsch = true;
                        break;
                    }
                    solidBrush = new SolidBrush(Color.FromArgb(50, new Pen(Color.Yellow).Color));
                    gMapPolygon = new GMapPolygon(points, name)
                    {
                        Fill = solidBrush,
                        IsHitTestVisible = true,
                        Stroke = new Pen(Color.Yellow)
                    };
                    break;
                case 3:
                    name = "Überschwemmung";
                    points = pointswasser;
                    if (points.Count < 3)
                    {
                        falsch = true;
                        break;
                    }
                    solidBrush = new SolidBrush(Color.FromArgb(50, new Pen(Color.Blue).Color));
                    gMapPolygon = new GMapPolygon(points, name)
                    {
                        Fill = solidBrush,
                        IsHitTestVisible = true,
                        Stroke = new Pen(Color.Blue)
                    };
                    break;
            }
            foreach (Item.Items i in items)
            {
                if (i.Name == name)
                {
                    switch (imagekind)
                    {
                        case true:
                            bitmap = new Bitmap(i.imagepath.ToString());
                            break;
                        case false:
                            bitmap = new Bitmap(i.altpath.ToString());
                            break;
                    }
                    break;
                }
            }
            if (falsch) { }
            else
            {
                area = areas(points);
                gMapPolygon.Tag = "Fläche ca. " + area + " km²";
                gMapPolygon.ErrorMessage = area.ToString();
                var centerpoint = middlepoint(points);
                GMarkerGoogle middle = new GMarkerGoogle(centerpoint, bitmap)
                {
                    Tag = "Fläche ca. " + area + " km²"
                };
                overlayareas.Markers.Add(middle);
                overlayareas.Polygons.Add(gMapPolygon);
                points.Clear();
                List<GMarkerGoogle> temp = new List<GMarkerGoogle>();
                foreach (GMarkerGoogle g in overlayjunk.Markers)
                {
                    if (g.ToolTipText == name)
                    {
                        temp.Add(g);
                    }
                }
                foreach (GMarkerGoogle g in temp)
                {
                    overlayjunk.Markers.Remove(g);
                }
                Gebiete.Add(gMapPolygon);
                tabControl.SelectTab(tabareas);
                LoadData(listBoxareas, 1);

            }
        }
        private PointLatLng middlepoint(List<PointLatLng> points)
        {
            PointLatLng middlepoint = new PointLatLng();
            var sum = 0;
            double Lat = 0;
            double Lng = 0;
            foreach (PointLatLng point in points)
            {
                sum += 1;
                Lat += point.Lat;
                Lng += point.Lng;
            }
            Lat = Lat / sum;
            Lng = Lng / sum;
            middlepoint.Lat = Lat;
            middlepoint.Lng = Lng;
            return middlepoint;
        }
        public double areas(List<PointLatLng> points)
        {
            double area = new double();
            IList<PointLatLng> punkte = new List<PointLatLng>();
            foreach (PointLatLng coord in points)
            {
                PointLatLng p = new PointLatLng(
                  coord.Lat * (System.Math.PI * 6378137 / 180),
                  coord.Lng * (System.Math.PI * 6378137 / 180)
                );
                punkte.Add(p);
            }
            punkte.Add(punkte[0]);
            area = System.Math.Abs(punkte.Take(punkte.Count - 1)
              .Select((p, i) => (punkte[i + 1].Lat - p.Lat) * (punkte[i + 1].Lng + p.Lng))
              .Sum() / 2) * 0.65;
            punkte.Clear();
            area = area / 10000;
            return area;
        }
        #endregion
        #region Kreis
        private void placeCircle(PointLatLng pointLatLng)
        {
            if (int.TryParse(textBoxradius.Text, out int n))
            {
                double radius = double.Parse(textBoxradius.Text);
                textBoxradius.Clear();
                GMarkerGoogle gMarkerGoogle = new GMarkerGoogle(pointLatLng, GMarkerGoogleType.yellow_pushpin);
                gMarkerGoogle.Tag = ID.ToString() + "Kreis";
                gMarkerGoogle.ToolTipText = "Kreis: " + radius.ToString();
                overlayareas.Markers.Add(gMarkerGoogle);
                CreateCircle(pointLatLng, radius);
            }
        }
        private void CreateCircle(PointLatLng pointLatLng, double radius)
        {
            PointLatLng point = pointLatLng;
            int segments = 1000;
            List<PointLatLng> gpollist = new List<PointLatLng>();
            for (int i = 0; i < segments; i++)
                gpollist.Add(FindPointAtDistanceFrom(point, i, radius / 1000));
            GMapPolygon gpol = new GMapPolygon(gpollist, "Kreis: " + radius.ToString())
            {
                Tag = "Kreis: " + radius.ToString(),
                ErrorMessage = point.Lat.ToString() + point.Lng.ToString()
            };
            overlayareas.Polygons.Add(gpol);
        }
        public static GMap.NET.PointLatLng FindPointAtDistanceFrom(GMap.NET.PointLatLng startPoint, double initialBearingRadians, double distanceKilometres)
        {
            const double radiusEarthKilometres = 6371.01;
            var distRatio = distanceKilometres / radiusEarthKilometres;
            var distRatioSine = Math.Sin(distRatio);
            var distRatioCosine = Math.Cos(distRatio);
            var startLatRad = DegreesToRadians(startPoint.Lat);
            var startLonRad = DegreesToRadians(startPoint.Lng);
            var startLatCos = Math.Cos(startLatRad);
            var startLatSin = Math.Sin(startLatRad);
            var endLatRads = Math.Asin((startLatSin * distRatioCosine) + (startLatCos * distRatioSine * Math.Cos(initialBearingRadians)));
            var endLonRads = startLonRad + Math.Atan2(
                Math.Sin(initialBearingRadians) * distRatioSine * startLatCos,
                distRatioCosine - startLatSin * Math.Sin(endLatRads));
            return new GMap.NET.PointLatLng(RadiansToDegrees(endLatRads), RadiansToDegrees(endLonRads));
        }
        public static double DegreesToRadians(double degrees)
        {
            const double degToRadFactor = Math.PI / 180;
            return degrees * degToRadFactor;
        }
        public static double RadiansToDegrees(double radians)
        {
            const double radToDegFactor = 180 / Math.PI;
            return radians * radToDegFactor;
        }
        #endregion
        #endregion
        #endregion
    }
}
