using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace odczytywanie_tekstu
{
    public class ReadTextFile
    {
        public OpenFileDialog ofd = new OpenFileDialog();
        public string path;

        public ReadTextFile()
        {
            path = string.Empty;
        }

        public string readText(TextBlock area)
        {
            this.path = string.Empty;
            ofd.DefaultExt = ".txt";
            ofd.Filter = "Dokumenty tekstowe (.txt)|*.txt";

            bool? res = ofd.ShowDialog();


            if (res.HasValue && res.Value)
            {
                this.path = ofd.FileName;
            }
            else
            {
                return "NIE WYBRANO PLIKU";
            }

            return this.path;
        }
    }
}
