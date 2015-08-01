using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountSymbols
{
    class CountSymbolsMain
    {
        static void Main(string[] args)
        {
            var alphabetCollection = new Dictionary<char, int>();
            string inputText = Console.ReadLine();

            foreach (var character in inputText)
            {
                if (!alphabetCollection.ContainsKey(character))
                {
                    alphabetCollection[character] = 0;
                }
                alphabetCollection[character]++;
            }

            PrintAlphabetOccurrence(alphabetCollection);
        }

        /// <summary>
        /// Print Collection of characters
        /// and occurrence in a text
        /// </summary>
        /// <param name="collection"></param>
        private static void PrintAlphabetOccurrence(Dictionary<char, int> collection)
        {
            foreach (var character in collection.OrderBy(ch=>ch.Key))
            {
                Console.WriteLine("{0} - {1} time(s)", character.Key, character.Value);
            }
        }
    }
}
