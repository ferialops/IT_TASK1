using System;
using System.Collections.Generic;

namespace SetApp.Models
{
    public class Set<T>
    {
        private HashSet<T> _items;

        public Set()
        {
            _items = new HashSet<T>();
        }

        public int Count => _items.Count;

        public bool IsEmpty => _items.Count == 0;

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public T[] ToArray()
        {
            return new List<T>(_items).ToArray();
        }

        public bool Contains(T item)
        {
            return _items.Contains(item);
        }
    }
}