using System;
using System.Diagnostics;

namespace AlgorithmsComplexity
{
    class Program
    {
        static Random rng = new Random();
        private static Stopwatch timer = new Stopwatch();
        private static StupidList<char> StupidList;   
        static void Main(string[] args)
        {
            StupidList = new StupidList<char>();

            for (int i = 0; i < 50; i++)
            {
                Add((char)rng.Next(32,128));
            }
            Console.ReadKey();
            Console.Clear();
            Remove(1);
            Console.ReadKey();
            Console.Clear();
            RemoveFirst();
            Console.ReadKey();
            Console.Clear();
            RemoveLast();
            Console.ReadKey();
            Console.Clear();
            Lenght();
            Console.ReadKey();
            Console.Clear();
            Index();
            Console.ReadKey();
            Console.Clear();
            First();
            Console.ReadKey();
            Console.Clear();
            Last();
            Console.ReadKey();
            Console.Clear();



        }
        
        /// <summary>
        /// Expected running time O(n)
        /// </summary>
        /// <param name="c"></param>
        public static void Add(char c)
        {
            timer.Reset();
            timer.Start();
            StupidList.Add(c);
            timer.Stop();
            Console.WriteLine(timer.Elapsed);
        }

        /// <summary>
        /// Worst case
        /// Expected running time O(n)
        /// Avarage 
        /// Expected running time O(n)
        /// Best case (1 element in list)
        /// Expected running time O(1)
        /// </summary>
        /// <param name="index"></param>
        public static void Remove(int index)
        {
            timer.Reset();
            timer.Start();
            StupidList.Remove(index);
            timer.Stop();
            Console.WriteLine("Remove(index) : " + index);
            Console.WriteLine(timer.Elapsed);
        }

        /// <summary>
        /// Expected running time O(n)
        /// </summary>
        public static void RemoveFirst()
        {
            timer.Reset();
            timer.Start();
            StupidList.RemoveFirst();
            timer.Stop();
            Console.WriteLine("RemoveFirst() : ");
            Console.Write(timer.Elapsed);
        }

        /// <summary>
        /// Expected running time O(n)
        /// </summary>
        public static void RemoveLast()
        {
            timer.Reset();
            timer.Start();
            StupidList.RemoveLast();
            timer.Stop();
            Console.WriteLine("RemoveLast() : ");
            Console.Write(timer.Elapsed);
        }

        /// <summary>
        /// Expected running time O(1)
        /// </summary>
        public static void Lenght()
        {
            timer.Reset();
            timer.Start();
            int x = StupidList.Length;
            timer.Stop();
            Console.WriteLine("Lenght() : ");
            Console.Write(timer.Elapsed);
        }

        /// <summary>
        /// Expected running time O(1)
        /// </summary>
        public static void Index()
        {
            timer.Reset();
            timer.Start();
            char x = StupidList[1];
            timer.Stop();
            Console.WriteLine("Index() : ");
            Console.Write(timer.Elapsed);
        }

        /// <summary>
        /// Expected running time O(1)
        /// </summary>
        public static void First()
        {
            timer.Reset();
            timer.Start();
            char x = StupidList.First;
            timer.Stop();
            Console.WriteLine("First() : ");
            Console.Write(timer.Elapsed);
        } 

        /// <summary>
        /// Expected running time O(1)
        /// </summary>
        public static void Last()
        {
            timer.Reset();
            timer.Start();
            char x = StupidList.Last;
            timer.Stop();
            Console.WriteLine("Last() : ");
            Console.Write(timer.Elapsed);
        }

    }
}
