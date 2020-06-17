using System;
using System.Collections.Generic;
using System.Text;

namespace WoerterbuchLogic
{
    public class PersonalException : Exception
    {
        public PersonalException(string message) : base(message)
        {

        }
    }
}
