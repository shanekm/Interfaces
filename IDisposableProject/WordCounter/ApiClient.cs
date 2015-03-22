namespace IDisposableProject
{
    using System;

    // Arbitrary api client
    // Shows usage of disposable when calling WCF client
    public class ApiClient
    {
        public int GetWordCount(string input)
        {
            var wordCount = 0;

            // WCF client 
            var client = new WordCountServiceClient();

            try
            {
                wordCount = client.GetWordCount();
                client.Close();
            }
            catch (Exception)
            {
                // Abort if failed
                client.Abort();
            }
            finally
            {
                ((IDisposable)client).Dispose();
            }

            return wordCount;
        }
    }
}
