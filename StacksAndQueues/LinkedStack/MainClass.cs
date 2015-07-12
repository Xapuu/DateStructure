using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedStack
{
    class MainClass
    {
        static void Main(string[] args)
        {
            LinkedStack<int> stack = new LinkedStack<int>();

            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }
            int count = stack.Count();
            Console.WriteLine("*" + count);
            var array = stack.ToArray();

            for (int i = 0; i < count; i++)
            {
                Console.Write(stack.Pop() + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine(Environment.NewLine);
        }
    }
}
