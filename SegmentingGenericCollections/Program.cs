using System;
using System.Collections.Generic;
using System.Linq;

namespace SegmentingGenericCollections
{
    public interface IMyInterface
    {
        void SendToICollection(ICollection<int> list);
        void SendToIEnumerable(IEnumerable<int> list);
        void SendToIList(IList<int> list);

        IEnumerable<int> GetIEnumerable(ICollection<int> list);
        ICollection<int> GetICollection(ICollection<int> list);
        IList<int> GetIList(ICollection<int> list);
    }

    public class MyImpl : IMyInterface
    {
        public void SendToICollection(ICollection<int> list)
        {
//            throw new NotImplementedException();
        }

        public void SendToIEnumerable(IEnumerable<int> list)
        {
//            throw new NotImplementedException();
        }

        public void SendToIList(IList<int> list)
        {
//            throw new NotImplementedException();
        }

        public IEnumerable<int> GetIEnumerable(ICollection<int> list)
        {
            return list.AsEnumerable();
        }

        public ICollection<int> GetICollection(ICollection<int> list)
        {
            return list;
        }

        public IList<int> GetIList(ICollection<int> list)
        {
            return list.ToList();
        } 
    }

    class Program
    {
        static void Main(string[] args)
        {
            IMyInterface service = new MyImpl();

            // Send in Most Generic (IEnumerable => ICollection => IList)
            ICollection<int> collection = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
            IEnumerable<int> enumerable = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 }.AsEnumerable();
            IList<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 }.ToList();

            // Can not send IEnumerable or ICollection to IList
//            service.SendToIList(collection);  // error
//            service.SendToIList(enumerable);  // error
            service.SendToIList(list);        // ok

            // Can not send IEnumerable to ICollection
//            service.SendToICollection(enumerable);
//            service.SendToICollection(list);
            service.SendToICollection(collection);

            // Can send all three to IEnumerable
            service.SendToIEnumerable(collection);
            service.SendToIEnumerable(list);
            service.SendToIEnumerable(enumerable);

            // Return Most Specific to avoid casting
            ICollection<int> test1 = service.GetIEnumerable(collection) as ICollection<int>; // Need to cast
            ICollection<int> test2 = service.GetICollection(collection); 
            ICollection<int> test3 = service.GetIList(collection);
            IList<int> test5 = service.GetIList(collection);
        }
    }
}
