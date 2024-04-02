using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace odczytywanie_tekstu
{
    public class WriteTextFromFile
    {
        public string text;

        public WriteTextFromFile()
        {
            this.text = string.Empty;
        }

        public string writeText(string path, TextBlock textBlock)
        {
            if (!string.IsNullOrWhiteSpace(path) || path != "NIE WYBRANO PLIKU")
            {
                string line;
                try
                {
                    StreamReader sr = new StreamReader(path);
                    // ODCZYTUJE LINIE PLIKU TEKSTOWEGO
                    line = sr.ReadLine();


                    if (textBlock.Text == string.Empty)
                    {
                        int i = 1;
                        while (line != null)
                        {
                            // DODAJE TEKST Z LINII DO ZMIENNEJ PRZECHOWUJACEJ CALY TEKST PLIKU
                            this.text += $"{i}  " + line;

                            line = sr.ReadLine();
                            i++;
                            // DODAJE ZNAK NOWEJ LINII TYLKO WTEDY GDY NIE JEST TO OSTATNIA LINIA PLIKU
                            if (line != null)
                                this.text += "\r\n";
                        }
                    }
                    else
                    {
                        this.text = "";
                        int i = 1;
                        while (line != null)
                        {
                            // DODAJE TEKST Z LINII DO ZMIENNEJ PRZECHOWUJACEJ CALY TEKST PLIKU
                            this.text += $"{i}  " + line;

                            line = sr.ReadLine();
                            i++;
                            // DODAJE ZNAK NOWEJ LINII TYLKO WTEDY GDY NIE JEST TO OSTATNIA LINIA PLIKU
                            if (line != null)
                                this.text += "\r\n";
                        }
                    }

                    if (line != null)
                        this.text += "»  " + line;

                    sr.Close();
                }
                catch (Exception er)
                {
                    Console.WriteLine(er.Message);
                }
                finally
                {
                    Console.WriteLine("Wypisano");
                }
            }
            else
            {
                return "NIE WYBRANO PLIKU";
            }

            return this.text;
        }
    }
}
