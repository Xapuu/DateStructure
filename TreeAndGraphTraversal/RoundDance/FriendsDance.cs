using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundDance
{
    class FriendsDance
    {
        private static readonly Dictionary<int, List<int>> Dancers = new Dictionary<int, List<int>>();
        private static readonly List<int> VisitedFriends = new List<int>();
        static int maxLength = 1;

        static void Main()
        {
            int friendships = int.Parse(Console.ReadLine());
            int leadDancer = int.Parse(Console.ReadLine());

            for (int friend = 0; friend < friendships; friend++)
            {
                int[] friends = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int firstFriend = friends[0];
                int secondFriend = friends[1];

                if (!Dancers.ContainsKey(firstFriend))
                {
                    Dancers[firstFriend] = new List<int>();
                }
                if (!Dancers.ContainsKey(secondFriend))
                {
                    Dancers[secondFriend] = new List<int>();
                }

                Dancers[firstFriend].Add(secondFriend);
                Dancers[secondFriend].Add(firstFriend);
            }

            DepthFirstSearchLongestDance(leadDancer);

            Console.WriteLine("Max length dance is with {0} friends", maxLength);
        }

        static void DepthFirstSearchLongestDance(int lead)
        {
            if (!VisitedFriends.Contains(lead))
            {
                VisitedFriends.Add(lead);
                maxLength = 1;

                foreach (var childNode in Dancers[lead])
                {
                    DepthFirstSearchLongestDance(childNode);
                }

                maxLength++;
            }
        }
    }
}
