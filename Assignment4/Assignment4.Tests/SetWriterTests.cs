///Users/alexthornton/Documents/College/CSCD371/EWU-CSCD371-2021-Winter/Assignment4/testFile.txt
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using Assignment4.Writer;

namespace Assignment4.Tests
{
    [TestClass]
    public class SetWriterTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetWriter_NullFilePath_ArgumentNullException()
        {
            string path = Path.GetTempFileName();

            NumSet ns1 = new NumSet(12, 43, 6, 19, 2);

            using (SetWriter sw = new SetWriter(null!))
            sw.WriteSet(ns1);
        }

        [TestMethod]
        public void SetWriter_Path_SavesStreamWriter()
        {
            string path = Path.GetTempFileName();

            using(SetWriter setWriter = new SetWriter(path))
            using(StreamWriter streamWriter = new StreamWriter(path))

            Assert.AreEqual(setWriter.Writer.GetType(), streamWriter.GetType());
        }

        [TestMethod]
        public void WriteSet_ValidSet_EqualResult()
        {
            string path = Path.GetTempFileName();

            NumSet ns1 = new NumSet(12, 43, 6, 19, 2);

            using (SetWriter sw = new SetWriter(path))
            sw.WriteSet(ns1);

            string lastLine = File.ReadLines(path).Last();

            Assert.AreEqual(lastLine, "{12, 43, 6, 19, 2}");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WriteSet_NullSet_EqualResult()
        {
            string path = Path.GetTempFileName();

            NumSet ns1 = new NumSet(null!);

            using (SetWriter sw = new SetWriter(path))
            sw.WriteSet(ns1);

        }

    }
}