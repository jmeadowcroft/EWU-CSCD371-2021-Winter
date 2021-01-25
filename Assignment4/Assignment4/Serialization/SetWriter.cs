using System;
using System.IO;

namespace Assignment4.Serialization
{
    public class SetWriter : IDisposable
    {
        private bool disposedValue;

        private StreamWriter Writer { get; }

        public SetWriter(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException($"'{nameof(filePath)}' cannot be null or whitespace.", nameof(filePath));
            }
            Writer = new StreamWriter(filePath);
        }

        public void WriteSet(NumSet set)
        {
            if (set is null)
            {
                throw new ArgumentNullException(nameof(set));
            }
            foreach(int value in set.GetValues())
            {
                Writer.WriteLine(value);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Writer.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
