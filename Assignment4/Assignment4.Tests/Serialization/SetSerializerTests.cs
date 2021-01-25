using Assignment4.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Assignment4.Tests.Serialization
{
    [TestClass]
    public class SetSerializerTests
    {
        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        public void Constructor_InvalidInput_Throws(string filePath)
        {
            try
            {
                using SetWriter _ = new(filePath);
                Assert.Fail("Constructor did not throw an exception");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("filePath", ex.ParamName);
            }
        }

        [TestMethod]
        public void WriteSet_WithNullSet_Throws()
        {
            NumSet set = null!;
            string filePath = Path.GetRandomFileName();
            try
            {
                using SetWriter writer = new(filePath);
                var ex = Assert.ThrowsException<ArgumentNullException>(() => writer.WriteSet(set));
                Assert.AreEqual("set", ex.ParamName);
            }
            finally
            {
                DeleteFile(filePath);
            }
        }

        [TestMethod]
        public void WriteSet_WithSet_WritesData()
        {
            NumSet set = new(1, 2, 3);
            string filePath = Path.GetRandomFileName();
            try
            {
                using (SetWriter writer = new(filePath))
                {
                    writer.WriteSet(set);
                } //Must close the file so the test can read it.
                string[] lines = File.ReadAllLines(filePath);
                CollectionAssert.AreEquivalent(new[] { "1", "2", "3" }, lines);
            }
            finally
            {
                DeleteFile(filePath);
            }
        }

        [TestMethod]
        public void Dispose_MultipleCalls_IsReentrant()
        {
            string filePath = Path.GetRandomFileName();
            try
            {
                using SetWriter writer = new(filePath);
                writer.Dispose();
                //Second dispose call occurs after writer leaves scope
            }
            finally
            {
                DeleteFile(filePath);
            }
        }

        private void DeleteFile(string filePath)
        {
            try
            {
                File.Delete(filePath);
            }
            catch
            {
                // Just best effort to clean up; ignoring errors
            }
        }
    }
}
