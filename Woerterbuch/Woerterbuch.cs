using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Woerterbuch
{
    public partial class Woerterbuch : Form
    {
        
        Dictionary<string, List<Translation>> germanToEnglishDict = new Dictionary<string, List<Translation>>();
        public Woerterbuch()
        {
            InitializeComponent();
            string[] stringArray = System.IO.File.ReadAllLines("C:\\Users\\DCV\\C#\\Woerterbuch\\Woerterbuch.csv");

            for (int i = 0; i < stringArray.Length; i++) 
            {
                List<Translation> translations = new List<Translation>();
                string[] partArray = stringArray[i].Split(';');
                string word = partArray[0];
                Translation translation = new Translation();
                translation.Word = partArray[1];
                translation.CountryCode = partArray[2];
                translations.Add(translation);
                if(partArray.Length > 2)
                {
                    Translation translation1 = new Translation();
                    translation1.Word = partArray[3];
                    translation1.CountryCode = partArray[4];
                    translations.Add(translation1);
                }
                germanToEnglishDict.Add(word, translations);
            }
            UpdateTranslations();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<Translation> translations = new List<Translation>();
            Translation translation = null;
            string germanWord = tbGermanWord.Text;
            string englishWord = tbEnglishWord.Text;
            string spanishWord = tbSpanishWord.Text;
            bool isSomethingAdded = false;

            if (!string.IsNullOrEmpty(germanWord) && !string.IsNullOrEmpty(englishWord))
            {
                isSomethingAdded = true;
                translation = new Translation();
                translation.Word = englishWord;
                translation.CountryCode = "EN";
                translations.Add(translation);
            }
            if (!string.IsNullOrEmpty(germanWord) && !string.IsNullOrEmpty(spanishWord))
            {
                isSomethingAdded = true;
                translation = new Translation();
                translation.Word = spanishWord;
                translation.CountryCode = "SP";
                translations.Add(translation);
            }
            if (isSomethingAdded)
            {
                if (germanToEnglishDict.ContainsKey(germanWord))
                {
                    germanToEnglishDict[germanWord].Add(translation);
                }
                else
                {
                    germanToEnglishDict.Add(germanWord, translations);
                }
                UpdateTranslations();
            }
        }
        private void UpdateTranslations()
        {
            lBoxGermanWords.DataSource = germanToEnglishDict.Keys.ToList();
        }

        private void lBoxGermanWords_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedWord = lBoxGermanWords.SelectedItem as string;

            if (!string.IsNullOrEmpty(selectedWord) && germanToEnglishDict.ContainsKey(selectedWord))
            {
                List<Translation> translations;
                bool isThereAEnglishTranslation = false;
                bool isThereASpanishTranslation = false;
                translations = germanToEnglishDict[selectedWord];
                for (int i = 0; i < translations.Count; i++)
                {
                    if (translations[i].CountryCode.Equals("EN"))
                    {
                        tbTranslation.Text = translations[i].Word;
                        isThereAEnglishTranslation = true;
                    }                   
                    else if (translations[i].CountryCode.Equals("SP"))
                    {
                        isThereASpanishTranslation = true;
                        tbSpanishTranslation.Text = translations[i].Word;
                    }
                }
                if (!isThereAEnglishTranslation)
                {
                    tbTranslation.Text = null;
                }
                if (!isThereASpanishTranslation)
                {
                    tbSpanishTranslation.Text = null;
                }


            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string[] exportString = new string[germanToEnglishDict.Count];
            int i = 0;
            foreach(KeyValuePair<string, List<Translation>> item in germanToEnglishDict)
            {
                string valueString = "";
                for(int j = 0; j < item.Value.Count; j++)
                {
                    valueString = valueString + item.Value[j].Word + ";" + item.Value[j].CountryCode + ";";
                }
                exportString[i] = item.Key + ";" + valueString;
                i++;
            }
            File.WriteAllLines("C:\\Users\\DCV\\C#\\Woerterbuch\\Woerterbuch.csv", exportString);
        }
    }
}
