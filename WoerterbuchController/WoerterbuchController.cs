using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using WoerterbuchData;
using Google.Protobuf.WellKnownTypes;

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
        private Dictionary<Word, List<Word>> germanToEnglishDict = new Dictionary<Word, List<Word>>();
        Repository repository = new Repository();
        List<string> dataList = new List<string>();
        /// <summary>
        /// read the file to the dictionary
        /// wordsDict
        /// </summary>
        public Dictionary<Word, List<Word>> ReadDictionary()
        {
            string[] stringArray = System.IO.File.ReadAllLines(path);

            germanToEnglishDict = TransformData(stringArray);

            return germanToEnglishDict;
        }
        public Dictionary<Word, List<Word>> FillDictionaryFromDatabase()
        {
            dataList = repository.GetDataList();
            string[] stringArray = dataList.ToArray();
            germanToEnglishDict = TransformData(stringArray);
            return germanToEnglishDict;
        }
        public Dictionary<Word, List<Word>> TransformData(string[] stringArray)
        {
            
            for (int i = 0; i < stringArray.Length; i++)
            {

                List<Word> words = new List<Word>();
                string[] partArray = stringArray[i].Split(';');
                Word newWord = new Word();

                newWord.Name = partArray[0];
                newWord.CountryCode = partArray[1];
                newWord.Id = Convert.ToInt32(partArray[2]);
                
                if (!string.IsNullOrEmpty(partArray[3]) && !string.IsNullOrEmpty(partArray[4]))
                {
                    Word newWord1 = new Word();
                    newWord1.Name = partArray[3];
                    newWord1.CountryCode = partArray[4];
                    newWord1.Id = Convert.ToInt32(partArray[5]);
                    words.Add(newWord1);
                }
                if (!string.IsNullOrEmpty(partArray[6]) && !string.IsNullOrEmpty(partArray[7]))
                {
                    Word newWord2 = new Word();
                    newWord2.Name = partArray[6];
                    newWord2.CountryCode = partArray[7];
                    newWord2.Id = Convert.ToInt32(partArray[8]);
                    words.Add(newWord2);
                }
                germanToEnglishDict.Add(newWord, words);

            }
            return germanToEnglishDict;

        }

        /// <summary>
        /// writes the dictionary to file
        /// </summary>
        public void WriteToFile(Dictionary<Word, List<Word>> germanToEnglishDict)
        {
            string[] exportString = new string[germanToEnglishDict.Count];
            int i = 0;
            int number = 2;

            foreach (KeyValuePair<Word, List<Word>> item in germanToEnglishDict)
            { 
                string valueString = "";
                for (int j = 0; j < item.Value.Count; j++)
                {

                    valueString = valueString + item.Value[j].Name + ";" + item.Value[j].CountryCode + ";" + item.Value[j].Id + ";";
          
                }
               
                exportString[i] = item.Key.Name + ";" + item.Key.CountryCode +";" + item.Key.Id + ";" + valueString;

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
                                        x.Key.Name.StartsWith(filterString) || x.Key.Name.StartsWith(filterStringLower)).Select(x => x.Key.Name).ToList();
                return list;

            }
            else
            {
                List<string> list = germanToEnglishDict
                                    .Where(x =>
                                    x.Key.Name.Contains(filterString)).Select(x => x.Key.Name).ToList();
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

        public Dictionary<Word, List<Word>> AppendTranslations(Dictionary<Word, List<Word>> germanToEnglishDict,
            string englishWord, string spanishWord, string germanWord)
        {
            bool isSomethingAdded = false;
            Word translation = null;
            List<Word> translations = new List<Word>();

            Word germanWordObject = new Word();
            germanWordObject.Name = germanWord;
            germanWordObject.CountryCode = "DE";


            if (!string.IsNullOrEmpty(germanWord) && !string.IsNullOrEmpty(englishWord))
            {
                isSomethingAdded = true;
                translation = new Word();
                translation.Name = englishWord;
                translation.CountryCode = "EN";
                translations.Add(translation);

            }
            if (!string.IsNullOrEmpty(germanWord) && !string.IsNullOrEmpty(spanishWord))
            {
                isSomethingAdded = true;
                translation = new Word();
                translation.Name = spanishWord;
                translation.CountryCode = "SP";
                translations.Add(translation);
            }
            if (isSomethingAdded)
            {
                if (germanToEnglishDict.ContainsKey(germanWordObject))
                {
                    germanToEnglishDict[germanWordObject].Add(translation);
                }
                else
                {
                    germanToEnglishDict.Add(germanWordObject, translations);
                }
                
            }
            return germanToEnglishDict;
        }
        public string[] OrderTranslations(Dictionary<Word, List<Word>> germanToEnglishDict, string selectedWord)
        {
            
            string[] outputArray = new string[2];
            foreach (KeyValuePair<Word, List<Word>> item in germanToEnglishDict)
            {
                if (item.Key.Name.Equals(selectedWord))
                {
                   for(int i = 0; i < item.Value.Count; i++)
                    {
                        if (item.Value[i].CountryCode.Equals("EN"))
                        {
                            outputArray[0] = item.Value[i].Name;
                        }
                        else if (item.Value[i].CountryCode.Equals("SP"))
                        {
                            outputArray[1] = item.Value[i].Name;
                        }

                    }

                }
            }
                
            return outputArray;
        }
    }
}
