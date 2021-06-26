using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericsHomework;
using System;

namespace GenericsHomwork.Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void Constructor_ValidInput_Success()
        {
            int number = 4;
            Node<int> testNode = new Node<int>(number);
            Assert.IsNotNull(testNode);
        }
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void Constructor_NullInput_Success()
        {
            int? number = null;
            Node<int?> testNode = new Node<int?>(number);
        }
        [TestMethod]
        public void Constructor_NullNext_Success()
        {
            int number = 4;
            Node<int> testNode = new Node<int>(number, null);
            Assert.IsNotNull(testNode);
        }
        [TestMethod]
        public void Insert_ValidInput_Success()
        {
            int number = 4;
            Node<int> testNode = new Node<int>(number);
            testNode.Insert(number);
            Assert.IsNotNull(testNode);
        }
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void Insert_NullInput_Success()
        {
            int? number = 4;
            Node<int?> testNode = new Node<int?>(number);
            number = null;
            testNode.Insert(number);
        }
        [TestMethod]
        public void ToString_ValidNode_Success()
        {
            int number = 4;
            Node<int> testNode = new Node<int>(number);
            string output = testNode.ToString();
            string expectedOutput = "4";

            Assert.AreEqual(expectedOutput, output);
        }
        [TestMethod]
        public void DestroyLinks_ValidNode_Success()
        {
            Node<int> testNode = new Node<int>(4);
            Node<int> testNodeTwo = new Node<int>(5,testNode);
            Node<int> testNodeThree = new Node<int>(6,testNodeTwo);
            Node<int> testNodeFour = new Node<int>(7,testNodeThree);

            testNode.DestroyLinks();
            Node<int> nextNode = testNode.Next;
            Node<int> expectedNextNode = testNode;

            Assert.AreEqual(expectedNextNode, nextNode);
        }
    }
}
