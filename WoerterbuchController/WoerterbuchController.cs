using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace WoerterbuchLogic
{
    public class WoerterbuchController
    {
        private string path;
        public WoerterbuchController(string path)
        {
            this.path = path;
        }
        /// <summary>
        /// words in dictionary
        /// </summary>
        private Dictionary<string, List<Translation>> germanToEnglishDict = new Dictionary<string, List<Translation>>();

        /// <summary>
        /// read the file to the dictionary
        /// wordsDict
        /// </summary>
        public Dictionary<string, List<Translation>> ReadDictionary()
        {
            string[] stringArray = System.IO.File.ReadAllLines(path);

            for (int i = 0; i < stringArray.Length; i++)
            {
                List<Translation> translations = new List<Translation>();
                string[] partArray = stringArray[i].Split(';');
                string word = partArray[0];
                Translation translation = new Translation();
                translation.Word = partArray[1];
                translation.CountryCode = partArray[2];
                translations.Add(translation);
                if (!string.IsNullOrEmpty(partArray[3]) && !string.IsNullOrEmpty(partArray[4]))
                {
                    Translation translation1 = new Translation();
                    translation1.Word = partArray[3];
                    translation1.CountryCode = partArray[4];
                    translations.Add(translation1);
                }
                germanToEnglishDict.Add(word, translations);
            }
            return germanToEnglishDict;
        }

        /// <summary>
        /// writes the dictionary to file
        /// </summary>
        public void WriteToFile(Dictionary<string, List<Translation>> germanToEnglishDict)
        {
            string[] exportString = new string[germanToEnglishDict.Count];
            int i = 0;
            int number = 2;

            foreach (KeyValuePair<string, List<Translation>> item in germanToEnglishDict)
            {
                int difference = 0;
                string valueString = "";
                for (int j = 0; j < item.Value.Count; j++)
                {

                    valueString = valueString + item.Value[j].Word + ";" + item.Value[j].CountryCode + ";";

                }
                difference = number - item.Value.Count;
                /// need the semicolons to read it right in Public Woerterbuch()
                for (int j = 0; j < difference; j++)
                {
                    valueString = valueString + ";";
                }
                exportString[i] = item.Key + ";" + valueString;

                i++;
            }
            File.WriteAllLines(path, exportString);

        }

        /// <summary>
        /// filters the dictionary and returns a list
        /// </summary>
        /// <param name="filterString"></param>
        /// <param name="hasToStartsWith"></param>
        /// <returns></returns>
        public List<string> FindResults(string filterString, bool hasToStartsWith)
        {
            if (hasToStartsWith)
            {
                string filterStringLower = filterString.ToLower();
                List<string> list = germanToEnglishDict
                                        .Where(x =>
                                        x.Key.StartsWith(filterString) || x.Key.StartsWith(filterStringLower)).Select(x => x.Key).ToList();
                return list;

            }
            else
            {
                List<string> list = germanToEnglishDict
                                    .Where(x =>
                                    x.Key.Contains(filterString)).Select(x => x.Key).ToList();
                return list;
            }

        }

        /// <summary>
        /// returns the alphabet for the filtering
        /// </summary>
        /// <returns></returns>
        public List<string> GetAlphabet()
        {
            string[] alphabetArray = {"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R",
            "S","T","U","V","W","X","Y","Z"};
            var list = alphabetArray.ToList();
            return list;
        }

        public Dictionary<string, List<Translation>> AppendTranslations(Dictionary<string, List<Translation>> germanToEnglishDict,
            string englishWord, string spanishWord, string germanWord)
        {
            bool isSomethingAdded = false;
            Translation translation = null;
            List<Translation> translations = new List<Translation>();

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
                
            }
            return germanToEnglishDict;
        }
        public List<string> OrderTranslations(Dictionary<string, List<Translation>> germanToEnglishDict, string selectedWord)
        {
            List<Translation> translations;
            List<string> outputList = null;
            translations = germanToEnglishDict[selectedWord];
            for (int i = 0; i < translations.Count; i++)
            {
                if (translations[i].CountryCode.Equals("EN"))
                {
                    outputList[0] = translations[i].Word;
                }
                else if (translations[i].CountryCode.Equals("SP"))
                {
                    outputList[1] = translations[i].Word;
                }

            }
            return outputList;
        }
    }
}
