namespace IDisposableProject.WordCounter
{
    using System;
    using System.IO;
    using System.Threading;

    public class FolderWatcher
    {
        public void Start(string path, string filter, Action<string> onFileCreated)
        {
            var fileSystemWatcher = new FileSystemWatcher(path, filter);
            fileSystemWatcher.Created += (x, y) =>
                {
                    Thread.Sleep(1000); // Hack
                    Console.WriteLine("New file created: " + y.Name);
                    onFileCreated(y.FullPath);
                };

            fileSystemWatcher.EnableRaisingEvents = true;
        }
    }
}
