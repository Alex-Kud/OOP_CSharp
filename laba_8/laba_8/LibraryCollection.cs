using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_8
{
    public class LibraryCollection<T> : ICollection<T>
    {
        protected LinkedList<T> List { get; set; } = new LinkedList<T>();
        private bool _disposed = false;
        public int Count => List.Count;

        public bool IsReadOnly { get; }

        public LibraryCollection()
        {
            List = new LinkedList<T>();
        }

        public LibraryCollection(T[] items)
        {
            foreach (T item in items)
            {
                this.Add(item);
            }
        }

        public void Add(T item)
        {
           List.AddLast(item);
        }

        public void Clear()
        {
            List.Clear();
        }

        public bool Contains(T item)
        {
            return List.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(array));
            }

            if (array.LongLength > arrayIndex + List.Count)
            {
                throw new ArgumentException();
            }

            foreach (var item in List.Select((item, ind) => (item: item, ind: ind + arrayIndex)))
            {
                array[item.ind] = item.item;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return List.GetEnumerator();
        }

        public bool Remove(T item)
        {
            return List.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary> Деструктор</summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary> Деструктор</summary>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                // Освобождаем управляемые ресурсы
            }

            // освобождаем неуправляемые объекты
            _disposed = true;
        }

        /// <summary> Деструктор</summary>
        ~LibraryCollection()
        {
            Dispose(false);
        }
    }
}
