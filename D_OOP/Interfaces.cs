using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_OOP
{
    public interface IBaseCollection
    {
        void Add(object item);
        void Remove(object item);
    }

    public static class BaseCollectionExt
    {
        public static void AddRange(this IBaseCollection collection, IEnumerable<object> objects)
        {
            foreach (object obj in objects)
            {
                collection.Add(obj);
            }
        }
    }

    public class BaseList : IBaseCollection
    {
        private object[] items;
        private int count = 0;
        public BaseList(int initialCapacity)
        {
            items = new object[initialCapacity];
        }
        public void Add(object item)
        {
            items[count++] = item;
        }

        public void Remove(object item)
        {
            items[count--] = null;
        }
    }
}
