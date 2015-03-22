namespace IDisposableProject.WordCounter
{
    using System.IO;

    public class FileArchiver
    {
        public void CopyFile(string sourcePath, string targetPath)
        {
            using (var inputStream = File.OpenRead(sourcePath))
            {
                // Nested using blocks
                using (var outputStream = File.Create(targetPath))
                {
                    inputStream.CopyTo(outputStream);
                } // Will dispose outputStream here
            } // Will dispose inputStream here
        } // Both streams will be closed propertly
    }
}
