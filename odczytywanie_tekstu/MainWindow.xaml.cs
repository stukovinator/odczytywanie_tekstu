
using System.Windows;

using System.Windows.Input;


namespace odczytywanie_tekstu
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MAIN_SEARCH_PANEL.Visibility = Visibility.Collapsed;
            FOUND_PANEL.Visibility = Visibility.Collapsed;
        }

        private void uploadFile(object sender, MouseButtonEventArgs e)
        {
            // HANDLING WRZUCANIA PLIKU TEKSTOWEGO
            ReadTextFile readTextFile = new ReadTextFile();
            WriteTextFromFile writeTextFromFile = new WriteTextFromFile();
            AnalyzeText analyzeText = new AnalyzeText();
            string text = writeTextFromFile.writeText(readTextFile.readText(MAIN_TEXT), MAIN_TEXT);

            MAIN_TEXT.Text = text;
            LINE_COUNT.Content = analyzeText.countLines(text);
            WORDS_COUNT.Content = analyzeText.countWords(text);
        }

        private void closeFile(object sender, MouseButtonEventArgs e)
        {
            // HANDLING RESETOWANIA APLIKACJI
            CloseTextFile closeTextFile = new CloseTextFile();
            AnalyzeText analyzeText = new AnalyzeText();

            closeTextFile.close(MAIN_TEXT, LINE_COUNT, WORDS_COUNT, UPLOAD_BUTTON, FOUND_COUNT, SEARCH_ENTRY, FOUND_IN_LINES_TEXT, analyzeText);
        }

        private void searchPanelOperation(object sender, MouseButtonEventArgs e)
        {
            // HANDLING PANELU WYSZUKIWANIA
            SearchPanel searchPanel = new SearchPanel();

            searchPanel.searchPanelOpenCloseHandle(MAIN_SEARCH_PANEL, SEARCH_PANEL_BAR, FOUND_PANEL);
        }

        private void searchInText(object sender, MouseButtonEventArgs e)
        {
            // HANDLING DZIALANIA WYSZUKIWANIA
            SearchPanel searchPanel = new SearchPanel();
            ReadTextFile readTextFile = new ReadTextFile();
            string text = MAIN_TEXT.Text;

            if (!string.IsNullOrWhiteSpace(text))
            {
                if (!searchPanel.checkIfEmpty(SEARCH_ENTRY))FOUND_COUNT.Content = "ZNALEZIONE: " + searchPanel.searchHandler(SEARCH_ENTRY, MAIN_TEXT, readTextFile, FOUND_IN_LINES_TEXT);
                else MessageBox.Show("Nie wpisano frazy wyszukiwania", "Brak tekstu", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
            else
            {
                MessageBox.Show("Nie wybrano pliku tekstowego", "Brak tekstu", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }
    }
}