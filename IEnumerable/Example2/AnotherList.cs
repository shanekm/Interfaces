using System.Collections;
using System.Linq;

namespace IEnumerableProject
{
    public class AnotherList : IEnumerable
    {
        // Users should not be aware of implementation
        // Should NOT exoise its internal structure (object[]) for storing data
        //public object[] _objects;
        private object[] _objects;

        private static int index;

        public AnotherList()
        {
            _objects = new object[100];
        }
 
        public void Add(object obj)
        {
            _objects[index] = obj;
            index++;
        }

        // IEnumerable Member
        public IEnumerator GetEnumerator()
        {
            foreach (object o in _objects)
            {
                // Lets check for end of list (its bad code since we used arrays)
                if (o == null)
                {
                    break;
                }

                // Return the current element and then on next function call 
                // resume from next element rather than starting all over again;
                yield return o;
            }
        }
    }
}