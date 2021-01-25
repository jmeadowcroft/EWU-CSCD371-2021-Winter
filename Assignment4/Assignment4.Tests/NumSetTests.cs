using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment4.Tests
{
    [TestClass]
    public class NumSetTests
    {
        [TestMethod]
        public void ToString_OutputsValues()
        {
            NumSet set = new(1, 2, 3);

            Assert.AreEqual("1, 2, 3", set.ToString());
        }

        [TestMethod]
        public void Equals_WithNull_ReturnsFalse()
        {
            NumSet set = new(1, 2, 3);

            Assert.IsFalse(set.Equals(null));
        }

        [TestMethod]
        public void Equals_WithEqualValues_ReturnsTrue()
        {
            NumSet set1 = new(1, 2, 3);
            NumSet set2 = new(3, 2, 1);

            Assert.AreEqual(set1, set2);
        }

        [TestMethod]
        public void Equals_WithUnequalValues_ReturnsFalse()
        {
            NumSet set1 = new(1, 2, 3);
            NumSet set2 = new(3, 4);

            Assert.AreNotEqual(set1, set2);
        }

        [TestMethod]
        public void EqualsOperator_WithEqualValues_ReturnsTrue()
        {
            NumSet set1 = new(1, 2, 3);
            NumSet set2 = new(3, 2, 1);

            Assert.IsTrue(set1 == set2);
        }

        [TestMethod]
        public void EqualsOperator_WithUnequalValues_ReturnsFalse()
        {
            NumSet set1 = new(1, 2, 3);
            NumSet set2 = new(3, 2, 0);

            Assert.IsFalse(set1 == set2);
        }

        [TestMethod]
        public void NotEqualsOperator_WithEqualValues_ReturnsFalse()
        {
            NumSet set1 = new(1, 2, 3);
            NumSet set2 = new(3, 2, 1);

            Assert.IsFalse(set1 != set2);
        }

        [TestMethod]
        public void NotEqualsOperator_WithUnequalValues_ReturnsTrue()
        {
            NumSet set1 = new(1, 2, 3);
            NumSet set2 = new(3, 2, 0);

            Assert.IsTrue(set1 != set2);
        }

        [TestMethod]
        public void GetHashCode_WithEqualValues_ReturnsMatchingHashCodes()
        {
            NumSet set1 = new(1, 2, 3);
            NumSet set2 = new(3, 2, 1);

            Assert.AreEqual(set1.GetHashCode(), set2.GetHashCode());
        }

        [TestMethod]
        public void ImplictArrayOperator_WithNull_ReturnsNull()
        {
            NumSet? set = null;
            int[]? array = set;
            Assert.IsNull(array);
        }

        [TestMethod]
        public void ImplictArrayOperator_WithSet_ReturnsArray()
        {
            NumSet set = new(1, 2, 3);
            int[]? array = set;
            CollectionAssert.AreEquivalent(new[] { 1, 2, 3 }, array);
        }

        [TestMethod]
        public void GetValues_ReturnsValues()
        {
            NumSet set = new(1, 2, 3);

            int[] values = set.GetValues();
            CollectionAssert.AreEquivalent(new[] { 1, 2, 3 }, values);
        }

        [TestMethod]
        public void GetValues_ModifyingReturnedValues_DoesNotModifySet()
        {
            NumSet set = new(1, 2, 3);

            int[] values = set.GetValues();

            int hashCode = set.GetHashCode();

            values[0] = -1;

            Assert.AreEqual(hashCode, set.GetHashCode());
        }
    }
}
