using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WoerterbuchLogic;

namespace Woerterbuch
{
    public partial class Woerterbuch : Form
    {
        WoerterbuchController controller = new WoerterbuchController("C:\\Users\\DCV\\C#\\Woerterbuch\\Woerterbuch.csv");
        Dictionary<string, List<Translation>> germanToEnglishDict = new Dictionary<string, List<Translation>>();
       
        public Woerterbuch()
        {
            InitializeComponent();

            germanToEnglishDict = controller.ReadDictionary();
            
            UpdateTranslations();
            lBoxAlphabet.DataSource = controller.GetAlphabet();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            string germanWord = tbGermanWord.Text;
            string englishWord = tbEnglishWord.Text;
            string spanishWord = tbSpanishWord.Text;

            germanToEnglishDict = controller.AppendTranslations(germanToEnglishDict,englishWord,spanishWord,germanWord);
            UpdateTranslations();

        }
        private void UpdateTranslations()
        {
            lBoxGermanWords.DataSource = germanToEnglishDict.Keys.ToList();
        }

        private void lBoxGermanWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedWord = lBoxGermanWords.SelectedItem as string;

            if (!string.IsNullOrEmpty(selectedWord))
            {

                string[] outputArray;
                outputArray = controller.OrderTranslations(germanToEnglishDict, selectedWord);
                
                tbTranslation.Text = outputArray[0];
                tbSpanishTranslation.Text = outputArray[1];
                
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            controller.WriteToFile(germanToEnglishDict);
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string searchedString = tbSearch.Text;
            var list = controller.FindResults(searchedString, false);
            lBoxGermanWords.DataSource = list;
        }

        private void lBoxAlphabet_Click(object sender, EventArgs e)
        {
            string letter = lBoxAlphabet.SelectedItem.ToString();
            var list = controller.FindResults(letter, true);         
            lBoxGermanWords.DataSource = list;

        }
    }
}
 