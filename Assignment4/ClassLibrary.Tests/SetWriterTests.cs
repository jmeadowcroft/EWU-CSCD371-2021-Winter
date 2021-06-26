using ClassLibrary.Writer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ClassLibrary.Tests
{
	namespace Writer
	{
        [TestClass]
        public class SetWriterTests
        {
            private SetWriter GetValidWriter()
            {
                string workingDirectory = System.IO.Directory.GetCurrentDirectory();
                SetWriter? writer = null;
                if (workingDirectory is not null)
                {
                    DirectoryInfo? info = Directory.GetParent(workingDirectory);
                    if (info is not null)
                    {
                        DirectoryInfo? info2 = info.Parent;//.Parent.FullName;//+ "/TestFile.txt"
                        if (info2 is not null)
                        {
                            DirectoryInfo? info3 = info2.Parent;
                            if (info3 is not null)
                            {
                                string filePath = info3.FullName + "/TestFile.txt";
                                writer = new(filePath);
                            }
                        }
                    }
                }
                if(writer is null)
                {
                    throw new NullReferenceException("Issue in GetValidWriter");
                }
                return writer;
            }
            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void Constructor_NullParam_ThrowsException()
            {
                SetWriter writer = new(null);
            }
            [TestMethod]
            [ExpectedException(typeof(FileNotFoundException))]
            public void Constructor_FileDNE_ThrowsException()
            {
                SetWriter writer = new("fakefilepath");
            }
            [TestMethod]
            public void Constructor_ValidPath_Success()
            {
                SetWriter writer = GetValidWriter();
                
                Assert.IsNotNull(writer);
            }
            [TestMethod]
            public void WriteToFile_ValidNumSet_Success()
            {
                SetWriter writer = GetValidWriter();
                int[] testArray = { 1, 2, 3, 4, 5 };
                bool success = false;

                success = writer.WriteToFile(new NumSet(testArray));

                Assert.IsTrue(success);
            }
            [TestMethod]
            public void Constructor_NullNumSet_Failure()
            {
                SetWriter writer = GetValidWriter();

                bool success = writer.WriteToFile(null);

                Assert.IsFalse(success);
            }
            [TestMethod]
            public void WriteToFile_EmptyNumSet_Success()
            {
                SetWriter writer = GetValidWriter();
                int[] testArray = {};
                NumSet testSet = new NumSet(testArray);

                bool success = writer.WriteToFile(testSet);

                Assert.IsTrue(success);
            }
        }
    }
}
