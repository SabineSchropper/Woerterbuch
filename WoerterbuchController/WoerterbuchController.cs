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
            var allWords = new List<Word>();
            foreach (KeyValuePair<Word, List<Word>> item in germanToEnglishDict)
            {
                allWords.Add(item.Key);
            }    
            for (int i = 0; i < stringArray.Length; i++)
            {

                List<Word> words = new List<Word>();
                string[] partArray = stringArray[i].Split(';');
                var wordName = partArray[0];
                Word newWord = null;
                Word newWord1 = null;
                Word newWord2 = null;
                ///search if there already exists the word
                ///if it not exists then a new Word is going to be created
                ///creating new word object and compare it afterwards only generates problems
                if (allWords.Any(x => x.Name == wordName))
                {
                    newWord = allWords.FirstOrDefault(x => x.Name == wordName);
                }
                else
                {
                    newWord = new Word();
                    newWord.Name = partArray[0];
                    newWord.CountryCode = partArray[1];
                    newWord.Id = Convert.ToInt32(partArray[2]);
                    allWords.Add(newWord);
                }
                
                if (!string.IsNullOrEmpty(partArray[3]) && !string.IsNullOrEmpty(partArray[4]))
                {
                    newWord1 = new Word();
                    newWord1.Name = partArray[3];
                    newWord1.CountryCode = partArray[4];
                    newWord1.Id = Convert.ToInt32(partArray[5]);
                    words.Add(newWord1);
                }
                if (!string.IsNullOrEmpty(partArray[6]) && !string.IsNullOrEmpty(partArray[7]))
                {
                    newWord2 = new Word();
                    newWord2.Name = partArray[6];
                    newWord2.CountryCode = partArray[7];
                    newWord2.Id = Convert.ToInt32(partArray[8]);
                    words.Add(newWord2);
                }
                if (!germanToEnglishDict.Keys.Any(x => x.Equals(newWord)))
                {
                    germanToEnglishDict.Add(newWord, words);
                }
                else
                {
                    if (newWord1 != null && !germanToEnglishDict[newWord].Contains(newWord1))
                    {
                        germanToEnglishDict[newWord].Add(newWord1);
                    }
                    if (newWord2 != null && !germanToEnglishDict[newWord].Contains(newWord2))
                    {
                        germanToEnglishDict[newWord].Add(newWord2);
                    }
                }
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

        public Dictionary<Word, List<Word>> AppendTranslations(string englishWord, string spanishWord, string germanWord)
        {
            bool isSomethingAdded = false;
            string inputString = "";
        
            if (!string.IsNullOrEmpty(germanWord) && !string.IsNullOrEmpty(englishWord))
            {
                isSomethingAdded = true;
                inputString = germanWord + ";" + "DE" + ";" + "0" + ";";
                inputString = inputString + englishWord + ";" + "EN" + ";" + "0" + ";";

            }
            if (!string.IsNullOrEmpty(germanWord) && !string.IsNullOrEmpty(spanishWord))
            {
                if (isSomethingAdded)
                {
                  inputString = inputString + spanishWord + ";" + "SP" + ";" + "0" + ";";
                }
                else
                {
                    inputString = germanWord + ";" + "DE" + ";" + "0" + ";";
                    inputString = inputString + spanishWord + ";" + "SP" + ";" + "0" + ";";
                }
            }
            string[] array = { inputString };
            Dictionary<Word, List<Word>> dict = new Dictionary<Word, List<Word>>();
            dict = TransformData(array);
           
            
            return dict;
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
                    break;
                }
            }
                
            return outputArray;
        }
        public void SaveData(Dictionary<Word,List<Word>> germanToEnglishDict)
        {
            Dictionary<Word, List<Word>> newDict = new Dictionary<Word, List<Word>>();
            newDict = SearchChanges(germanToEnglishDict);
            repository.AddDataToDatabase(newDict);
        }
        public Dictionary<Word,List<Word>> SearchChanges(Dictionary<Word, List<Word>> germanToEnglishDict)
        {
            Dictionary<Word, List<Word>> newDict = new Dictionary<Word, List<Word>>();
            foreach (KeyValuePair<Word, List<Word>> item in germanToEnglishDict)
            {
                ///search for either Id = 0 in Key or Id = 0 in Values
                ///this shows us that the word is new and should be added to Database
                if(item.Key.Id == 0)
                {
                    newDict.Add(item.Key,item.Value);
                }
                else
                {
                    for(int i = 0; i < item.Value.Count; i++)
                    {
                        if(item.Value[i].Id == 0)
                        {
                            newDict.Add(item.Key, item.Value);
                        }
                    }
                }
            }

            return newDict;
        }
    }
}
