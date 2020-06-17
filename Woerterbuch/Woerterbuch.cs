using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using WoerterbuchData;
using WoerterbuchLogic;

namespace Woerterbuch
{
    public partial class Woerterbuch : Form
    {
        string language1;
        List<string> saveList = new List<string>();
        private int searchCounter = 0;
        WoerterbuchController controller = new WoerterbuchController(""+ConfigurationManager.AppSettings.Get("FilePath")+"");
        Dictionary<Word, List<Word>> germanToEnglishDict = new Dictionary<Word, List<Word>>();
       
        public Woerterbuch()
        {
            InitializeComponent();

            string languages = ConfigurationManager.AppSettings.Get("Languages");
            string[] languageArray = languages.Split(';');

            foreach(string item in languageArray)
            {
                coBoLang1.Items.Add(item);
                coBoLang2.Items.Add(item);
            }

            germanToEnglishDict = controller.FillDictionaryFromDatabase("DE");
            
            UpdateTranslations();
            lBoxAlphabet.DataSource = controller.GetAlphabet();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            string firstWord = tbFirstWord.Text;
            string firstCountry = coBoLang1.SelectedItem as string;
            string secondWord = tbSecondWord.Text;
            string secondCountry = coBoLang2.SelectedItem as string;

            germanToEnglishDict = controller.AppendTranslations(firstWord,firstCountry,secondWord,secondCountry);
            UpdateTranslations();

        }
        private void UpdateTranslations()
        {
            
            List<string> dataList = new List<string>();
            foreach (KeyValuePair<Word, List<Word>> item in germanToEnglishDict)
            {
                dataList.Add(item.Key.Name);
            }
            lBoxGermanWords.DataSource = dataList;
        }

        private void lBoxGermanWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedWord = lBoxGermanWords.SelectedItem as string;
            //searchCounter helps me to better handle the countryCode Searching in tbSearchCountry_TextChanged
            searchCounter = 0;

            if (!string.IsNullOrEmpty(selectedWord))
            {

                List<string> outputList = new List<string>();
                outputList = controller.OrderTranslations(germanToEnglishDict, selectedWord);

                lBoxTranslation.DataSource = outputList;
                
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            controller.SaveData(germanToEnglishDict);
        }

        private void coBoLang1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string language = coBoLang1.SelectedItem as string;
            language1 = language;
            germanToEnglishDict.Clear();
            germanToEnglishDict = controller.FillDictionaryFromDatabase(language1);
            UpdateTranslations();
        }

        private void tbSearchCountry_TextChanged(object sender, EventArgs e)
        {
            string searchedCountryCode = tbSearchCountry.Text;
            List<string> list = new List<string>();
            
            List<string> newList = new List<string>();
            foreach (var item in lBoxTranslation.Items)
            {
                list.Add(item as string);
                if (searchCounter == 0)
                {
                    saveList.Add(item as string);
                }
            }
            newList = controller.SearchInTranslations(searchedCountryCode,list);
            lBoxTranslation.DataSource = newList;
            searchCounter++;
        }

        private void tbSearchCountry_Leave(object sender, EventArgs e)
        {
            lBoxTranslation.DataSource = saveList;
        }
        ///TODO...Verknüpfungen zwischen zwei Worten in der Relation Tabelle
        ///z.B. Fuchs...Zorro, Fox....Zorro, autom. Verbíndung zw. Fuchs und Fox
    }
}
 