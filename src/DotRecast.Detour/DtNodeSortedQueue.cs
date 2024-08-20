using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DotRecast.Detour
{
    public class DtNodeSortedQueue
    {
        private readonly SortedList<float, DtNode> _items;

        public DtNodeSortedQueue()
        {
            _items = new SortedList<float, DtNode>(Comparer<float>.Create(Comparer));
        }
        
        private int Comparer(float a, float b)
        {
            return a.CompareTo(b) * -1;
        }

        public int Count()
        {
            return _items.Count;
        }

        public bool IsEmpty()
        {
            return 0 == _items.Count;
        }

        public void Clear()
        {
            _items.Clear();
        }

        public DtNode Peek()
        {
            return _items.Values[_items.Count - 1];
        }

        public DtNode Dequeue()
        {
            var node = Peek();
            _items.RemoveAt(_items.Count - 1);
            return node;
        }

        public void Enqueue(DtNode item)
        {
            if (null == item)
                return;

            _items.Add(item.total, item);
        }

        public void Remove(DtNode item)
        {
            if (null == item) return;

            var values = _items.Values;
            for (int i = 0; i < values.Count; i++)
            {
                DtNode existingItem = values[i];
                if (item.Equals(existingItem))
                {
                    _items.RemoveAt(i);
                    return;
                }
            }
        }
    }
}