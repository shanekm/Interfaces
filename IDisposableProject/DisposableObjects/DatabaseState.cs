namespace IDisposableProject
{
    using System;
    using System.Data.SqlClient;

    // class using SqlConnection, it needs to implement IDisposable
    // gets datetime stamp from DB
    public class DatabaseState : IDisposable
    {
        // disposable resource
        private SqlConnection connection;

        public string GetDate()
        {
            if (connection == null)
            {
                connection = new SqlConnection("Data Source=(local);Initial Catalog=Pacioli_Dev;Integrated Security=SSPI;Application Name=some name here");
                connection.Open();
            }

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "Select getdate()";
                return command.ExecuteScalar().ToString();
            }
        }

        public void Dispose()
        {
            Console.WriteLine("Disposing SqlConnection: {0}", connection.GetHashCode());
            connection.Close();

            // call dispose on the base object!
            connection.Dispose();
        }
    }
}
