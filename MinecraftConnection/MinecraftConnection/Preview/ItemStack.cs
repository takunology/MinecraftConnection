using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MinecraftConnection.Preview
{
    public class ItemStack<T> : IList<T>, IList, IReadOnlyList<T>
    {
        private T[] _array;
        private int version = 0;
        public int Count { get; private set; } = 0;
        public int Capacity
        {
            get => _array.Length;
            set
            {
                if (value < Count) throw new ArgumentOutOfRangeException();
                if (_array.Length != value)
                {
                    var newArray = new T[value];
                    for(int i = 0; i < _array.Length; i++)
                        newArray[i] = _array[i];
                    _array = newArray;
                }
            }
        }

        bool ICollection.IsSynchronized => false;
        private object _syncRoot;
        object ICollection.SyncRoot
        {
            get
            {
                if (_syncRoot == null) System.Threading.Interlocked.CompareExchange<object>(ref _syncRoot, new object(), null);
                return _syncRoot;
            }
        }
        bool ICollection<T>.IsReadOnly => false;

        bool IList.IsFixedSize => false;
        bool IList.IsReadOnly => false;
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException();
                return _array[index];
            }
            set
            {
                if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException();
                _array[index] = value;
                version++;
            }
        }
        object IList.this[int index]
        {
            get
            {
                if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException();
                return _array[index];
            }
            set
            {
                if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException();
                try
                {
                    _array[index] = (T)value;
                }
                catch (InvalidCastException)
                {
                    throw new ArgumentException();
                }
                version++;
            }
        }

        public Enumerator GetEnumerator() => new Enumerator(this);
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public struct Enumerator : IEnumerator<T>
        {
            private readonly ItemStack<T> list;
            private readonly int version;
            private int index;
            public T Current { get; set; }
            object IEnumerator.Current
            {
                get
                {
                    if (index == 0 || index > list.Count) throw new InvalidOperationException();
                    return Current;
                }
            }
            internal Enumerator(ItemStack<T> list)
            {
                this.list = list;
                index = 0;
                version = list.version;
                Current = default;
            }
            public void Dispose() { }
            public bool MoveNext()
            {
                if (version != list.version) throw new InvalidOperationException();
                if(index < list.Count)
                {
                    Current = list._array[index];
                    index++;
                    return true;
                }
                else
                {
                    Current = default;
                    index = list.Count + 1;
                    return false;
                }
            }
            void IEnumerator.Reset()
            {
                if (version != list.version) throw new InvalidOperationException();
                Current = default;
                index = 0;
            }

        }

        private void ChangeArraySize()
        {
            var ns = _array.Length == 0 ? 4u : (uint)_array.Length * 2u;
            var newSize = ns > int.MaxValue ? int.MaxValue : (int)ns;
            Capacity = newSize;
        }

        public void Add(T item)
        {
            if (Count + 1 > _array.Length) ChangeArraySize();
            _array[Count++] = item;
            version++;
        }

        int IList.Add(object value)
        {
            if ((T)default != null && value == null) throw new ArgumentNullException();
            try
            {
                Add((T)value);
            }
            catch (InvalidCastException)
            {
                throw new ArgumentException();
            }
            return Count - 1;
        }

        public void AddRange(IEnumerable<T> collection)
        {
            foreach (var item in collection) 
                Add(item);
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count) throw new ArgumentOutOfRangeException();
            if (Count + 1 > _array.Length) ChangeArraySize();
            if (index < Count) Array.Copy(_array, index, _array, index + 1, Count - index);
            _array[index] = item;
            Count++;
            version++;
        }
        
        void IList.Insert(int index, object value)
        {
            if ((T)default != null && value == null) throw new ArgumentNullException();
            try
            {
                Insert(index, (T)value);
            }
            catch (InvalidCastException)
            {
                throw new ArgumentException();
            }
        }

        public void InsertRange(int index, IEnumerable<T> collection)
        {
            foreach (var item in collection)
                Insert(index++, item);
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public string ItemID { get; set; }
        public int ItemCount { get; set; }
        public int ItemSlot { get; set; }

        public ItemStack()
        {

        }

        public ItemStack(string ItemID, int ItemCount, int ItemSlot)
        {
            this.ItemID = ItemID;
            this.ItemCount = ItemCount;
            this.ItemSlot = ItemSlot;
        }


    }
}
