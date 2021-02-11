using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Assignment4.Tests
{
    [TestClass]
    public class NumSetTests
    {


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NumSet_NullParams_ArgumentNullException()
        {
            
            NumSet numSet = new NumSet(null!);
        }

        [TestMethod]
        public void NumSet_validSet_SavesInputInSet()
        {
            NumSet numSet = new NumSet(8, 4, 2, 1, 0);

            var arr = new int[]{8, 4, 2, 1, 0};

            var temp = new HashSet<int>(arr);

            bool res = numSet.Set.SetEquals(temp);

            Assert.IsTrue(res); 
        }

        [TestMethod]
        public void NumSet_NoParams_CreateEmptySet()
        {
            
            NumSet numSet = new NumSet();

            bool res = numSet.Set.SetEquals(new HashSet<int>());

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void NumSet_duplicates_AreEqual()
        {
            NumSet ns1 = new NumSet(8, 4, 2, 1, 0);
            NumSet ns2 = new NumSet(8, 4, 4, 2, 2, 2, 2, 2, 1, 1, 0, 0);

            bool res = ns1.Equals(ns2);

            Assert.IsTrue(res); 
        }

        [TestMethod]
        public void Equals_EqualRef_True()
        {
            NumSet ns1 = new NumSet(8, 4, 2, 1, 0);

            Assert.IsTrue(ns1.Equals(ns1)); 
        }

        [TestMethod]
        public void Equals_ObjNotNumSet_False()
        {
            NumSet ns1 = new NumSet(8, 4, 2, 1, 0);

            Assert.IsFalse(ns1.Equals(42)); 
        }

        [TestMethod]
        public void Equals_EqualSets_True()
        {
            NumSet ns1 = new NumSet(8, 4, 2, 1, 0);
            NumSet ns2 = new NumSet(1, 0, 2, 8, 4);

            bool res = ns1.Equals(ns2);

            Assert.IsTrue(res); 
        } 

        [TestMethod]
        public void Equals_SameSizeNotEqualSets_False()
        {
            NumSet ns1 = new NumSet(8, 4, 2, 1, 0);
            NumSet ns2 = new NumSet(1, 33, 2, 8, 4);

            bool res = ns1.Equals(ns2);

            Assert.IsFalse(res); 
        } 


        [TestMethod]
        public void GetHashCode_EqualSets_EqualHashCode()
        {
            NumSet ns1 = new NumSet(8, 4, 2, 1, 0);
            NumSet ns2 = new NumSet(1, 0, 2, 8, 4);

            Assert.AreEqual(ns1.GetHashCode(), ns2.GetHashCode()); 
        }

        [TestMethod]
        public void GetHashCode_set_EqualSumOfElementsPlusLength()
        {
            var arr = new int[]{8, 4, 2, 1, 0};
            NumSet ns = new NumSet(arr);

            int res = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                res += arr[i];
            }
            res += arr.Length;

            Assert.AreEqual(res, ns.GetHashCode()); 
        }


        [TestMethod]
        public void EqualOperator_BothNull_True()
        {
           NumSet? ns1 = null;
           NumSet? ns2 = null;

            Assert.IsTrue((ns1!)==(ns2!)); 
        }

        [TestMethod]
        public void EqualOperator_FirstNull_False()
        {
           NumSet? ns1 = null;
           NumSet? ns2 = new NumSet(8, 4, 2, 1, 0);

            Assert.IsFalse((ns1!)==(ns2!)); 
        }

         [TestMethod]
        public void EqualOperator_Equal_True()
        {
           NumSet? ns1 = new NumSet(8, 4, 2, 1, 0);
           NumSet? ns2 = new NumSet(1, 0, 2, 8, 4);

            Assert.IsTrue(ns1==ns2); 
        }

         [TestMethod]
        public void EqualOperator_NotEqual_False()
        {
           NumSet? ns1 = new NumSet(8, 4, 2, 1, 0);
           NumSet? ns2 = new NumSet(1, 0, 2, 8, 3);

            Assert.IsFalse(ns1==ns2); 
        }

         [TestMethod]
        public void NotEqualOperator_Equal_False()
        {
           NumSet? ns1 = new NumSet(8, 4, 2, 1, 0);
           NumSet? ns2 = new NumSet(1, 0, 2, 8, 4);

            Assert.IsFalse(ns1!=ns2); 
        }

         [TestMethod]
        public void NotEqualOperator_NotEqual_True()
        {
           NumSet? ns1 = new NumSet(8, 4, 2, 1, 0);
           NumSet? ns2 = new NumSet(1, 0, 2, 8, 3);

            Assert.IsTrue(ns1!=ns2); 
        }

        [TestMethod]
        public void ToArray_ValidSet_Equal()
        {
            var arr = new int[]{8, 4, 2, 1, 0};
            NumSet ns = new NumSet(arr);

            bool res = Enumerable.SequenceEqual(arr, ns.ToArray());
            Assert.IsTrue(res); 
        }

        [TestMethod]
        public void ToString_ValidSet_Equal()
        {
            var arr = new int[]{8, 4, 2, 1, 0};
            NumSet ns = new NumSet(arr);

            Assert.AreEqual("{8, 4, 2, 1, 0}", ns.ToString()); 
        }
    }
}