using System;
using System.Collections.Generic;
using System.Text;

namespace WoerterbuchLogic
{
    public class NoLetterException : Exception
    {
        public NoLetterException(string message) : base(message)
        {

        }
    }
}
