using System.Collections;
using System.Collections.Generic;

namespace IEnumerableProject
{
    public class YetAnotherList<T> : IEnumerable<T>
    {
        private object[] _objects;
        private static int index;

        public YetAnotherList()
        {
            _objects = new object[100];
        }
 
        public void Add(object obj)
        {
            _objects[index] = obj;
            index++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T t in _objects)
            {
                // Lets check for end of list (its bad code since we used arrays)
                if (t == null)
                {
                    break;
                }

                // Return the current element and then on next function call 
                // resume from next element rather than starting all over again;
                yield return t;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            // Lets call the generic version here
            return this.GetEnumerator();
        }
    }
}