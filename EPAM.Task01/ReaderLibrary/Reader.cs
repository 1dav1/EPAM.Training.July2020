using System.IO;

namespace ReaderLibrary
{
    // The class reads strings from a file.

    /// <include file='docs.xml' path='docs/members[@name="reader"]/Reader/*'/>
    public class Reader
    {
        /// <include file='docs.xml' path='docs/members[@name="reader"]/Path/*'/>
        public string Path { get; set; }

        /// <include file='docs.xml' path='docs/members[@name="reader"]/ReaderConstr/*'/>
        public Reader(string path = "..\\..\\..\\..\\docs\\shapes.txt")
        {
            Path = path;
        }

        /// <include file='docs.xml' path='docs/members[@name="reader"]/GetLinesFromFile/*'/>
        public string[] GetLinesFromFile(string path)
        {
            if (File.Exists(Path))
            {
                return File.ReadAllLines(Path);
            }
            else
                throw new FileNotFoundException($"File {path} is not found.");
        }
    }
}
