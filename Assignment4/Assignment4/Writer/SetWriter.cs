using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Assignment4.Writer
{
    public sealed class SetWriter: IDisposable
    {
        
        private bool _DisposedValue = false;
        
        private StreamWriter? writer;

        public StreamWriter Writer{
            get
            {
                return writer!;
            }
            private set => writer = value??throw new ArgumentNullException();
        }

        public SetWriter(string filePath)
        {
             if(filePath is null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            this.writer = new StreamWriter(filePath);
        }

        public void WriteSet(NumSet numSet)
        {
            if(numSet is null)
            {
                throw new ArgumentNullException(nameof(numSet));
            }

            this.Writer.WriteLine(numSet.ToString());
        }
   

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        private void Dispose(bool disposing)
        {
            if (!_DisposedValue)
            {
                if (disposing) {
                    Writer.Dispose();
                }

                _DisposedValue = true;
            }
        }
    }
}