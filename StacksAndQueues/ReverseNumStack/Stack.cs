using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseNumStack
{
    internal class Stack
    {
        private static void Main(string[] args)
        {
            string input = Console.ReadLine();

            if (!String.IsNullOrWhiteSpace(input))
            {
                int[] numbers = input.Split().Select(int.Parse).ToArray();
                var stack = new Stack<int>(numbers);
                int stackCounter = stack.Count;

                for (int i = 0; i < stackCounter; i++)
                {
                    Console.Write(stack.Pop() + " ");
                }              
            }
            else
            {
                Console.WriteLine(" ");
            }
            Console.WriteLine(Environment.NewLine);
        }
    }
}