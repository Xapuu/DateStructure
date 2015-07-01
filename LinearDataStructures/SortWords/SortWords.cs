using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortWords
{
    class SortWords
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine().Split().ToList();

            var sorted = line.OrderBy(word => word);
            Console.WriteLine(String.Join(" ", sorted));
        }
    }
}
