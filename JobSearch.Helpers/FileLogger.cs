using System.IO;

namespace JobSearch.Helpers
{
    public class FileLogger
    {
        private readonly string _filePath;

        public FileLogger(string filePath)
        {
            this._filePath = filePath;
        }

        public void Write(string text)
        {
            File.WriteAllText(_filePath, text);
        }

        public void Write(string text, bool append)
        {
            File.AppendAllText(_filePath, text);
        }
    }
}
