using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionApp
{
    class _ListInt:IEnumerable
    {
        private const int _defaultCapacity = 4;
        private int[] _items;
        private int _size;
        private int _version;
        static readonly int[] _emptyArray = new int[0];
        public _ListInt()
        {
            _items = _emptyArray;
        }
        public _ListInt(int capacity)
        {
            if (capacity == 0)
                _items = _emptyArray;
            else
                _items = new int[capacity];
        }
        public int Capacity
        {
            get
            {
                return _items.Length;
            }
            set
            {
                if (value != _items.Length)
                {
                    if (value > 0)
                    {
                        int[] newItems = new int[value];
                        if (_size > 0)
                        {
                            Array.Copy(_items, 0, newItems, 0, _size);
                        }
                        _items = newItems;
                    }
                    else
                    {
                        _items = _emptyArray;
                    }
                }
            }
        }
        public int Count
        {
            get
            {
                return _size;
            }
        }
        public void Add(int item)
        {
            if (_size == _items.Length)
            {
                EnsureCapacity(_size + 1);
            }
            _items[_size++] = item;
            _version++;
        }
        private void EnsureCapacity(int min)
        {
            if (_items.Length < min)
            {
                int newCapacity = _items.Length == 0 ? _defaultCapacity : _items.Length * 2;
                if ((uint)newCapacity > 0X7FEFFFFF)
                {
                    newCapacity = 0X7FEFFFFF;
                }
                if (newCapacity < min)
                {
                    newCapacity = min;
                }
                Capacity = newCapacity;
            }
        }
        public override string ToString()
        {
            return $"Count= {Count}";
        }
        public int this[int i]
        {
            get
            {
                return _items[i];
            }
            set
            {
                _items[i] = value;

            }
        }
        public void Clear()
        {
            if (_size > 0)
            {
                Array.Clear(_items, 0, _size);
                _size = 0;

            }
            _version++;
        }
        public _ListInt GetRange(int index, int count)
        {
            _ListInt list = new _ListInt(count);
            Array.Copy(_items, count, list._items, 0, _size);
            list._size = count;
            return list;
        }
        public int IndexOf(int item)
        {
            return Array.IndexOf(_items, item, 0, _size);
        }
        public void Insert(int index, int item)
        {
            if (_size == _items.Length)
            {
                EnsureCapacity(_size + 1);
            }
            if (index < _size)
            {
                Array.Copy(_items, index, _items, index + 1, _size - index);
            }
            _items[index] = item;
            _size++;
            _version++;
        }
        public bool Remove(int item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }
            return false;
        }
        public void RemoveAt(int index)
        {
            _size--;
            if (index < _size)
            {
                Array.Copy(_items, index + 1, _items, index, _size - index);
            }
            _items[_size] = 0;
            _version++;
        }
        public void RemoveRange(int index, int count)
        {
            if (count > 0)
            {
                int i = _size;
                _size -= count;
                if (index < _size)
                {
                    Array.Copy(_items, index + count, _items, index, _size - index);
                }
                Array.Clear(_items, _size, count);
                _version++;
            }
        }
        public void Reverse()
        {
            Reverse(0, Count);
        }
        public void Reverse(int index, int count)
        {
            Array.Reverse(_items, index, count);
            _version++;
        }
        public int LastIndexOf(int item)
        {

            if (_size == 0)
            {  
                return -1;
            }
            else
            {
                return LastIndexOf(item, _size - 1, _size);
            }
        }
        public int LastIndexOf(int item, int index, int count)
        {
            return Array.LastIndexOf(_items, item, index, count);

        }

        public IEnumerator GetEnumerator()
        {
            return new IntIEnumerator(_items, _size);
        }
    }
    public class IntIEnumerator : IEnumerator
    {
        public IntIEnumerator(int[] item,int seize)
        {
            _item = item;
            _seize = seize;

        }
        int[] _item;
        int _seize;
        int count = 0;
        public object Current => _item[count++];

        public bool MoveNext()
        {
            return count < _seize;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
