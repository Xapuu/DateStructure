using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveOddOccurences
{
    class RemoveOddOccurences
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

            var newlist = RemoveOddOccur();
            Console.WriteLine(String.Join(" ", newlist));
        }

        static List<int> RemoveOddOccur()
        {
            var dictionaryNumbers = numbers.GroupBy(x => x)
                 .ToDictionary(g => g.Key, g => g.Count());
            List<int> evenNumber = new List<int>();

            foreach (var number in dictionaryNumbers)
            {
                if (number.Value%2 == 0)
                {
                    evenNumber.AddRange(Enumerable.Repeat(number.Key,number.Value));
                }
            }
            return evenNumber;
        } 
    }
}
