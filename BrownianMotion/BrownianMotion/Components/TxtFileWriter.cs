using System.Collections.Generic;
using System.IO;

namespace BrownianMotion
{
    public class TxtFileWriter
    {
        private FileInfo _fileInfo;
        private StreamWriter _textWriter;

        public TxtFileWriter(string file_path)
        {
            _fileInfo = new FileInfo(file_path);
        }

        public void Write(List<int> data)
        {
            _textWriter = _fileInfo.CreateText();

            foreach(int d in data)
            {
                _textWriter.WriteLine(d.ToString());
            }

            _textWriter.Close();
        }

    }
}
