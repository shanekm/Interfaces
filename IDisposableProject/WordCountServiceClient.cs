using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDisposableProject
{
    public class WordCountServiceClient
    {
        public void Abort()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {

            throw new NotImplementedException();
        }

        public int GetWordCount()
        {
            throw new NotImplementedException();
            return 1;
        }

        internal IDisposable Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
