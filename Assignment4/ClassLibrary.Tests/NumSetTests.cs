using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary;
using System;

namespace ClassLibrary.Tests
{
    [TestClass]
    public class NumSetTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_NullParam_ThrowsException()
        {
            NumSet testSet = new(null);
        }
        [TestMethod]
        public void ToString_EmptyArray_Success()
        {
            int[] emptyArray = { };
            NumSet testSet = new NumSet(emptyArray);

            string expectedResponse = "";
            string actualResponse = testSet.ToString();

            Assert.AreEqual(expectedResponse, actualResponse);
        }
        [TestMethod]
        public void ToString_NormalArray_Success()
        {
            int[] testArray = {1,2,3,4,5};
            NumSet testSet = new NumSet(testArray);

            string expectedResponse = "1 2 3 4 5";
            string actualResponse = testSet.ToString();

            Assert.AreEqual(expectedResponse, actualResponse);
        }
        [TestMethod]
        public void Equals_IdenticalArray_Success()
        {
            int[] testArray = { 1, 2, 3, 4, 5 };
            NumSet testSetOne = new NumSet(testArray);
            NumSet testSetTwo = new NumSet(testArray);
            bool result = testSetOne.Equals(testSetTwo);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Equals_ReorderedArray_Success()
        {
            int[] testArrayOne = { 1, 2, 3, 4, 5 };
            int[] testArrayTwo = { 5, 2, 1, 4, 3 };
            NumSet testSetOne = new NumSet(testArrayOne);
            NumSet testSetTwo = new NumSet(testArrayTwo);
            bool result = testSetOne.Equals(testSetTwo);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Equals_DifferentArray_Fail()
        {
            int[] testArrayOne = { 1, 2, 3, 4, 5 };
            int[] testArrayTwo = { 1, 2, 4, 4, 5 };
            NumSet testSetOne = new NumSet(testArrayOne);
            NumSet testSetTwo = new NumSet(testArrayTwo);
            bool result = testSetOne.Equals(testSetTwo);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Equals_NullArray_Fail()
        {
            int[] testArray = { 1, 2, 3, 4, 5 };
            NumSet testSetOne = new NumSet(testArray);
            bool result = testSetOne.Equals(null);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void EqualsOperator_IdenticalArray_Success()
        {
            int[] testArray = { 1, 2, 3, 4, 5 };
            NumSet testSetOne = new NumSet(testArray);
            NumSet testSetTwo = new NumSet(testArray);
            bool result = testSetOne == testSetTwo;
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void EqualsOperator_ReorderedArray_Success()
        {
            int[] testArrayOne = { 1, 2, 3, 4, 5 };
            int[] testArrayTwo = { 5, 2, 3, 4, 1 };
            NumSet testSetOne = new NumSet(testArrayOne);
            NumSet testSetTwo = new NumSet(testArrayTwo);
            bool result = testSetOne == testSetTwo;
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void EqualsOperator_NullFirstArray_Fail()
        {
            int[] testArray = { 1, 2, 3, 4, 5 };
            NumSet? testSetOne = null;
            NumSet? testSetTwo = new NumSet(testArray);
            bool result = testSetOne == testSetTwo;
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void EqualsOperator_NullSecondArray_Fail()
        {
            int[] testArray = { 1, 2, 3, 4, 5 };
            NumSet? testSetOne = new NumSet(testArray);
            NumSet? testSetTwo = null;
            bool result = testSetOne == testSetTwo;
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void EqualsOperator_DifferentArray_Fail()
        {
            int[] testArrayOne = { 1, 2, 3, 4, 5 };
            int[] testArrayTwo = { 2, 7, 8, 4, 2 };
            NumSet? testSetOne = new NumSet(testArrayOne);
            NumSet? testSetTwo = new NumSet(testArrayTwo);
            bool result = testSetOne == testSetTwo;
            Assert.IsFalse(result);
        }
    }
}

