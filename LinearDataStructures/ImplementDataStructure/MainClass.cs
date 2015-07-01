using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem6.ImplementtheDataStructureReversedList
{
    class MainClass
    {
        static void Main(string[] args)
        {
            ReverseList<string> test = new ReverseList<string>();

            test.Add("item");
            test.Add("item2");
            test.Add("item3");
            test.Add("item4");
            test.Add("item5");
            test.Add("item6");
            for (int i = 0; i < test.Count; i++)
            {
                Console.WriteLine(test[i]);
            }
            test.Remove(2);
            for (int i = 0; i < test.Count; i++)
            {
                Console.WriteLine(test[i]);
            }

            foreach (var item in test)
            {
                Console.WriteLine(item);
            }

        }
    }
}
