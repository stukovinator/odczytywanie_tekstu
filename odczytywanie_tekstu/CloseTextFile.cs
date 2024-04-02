using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace odczytywanie_tekstu
{
    public class CloseTextFile : ReadTextFile 
    {
        public void close(TextBlock tb, Label lc, Label w, Border up, Label fc, TextBox se, Label fl, AnalyzeText analyzeText)
        {
            // RESETUJE APLIAKCJE DO STANU POCZĄTKOWEGO
            ofd.Reset();
            up.Background = new SolidColorBrush(Color.FromRgb(61, 61, 61));
            tb.Text = string.Empty;
            lc.Content = 0;
            fc.Content = "ZNALEZIONE: 0";
            se.Text = string.Empty;
            fl.Content = string.Empty;
            w.Content = 0;
            path = string.Empty;
            analyzeText.lines = 0;
            analyzeText.words = 0;
        }
    }
}