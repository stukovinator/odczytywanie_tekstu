using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;

namespace odczytywanie_tekstu
{
    public class SearchPanel
    {

        public bool checkIfEmpty(TextBox textBox)
        {
            if(textBox.Text == string.Empty)
            {
                return true;
            }

            return false;
        }

        public void searchPanelOpenCloseHandle(StackPanel s, StackPanel bar, StackPanel found)
        {
            // OTWIERANIE I ZAMYKANIE PANELU WYSZUKIWANIA
            if (s.Visibility == Visibility.Collapsed)
            {
                s.Visibility = Visibility.Visible;
                found.Visibility = Visibility.Visible;
                foreach (object child in bar.Children)
                {
                    if (child is System.Windows.Controls.Image)
                    {
                        (child as System.Windows.Controls.Image).Source = new BitmapImage(new Uri("less.png", UriKind.RelativeOrAbsolute));
                    }
                }
            }
            else
            {
                s.Visibility = Visibility.Collapsed;
                found.Visibility = Visibility.Collapsed;
                foreach (object child in bar.Children)
                {
                    if (child is System.Windows.Controls.Image)
                    {
                        (child as System.Windows.Controls.Image).Source = new BitmapImage(new Uri("expand.png", UriKind.RelativeOrAbsolute));
                    }
                }
            }
        }

        public int searchHandler(TextBox textbox, TextBlock tb, ReadTextFile readTextFile, Label l)
        {
            // JEŚLI NIE WYBRANO PLIKU
            if (readTextFile == null)
            {
                return 0;
            }

            string search_text = textbox.Text;

            // JEŚLI OKNO WYSZUKIWANIA JEST PUSTE
            if (search_text == string.Empty)
            {
                return 0;
            }

            l.Content = string.Empty;

            int found_count = 0;

            // WZORZEC W KTÓRYM W WYSZUKIWANEJ FRAZIE "*" BĘDZIE OZNACZAĆ DOWOLNY LANCUCH ALFANUMERYCZNY ORAZ "%" KTÓRY OZNACZA DOWOLNY POJEDYNCZY ZNAK
            // \w+ - DOPASUJ CO NAJMNIEJ JEDEN ZNAK SŁOWA ALE JAK NAJMNNIEJSZA LICZBĘ ZNAKÓW
            // . - DOPASUJ JEDEN ZNAK SŁOWA
            string pattern = search_text.Replace("*", @"\w+").Replace("%", @".");

            // TEKST Z PLIKU
            string main_text = tb.Text;

            // USUNIĘCIE NUMERÓW LINII Z TEKSTU
            string textWithoutLineNumbers = Regex.Replace(main_text, @"^\d+\s", "", RegexOptions.Multiline);

            // DOPASOWANIE WYRAŻENIA REGULARNEGO DO TEKSTU PRZY UŻYCIU WZORCA. FUNKCJA ZWRACA WSZYSTKIE DOPASOWANIA ZNALEZIONE W TEKŚCIE
            //  "\b" - GRANICA SŁOWA
            MatchCollection word_matches = Regex.Matches(textWithoutLineNumbers, @"\b" + pattern + @"\b");

            // TABLICA PASUJĄCYCH SŁÓW O DŁUGOŚCI ILOŚCI ZNALEZIONYCH DOPASOWAŃ
            string[] found_words = new string[word_matches.Count];

            // UZUPEŁNIENIE TABLICY
            for (int i = 0; i < word_matches.Count; i++)
            {
                found_words[i] = word_matches[i].ToString();
            }

            // WYPISYWANIE PASUJĄCYCH LINIJEK DO ETYKIETY
            foreach (Match match in word_matches)
            {
                // ODCZYTANIE NUMERU LINII Z POZYCJI KONCOWEJ DOPASOWANIA
                int lineNumber = getLineNumber(textWithoutLineNumbers, match.Index);

                // WYPISANIE NUMERU LINII
                l.Content += $"{lineNumber} ";
            }

            found_count = found_words.Length;

            return found_count;
        }

        private int getLineNumber(string text, int index)
        {
            int lineNumber = 1;
            
            for (int i = 0; i < index; i++)
            {
                if (text[i] == '\n')
                {
                    lineNumber++;
                }
            }
            return lineNumber;
        }
    }
}