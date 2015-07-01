using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountOfOccurences
{
    class CountOfOccurences
    {
        private static List<int> numbers;

        static void Main(string[] args)
        {
            var line = Console.ReadLine();

            if (!String.IsNullOrWhiteSpace(line))
            {
                numbers = line.Split().Select(int.Parse).ToList();
            }
            else
            {
                throw new NullReferenceException("Collection can not be null or empty!");
            }

            CountOccurences();
        }

        private static void CountOccurences()
        {
            var ocurrencesDict = numbers.GroupBy(z => z)
                .ToDictionary(y => y.Key, y => y.Count());
            PrintDictionary(ocurrencesDict);
        }

        private static void PrintDictionary(Dictionary<int, int> dict)
        {
            foreach (var item in dict.OrderBy(x=>x.Key))
            {
                Console.WriteLine("{0} --> {1} time(s)", item.Key, item.Value);
            }
        }
    }
}
