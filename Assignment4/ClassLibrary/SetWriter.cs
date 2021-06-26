using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    namespace Writer
    {
        public class SetWriter : IDisposable
        {
			private string FilePath;
			private StreamWriter FileWriter;
            private bool disposed = false;

            public SetWriter(string? filePath)
            {
				FilePath = filePath ?? throw new ArgumentNullException(nameof(filePath));
				if (File.Exists(filePath))
                {
					FileWriter = new StreamWriter(filePath);
				}
                else
                {
                    throw new FileNotFoundException(filePath);
                }


            }

			public bool WriteToFile(NumSet? numSet)
            {
                bool success = false;
                if (numSet is not null)
                {
                    FileWriter.Write(numSet.ToString());
                    success = true;
				}
                return success;
            }

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    if (disposing)
                    {
                        FileWriter.Dispose();
                    }

                    disposed = true;
                }

            }

        }
    }
}
