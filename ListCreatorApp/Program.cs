using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionApp
{
    class Program
    {
        static void Main(string[] args)
        {
           
            _ListInt _List = new _ListInt(5);
            _List.Add(5);
            _List.Add(25);
            _List.Add(42);
            _List.Add(41);
            _List.Add(14);
            foreach (var item in _List)
            {
                Console.WriteLine(item);
            }
            _ListString ListString = new _ListString(4);
            ListString.Add("Alpha");
            ListString.Add("Betta");
            ListString.Add("Gamma");
            ListString.Add("Delta");
            foreach (var item in ListString)
            {
                Console.WriteLine(item);
            }

        }
    }
}
