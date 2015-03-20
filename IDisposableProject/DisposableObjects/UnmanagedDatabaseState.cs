namespace IDisposableProject.DisposableObjects
{
    using System;
    using System.Data.SqlClient;
    using System.Runtime.InteropServices;

    // Without THIS class's dispose method when Dispose() is called it will 
    // execute Dispose() of the base class and NOT this one - since this one 
    // doesn't have it's Dispose() method yet

    // Must include Dispose() because base class implements IDisposable
    // and also inheriting from a base class that does implement IDisposable
    public class UnmanagedDatabaseState : DatabaseStateIDisposable
    {
        private SqlCommand command;

        private IntPtr unmanagedPointer;

        public override string GetDate()
        {
            var sqlDate = base.GetDate();
            if (command == null)
            {
                command = connection.CreateCommand();
            }

            if (unmanagedPointer == IntPtr.Zero)
            {
                // Pointer to memory (100MB)
                unmanagedPointer = Marshal.AllocHGlobal(100 * 1024 * 1024);
            }

            return sqlDate;
        }

        // Fixing Dispose() of child class, dispose SqlCommand
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // clean up managed resources
                if (command != null)
                {
                    command.Dispose();
                    command = null;
                }
            }

            // clean up unmanaged resources
            // Part of Finalizer
            if (unmanagedPointer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(unmanagedPointer);
                unmanagedPointer = IntPtr.Zero;
            }

            // call base Dispose() method - to clean up its resources
            base.Dispose(disposing);
        }

        // Finalizer - called by GC
        // GC collection
        ~UnmanagedDatabaseState()
        {
            // clean up ONLY unmaganed resources
            this.Dispose(false);
        }
    }
}
