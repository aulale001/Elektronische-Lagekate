using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elektronische_Lagekarte
{
    class Item
    {
        public class Items
        {
            public string Name, imagepath,altpath;
            public int Kategorie;
            public Items(string name, string path,string apath, int i)
            {
                imagepath = path;
                altpath = apath;
                Name = name;
                Kategorie = i;
            }
            public Items()
            {
                imagepath = null;
                altpath = null;
                Name = null;
                Kategorie = -1;
            }
        }
    }
}
