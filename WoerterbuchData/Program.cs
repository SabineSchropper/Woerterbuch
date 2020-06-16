using System;

namespace WoerterbuchData
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();
            repository.GetDataString();
        }
    }
}
