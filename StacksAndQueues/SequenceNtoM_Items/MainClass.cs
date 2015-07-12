using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceNtoM_Items
{
    internal class MainClass
    {
        public static void Main(string[] args)
        {
            Func<int, int>[] function =
            {
                n => n + 1,
                n => n + 2,
                n => n*2,
            };

            foreach (var sequence in ShortestSequence.GetShortestSequences (10, 30, function))
            {
                Console.WriteLine(string.Join(" -> ", sequence));
            }
        }
    }
}
