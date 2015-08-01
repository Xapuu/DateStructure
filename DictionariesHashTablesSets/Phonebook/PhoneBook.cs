using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class PhoneBook
    {
        private readonly IDictionary<string, string> _phoneBook = new Dictionary<string, string>();

        public void AddSubscribe(string name, string number)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Subscriber name is null or empty!");
            }

            if (String.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentNullException(nameof(name), "Subscriber number is null or empty!");
            }

            if (!_phoneBook.ContainsKey(name))
            {
                _phoneBook[name] = number;
            }  
        }

        public void FindSubscriber(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "Subscriber name is null or empty!");
            }

            if (_phoneBook.ContainsKey(name))
            {
                PrintSubscriber(name);
            }
            else
            {
                Console.WriteLine("Contact {0} does not exist", name);
            }
        }

        private void PrintSubscriber(string name)
        {
            var subscriber = _phoneBook.First(s=>s.Key==name);
            Console.WriteLine("Name: {0} -Phone Number: {1}",subscriber.Key, subscriber.Value );
        }
    }
}
