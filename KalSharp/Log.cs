using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace KalSharp
{
    class Log
    {
        private TextWriter writer;

        public Log(string FileName)
        {
            Stream stream = new FileStream(FileName, FileMode.OpenOrCreate);
            writer = new StreamWriter(stream);
        }

        public void LogMessage(string Message)
        {
            writer.WriteLine(Message);
            writer.Flush();
        }

    }
}
