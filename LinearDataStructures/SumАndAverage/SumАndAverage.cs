using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumАndAverage
{
    class SumАndAverage
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            var line = Console.ReadLine();

            if (!String.IsNullOrWhiteSpace(line))
            {
                numbers = line.Split().Select(int.Parse).ToList();
            }
            else
            {
                numbers.Add(0);
            }
            Console.Clear();
            Console.WriteLine("Sum: {0}", numbers.Sum());
            Console.WriteLine("Average: {0}", numbers.Average());           
        }
    }
}
