using System;
using System.IO;

namespace Project_Console_Driver
{
    public class ConsoleInputWriter
    {
        StreamWriter _streamWriter = null;

        public void WriteLine(object text)
        {
            if (_streamWriter != null && _streamWriter.BaseStream != null)
            {
                _streamWriter.WriteLine(text);
            }
            else
            {
                Console.WriteLine(text);
            }
        }

        internal void SetStream(StreamWriter writer)
        {
            _streamWriter = writer;
        }

        internal void Dispose()
        {
            _streamWriter.Close();
            _streamWriter.Dispose();
        }
    }
}