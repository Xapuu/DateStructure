using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem7.ImplementaLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> myList = new LinkedList<string>();
            myList.Add("element");
            myList.Add("element2");
            myList.Add("element3");
            myList.Add("element4");
            myList.Add("element5");
            myList.Add("element6");
            myList.Add("element6");
            myList.Add("element6");
            myList.Add("element6");
            myList.Add("element6");
            myList.Add("element4");
            myList.Add("element4");
            myList.Add("element4");

            myList.Remove(2);

            foreach (var element in myList)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine(myList.GetCurrent);
            Console.WriteLine(myList.First);


            Console.WriteLine(myList.FirstIndexOf("item"));
            Console.WriteLine(myList.LastIndexOf("element6"));
        }
    }
}
