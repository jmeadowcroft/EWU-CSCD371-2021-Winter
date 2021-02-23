using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace LinqStuff.Tests
{
    [TestClass]
    public class CustomCollections
    {
        [TestMethod]
        public void Fibonacci_Enumerate10Items_Success()
        {
            List<int> expected = new List<int>() { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 };

            int fourth = expected[3];

            IEnumerable<int> actual = new FibonacciSequence();



            expected.OrderBy(item => item).SequenceEqual(
                actual.Take(expected.Count).OrderBy(item => item));

            // CollectionAssert.AreEquivalent(expected, actual.Take(expected.Count));

            expected.SequenceEqual(actual.Take(expected.Count));

            int counter = 0;
            foreach(int number in actual)
            {
                Assert.AreEqual<int>(number,expected[counter]);
                counter++;
                if(counter >= expected.Count)
                {
                    break;
                }
            }

            Assert.AreEqual<int>(10, counter);
        }

        class Person
        {

        }

        [TestMethod]
        public void Dictionaries()
        {
            Dictionary<int, string> dictionary = new();

            foreach (KeyValuePair<int, string> item in dictionary)
            {

            }

            foreach ((int key, string value) item in dictionary.Select(pair=>(pair.Key, pair.Value)))
            {

            }
        }


        [TestMethod]
        public void IEnumerable_CountReturns100()
        {
            Assert.AreEqual<int>(100, new FibonacciSequence().Count());
        }

        [TestMethod]
        public void Fibonacci_Enumerate2Items_Success()
        {

            IEnumerable<int> actual = new FibonacciSequence();

            IEnumerator<int> enumerator = actual.GetEnumerator();
            enumerator.MoveNext();
            Assert.AreEqual<int>(0, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(1, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(1, enumerator.Current);
            enumerator.MoveNext();
            Assert.AreEqual<int>(2, enumerator.Current);
        }

        [TestMethod]
        public void Index_3rdItem_Return1()
        {
            Assert.AreEqual<int>(1, new FibonacciSequence()[2]);
        }

        [TestMethod]
        public void Index_FirstItem_Return0()
        {
            Assert.AreEqual<int>(0, new FibonacciSequence()[0]);
        }

        [TestMethod]
        public void Index_SecondItem_Return0()
        {
            Assert.AreEqual<int>(1, new FibonacciSequence()[1]);
        }

        public class FibonacciSequence : IEnumerable<int>
        {
            public int Maximum { get; }

            public FibonacciSequence(int maximum = 100)
            {
                Maximum = maximum;
            }

            public int this[int index]
            {
                get
                {
                    IEnumerable<int> result = new FibonacciSequence();

                    return result.Skip(index).First();
                }
            }

            static public IEnumerable<int> Data
            {
                get
                {
                    foreach(int number in new FibonacciSequence())
                    {
                        yield return number;
                    }
                }
            }

            public IEnumerator<int> GetEnumerator()
            {
                int start = 0;
                int next = 1;
                int counter = 0;
                while(counter < Maximum)
                {
                    yield return start;
                    int sum = start + next;
                    start = next;
                    next = sum;
                    counter++;
                }    
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
