using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace odczytywanie_tekstu
{
    public class AnalyzeText
    {
        public int lines;
        public int words;

        public AnalyzeText()
        {
            this.lines = 0;
            this.words = 0;
        }

        public int countLines(string text)
        {
            if (text == "")
            {
                return 0;
            }
            else
            {
                // DZIELI TEKST TEXTBLOCKA NA LINIJKI
                // \r\n, \r, \n - WYRAZENIA OZNACZAJACE ROZPOCZECIE NOWEJ LINIJKI W TEKSCIE
                string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                this.lines = lines.Length;

                return this.lines;
            }
        }

        public int countWords(string text)
        {
            string[] lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            StringBuilder sb = new StringBuilder();

            foreach (string line in lines)
            {
                // POMIN PUSTE LINIE
                if (!string.IsNullOrWhiteSpace(line))
                {
                    // USUWANIE NUMERU LINII Z POCZATKU
                    int index = line.IndexOf(' ');
                    if (index >= 0)
                    {
                        sb.Append(line.Substring(index + 1));
                    }
                    else
                    {
                        sb.Append(line);
                    }
                    // DODAJ SPACJE JAKO SEPARATOR
                    sb.Append(' ');
                }
            }

            // PODZIAL TEKSTU PRZU UZYCIU PUSTYCH ZNAKOW JAKO SEPARATOROW
            string[] wordsArray = sb.ToString().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            this.words = wordsArray.Length;

            return this.words;
        }
    }
}
