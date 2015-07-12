using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArrayBasedStack;

namespace ArrayBasedStackUnitTest
{
    [TestClass]
    public class ArrayStackTest
    {
        [TestMethod]
        public void PushPopOneElement()
        {
            ArrayStack<int> arrayStack= new ArrayStack<int>();
            Assert.IsTrue(arrayStack.Count == 0);
            arrayStack.Push(15);
            Assert.IsTrue(arrayStack.Count == 1);
            int actual = arrayStack.Pop();
            Assert.AreEqual(15, actual);
            Assert.IsTrue(arrayStack.Count == 0);
        }

        [TestMethod]
        public void PushPopTwoElement()
        {
            ArrayStack<int> arrayStack = new ArrayStack<int>();
            Assert.IsTrue(arrayStack.Count == 0);
            arrayStack.Push(1);
            arrayStack.Push(2);
            Assert.IsTrue(arrayStack.Count == 2);
            int actual = arrayStack.Pop();
            Assert.AreEqual(2, actual);
            Assert.IsTrue(arrayStack.Count == 1);
            actual = arrayStack.Pop();
            Assert.AreEqual(1, actual);
            Assert.IsTrue(arrayStack.Count == 0);
        }

        [TestMethod]
        public void PushPopOneThousandElement()
        {
            ArrayStack<string> arrayStack = new ArrayStack<string>();
            string testWord = "Testing";
            Assert.IsTrue(arrayStack.Count == 0);

            for (int i = 0; i < 1000; i++)
            {
                arrayStack.Push(testWord);
            }

            Assert.IsTrue(arrayStack.Count == 1000);
            string actual = arrayStack.Pop();
            Assert.AreEqual(testWord, actual);
            Assert.IsTrue(arrayStack.Count == 999);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Stack is empty!")]
        public void PopFromEmptyStack()
        {
            ArrayStack<string> arrayStack = new ArrayStack<string>();
            arrayStack.Pop();
        }

        [TestMethod]
        public void ConvertToArray()
        {
            ArrayStack<int> arrayStack = new ArrayStack<int>();
            int[] expected = {3, 5, -2, 7};
            arrayStack.Push(3);
            arrayStack.Push(5);
            arrayStack.Push(-2);
            arrayStack.Push(7);

            int[] actual = arrayStack.ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ConvertEmptyStackToArray()
        {
            ArrayStack<int> arrayStack = new ArrayStack<int>();  
            int [] expected= new int[0];        
            int[] actual = arrayStack.ToArray();
            CollectionAssert.AreEqual(expected, actual);
        }

    }
}
