namespace IDisposableProject.WordCounter
{
    using System;
    using System.IO;
    using System.Threading;

    // TAKE TWO 
    // Implementing IDisposable on FolderWatcher class
    // Adding FileSystemWatcher private variable
    public class FolderWatcher : IDisposable
    {
        // TAKE ONE 
        // FileSystemWatcher is never disposed of
        //public void Start(string path, string filter, Action<string> onFileCreated)
        //{
        //    var fileSystemWatcher = new FileSystemWatcher(path, filter);
        //    fileSystemWatcher.Created += (x, y) =>
        //    {
        //        Thread.Sleep(1000); // Hack
        //        Console.WriteLine("New file created: " + y.Name);
        //        onFileCreated(y.FullPath);
        //    };

        //    fileSystemWatcher.EnableRaisingEvents = true;
        //}

        // TAKE TWO
        // To implement IDisposable we need a variable that would hold FileSystemWatcher

        private FileSystemWatcher fileSystemWatcher;

        public void Start(string path, string filter, Action<string> onFileCreated)
        {
            this.fileSystemWatcher = new FileSystemWatcher(path, filter);
            this.fileSystemWatcher.Created += (x, y) =>
            {
                Thread.Sleep(1000); // Hack
                Console.WriteLine("New file created: " + y.Name);
                onFileCreated(y.FullPath);
            };

            this.fileSystemWatcher.EnableRaisingEvents = true;
        }

        public void Dispose()
        {
            this.Dispose(disposing: true); 
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Dispose managed resources
            if (disposing && this.fileSystemWatcher != null)
            {
                this.fileSystemWatcher.Dispose();
                this.fileSystemWatcher = null;
            }
        }
    }
}
