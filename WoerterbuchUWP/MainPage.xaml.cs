using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WoerterbuchLogic;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WoerterbuchUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        WoerterbuchController controller = new WoerterbuchController("C:\\Users\\DCV\\C#\\Woerterbuch\\Woerterbuch.csv");
        Dictionary<string, List<Word>> germanToEnglishDict = new Dictionary<string, List<Word>>();
        public MainPage()
        {
            this.InitializeComponent();
            germanToEnglishDict = controller.ReadDictionary();
            UpdateTranslations();
            lBoxAlphabet.DataContext = controller.GetAlphabet();
        }

        private void btnAddTranslation_Click(object sender, RoutedEventArgs e)
        {
            string germanWord = tbGermanWord.Text;
            string englishWord = tbEnglishWord.Text;
            string spanishWord = tbSpanishWord.Text;

            germanToEnglishDict = controller.AppendTranslations(germanToEnglishDict, englishWord, spanishWord, germanWord);
            UpdateTranslations();

        }
        private void UpdateTranslations()
        {
            lBoxGermanWord.DataContext = germanToEnglishDict.Keys.ToList();
        }

        private void lBoxGermanWord_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedWord = lBoxGermanWord.SelectedItem as string;

            if (!string.IsNullOrEmpty(selectedWord))
            {

                string[] outputArray;
                outputArray = controller.OrderTranslations(germanToEnglishDict, selectedWord);

                tbTranslation.Text = outputArray[0];
                tbSpanishTranslation.Text = outputArray[1];

            }
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            controller.WriteToFile(germanToEnglishDict);
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchedString = tbSearch.Text;
            var list = controller.FindResults(searchedString, false);
            lBoxGermanWord.DataContext = list;
        }

        private void lBoxAlphabet_Tapped(object sender, TappedRoutedEventArgs e)
        {
            string searchedLetter = lBoxAlphabet.SelectedItem as string;
            var list = controller.FindResults(searchedLetter, true);
            lBoxGermanWord.DataContext = list;
        }

        private void lBoxAlphabet_LosingFocus(UIElement sender, LosingFocusEventArgs args)
        {
            UpdateTranslations();
        }
    }
}
