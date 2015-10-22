using System;
using System.Collections;

namespace IEnumerableProject
{
    public class SomeList : IEnumerable
    {
        // Users should not be aware of implementation
        // Should NOT exoise its internal structure (object[]) for storing data
        //public object[] _objects;
        private static object[] _objects;

        private static int index;

        public SomeList()
        {
            _objects = new object[100];
        }
 
        public void Add(object obj)
        {
            _objects[index] = obj;
            index++;
        }

        public IEnumerator GetEnumerator()
        {
            // Will return implementation of IEnumerator
            return new MyListEnumerator();
        }

        private class MyListEnumerator : IEnumerator
        {
            private int _currentIndex = -1; 

            public object Current
            {
                get
                {
                    try
                    {
                        return _objects[_currentIndex];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }

            public bool MoveNext()
            {
                _currentIndex++;
                return (_currentIndex < index); 
            }

            public void Reset()
            {
                _currentIndex = -1;
            }
        }
    }

    // IEnumerator interaface
    //public interface IEnumerator
    //{
    //    bool MoveNext();
    //    object Current { get; }
    //    void Reset();
    //}
}