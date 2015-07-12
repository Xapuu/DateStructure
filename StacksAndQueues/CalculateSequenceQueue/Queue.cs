using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSequenceQueue
{
    class Queue
    {
        static void Main(string[] args)
        {
            const int maxElements = 50;
            int counter = 0;
            bool isFifty = false;

            var queue = new Queue<int>();
            int number = int.Parse(Console.ReadLine());
            queue.Enqueue(number);

            while (!isFifty)
            {
                counter++;
                int currentNumber = queue.Dequeue();
                Console.Write(currentNumber + " ");

                if (counter == maxElements)
                {
                    isFifty = true;
                }
                queue.Enqueue(currentNumber + 1);
                queue.Enqueue(2*currentNumber + 1);
                queue.Enqueue(currentNumber + 2);
            }
            Console.WriteLine(Environment.NewLine);
        }
    }
}
