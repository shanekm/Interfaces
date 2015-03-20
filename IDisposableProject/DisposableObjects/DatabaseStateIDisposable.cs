namespace IDisposableProject.DisposableObjects
{
    using System;
    using System.Data.SqlClient;

    public class DatabaseStateIDisposable : IDisposable
    {
        // disposable resource
        protected SqlConnection connection;

        private bool disposed;

        public void Dispose()
        {
            // we are in dispose call
            // call my own dispose method()
            this.Dispose(true); 

            // let GC know that this instance has cleaned up its own resources and doesn't need to be finalized
            // ~Finilizer - no Unmanaged resources in this class
            GC.SuppressFinalize(this); 
        }

        public virtual string GetDate()
        {
            // is this instance have already been disposed?
            if (this.disposed)
            {
                // this has alredy been disposed
                throw new ObjectDisposedException("DatabaseState");
            }

            if (this.connection == null)
            {
                this.connection =
                    new SqlConnection(
                        "Data Source=(local);Initial Catalog=Pacioli_Dev;Integrated Security=SSPI;Application Name=some name here");
                this.connection.Open();
            }

            using (var command = this.connection.CreateCommand())
            {
                command.CommandText = "Select getdate()";
                return command.ExecuteScalar().ToString();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            // is this instance have already been disposed?
            if (this.disposed)
            {
                return;
            }

            // choose what needs to be cleaned up - manages vs. unmanaged resources
            // depending on what the class uses
            if (disposing)
            {
                // clean up managed resources
                if (this.connection != null)
                {
                    this.connection.Dispose();

                    // doesn't help GC - but won't go back into IF block above again
                    // since sql connection has already been disposed
                    this.connection = null; 
                }

                this.disposed = true;
            }
        }
    }
}