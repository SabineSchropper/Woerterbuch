using System;
using System.Collections.Generic;
using System.Linq;

namespace WoerterbuchLogic
{
   
        public class WoerterbuchController
        {
            /// <summary>
            /// words in dictionary
            /// </summary>
            private Dictionary<string, List<Translation>> germanToEnglishDict = new Dictionary<string, List<Translation>>();

            /// <summary>
            /// read the file to the dictionary
            /// wordsDict
            /// </summary>
            public void ReadDictionary()
            {
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
                    if (!string.IsNullOrEmpty(partArray[3]) && !string.IsNullOrEmpty(partArray[4]))
                    {
                        Translation translation1 = new Translation();
                        translation1.Word = partArray[3];
                        translation1.CountryCode = partArray[4];
                        translations.Add(translation1);
                    }
                    germanToEnglishDict.Add(word, translations);
                }
            }

            /// <summary>
            /// writes the dictionary to file
            /// </summary>
            public void WriteToFile()
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
                File.WriteAllLines("C:\\Users\\DCV\\C#\\Woerterbuch\\Woerterbuch.csv", exportString);

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
                    List<string> list = germanToEnglishDict
                                        .Where(x =>
                                        x.Key.StartsWith(filterString)).Select(x => x.Key).ToList();
                    return list;

                }
                else if (!hasToStartsWith)
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
        }
    }
