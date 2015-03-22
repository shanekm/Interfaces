namespace IDisposableProject
{
    using System;
    using System.Diagnostics;
    using IDisposableProject.DisposableObjects;
    using IDisposableProject.WordCounter;

    class Program
    {
        // Since we changed FolderWatcher to implement IDisposable
        // we are adding a static archiver here where we can call Dispose()
        private static FolderWatcher archiver;

        static void Main(string[] args)
        {
            // Incorrect usage - Dispose() will never be called unless you call it explicitely
            MyUnmanagedResource resources = new MyUnmanagedResource();
            resources.Method();

            // Correct usage
            using (var resource = new MyUnmanagedResource())
            {
                resource.Method();
            }

            // TAKE TWO
            // writing DatabaseState class
            using (var state = new DatabaseState())
            {
                Console.WriteLine(state.GetDate());
            }

            // Making it fail - never cleaning up
            // after a while it will throw an exception, no free connections 
            // will be available in the connection pool
            var willthrowerror = new DatabaseState();
            willthrowerror.GetDate();

            // Correct usage
            using (var s1 = new DatabaseState())
            {
                s1.GetDate();
            } // dispose will be called here

            // WCF - using is not really an option
            var s2 = new DatabaseState();
            try
            {
                s2.GetDate();
            }
            finally
            {
                s2.Dispose(); // explicit call
            }

            // TAKE THREE
            //Start();


            // TAKE FOUR
            // implementing IDisposable correctly
            using (var databaseState = new DatabaseStateIDisposable())
            {
                Console.WriteLine(databaseState.GetDate());
            }

            // testing for dispose again - same as above but excplicitely calling Dispose()
            var databaseState2 = new DatabaseStateIDisposable();
            Console.WriteLine(databaseState2.GetDate());
            databaseState2.Dispose();
            //databaseState2.GetDate();


            // TAKE FIVE
            using (UnmanagedDatabaseState ds = new UnmanagedDatabaseState())
            {
                Console.WriteLine(ds.GetDate());
            }

            // Testing Finalizer
            UnmanagedDatabaseState ds2 = new UnmanagedDatabaseState();
            Console.WriteLine(ds2.GetDate());
            // ~UnmanagedDatabaseState() will run here when program exists
            // however no managed resources will be Disposed(), only Unmanaged will be cleaned by Finalizer

        } // ~UnmanagedDatabaseState() will run here when program exists

        public static void Start()
        {
            archiver = new FolderWatcher();
            archiver.Start(@"c:\temp", "*.txt", ProcessFile);
            Console.WriteLine("Listening to c:\\temp");
        }

        // FolderWatcher now implements IDisposable
        // this is because it uses FileSystemWatcher
        // app has its own private variable for FolderWatcher()
        // that may be started and stopped
        public static void Stop()
        {
            if (archiver != null)
            {
                archiver.Dispose();
                archiver = null;
            }
        }

        private static void ProcessFile(string path)
        {
            var stopwatch = Stopwatch.StartNew();
            Console.WriteLine("Processing file: " + path);
            //...
            // perform word count and archive file
        }
    }
}
