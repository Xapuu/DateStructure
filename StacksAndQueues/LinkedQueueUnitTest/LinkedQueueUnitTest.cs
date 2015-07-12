using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinkedQueue;

namespace LinkedQueueUnitTest
{
    [TestClass]
    public class LinkedQueueUnitTest
    {
        [TestMethod]
        public void EnqueueDequeueOneElement()
        {
            LinkedQueue<int> queue= new LinkedQueue<int>();

            Assert.IsTrue(queue.Count == 0);
            queue.Enqueue(15);
            Assert.IsTrue(queue.Count == 1);
            int actual = queue.Dequeue();
            Assert.AreEqual(15, actual);
            Assert.IsTrue(queue.Count == 0);
        }

        [TestMethod]
        public void EnqueueDequeueTwoElement()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();

            Assert.IsTrue(queue.Count == 0);
            queue.Enqueue(1);
            queue.Enqueue(2);
            Assert.IsTrue(queue.Count == 2);
            int actual = queue.Dequeue();
            Assert.AreEqual(1, actual);
            Assert.IsTrue(queue.Count == 1);
            actual = queue.Dequeue();
            Assert.AreEqual(2, actual);
            Assert.IsTrue(queue.Count == 0);
        }


        [TestMethod]
        public void EnqueueDequeueOneThousandElement()
        {
            LinkedQueue<string> queue = new LinkedQueue<string>();
            string testWord = "Testing";
            Assert.IsTrue(queue.Count == 0);

            for (int i = 0; i < 1000; i++)
            {
                queue.Enqueue(testWord);
            }

            Assert.IsTrue(queue.Count == 1000);
            string actual = queue.Dequeue();
            Assert.AreEqual(testWord, actual);
            Assert.IsTrue(queue.Count == 999);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Queue is empty!")]
        public void DequeueEmptyLinkedQueue()
        {
            LinkedQueue<string> queue = new LinkedQueue<string>();
            queue.Dequeue();
        }


        [TestMethod]
        public void ConvertToArray()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();
            int[] expected = { 3, 5, -2, 7 };
            queue.Enqueue(3);
            queue.Enqueue(5);
            queue.Enqueue(-2);
            queue.Enqueue(7);

            int[] actual = queue.ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertEmptyQueueToArray()
        {
            LinkedQueue<int> queue = new LinkedQueue<int>();
            int[] expected = new int[0];
            int[] actual = queue.ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
