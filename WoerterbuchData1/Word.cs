using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoerterbuchData
{
    public class Word
    {
        public string Name { get; set; }
        public string CountryCode { get; set; }

        public int Id { get; set; }

        public bool IsNew 
        { 
            get
            {
                return Id == 0;
            }
        }

        public override bool Equals(object obj)
        {
            Word word = obj as Word;

            return this.Name == word.Name;
        }
    }
}
