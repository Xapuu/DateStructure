using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    internal class PhoneBoookMain
    {
        private static void Main(string[] args)
        {
            PhoneBook phoneBook = new PhoneBook();
            Console.WriteLine("Search and name for search the phonebook entries");
            Console.WriteLine("Exit to terminate the programm");
            string input = Console.ReadLine();
           
            while (!String.IsNullOrWhiteSpace(input))
            {
                string[] subscriber = input.Split('-');
                string name = subscriber[0];
                string number = subscriber[1];

                phoneBook.AddSubscribe(name, number);
                input = Console.ReadLine();

                if (input == "search")
                {
                    while (true)
                    {
                        input = Console.ReadLine();

                        if (input == "exit")
                        {
                            Environment.Exit(0);
                        }
                        phoneBook.FindSubscriber(input);
                    }
                }
            }        
        }
    }
}
