using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace DotRecast.Detour
{
    public class DtNodeSortedQueue
    {
        private bool _dirty;
        private readonly ArrayList _items;
        private readonly Comparer<DtNode> _comparer;

        public DtNodeSortedQueue()
        {
            _items = new ArrayList();
            _comparer = Comparer<DtNode>.Create(Comparer);
        }
        
        private int Comparer(DtNode a, DtNode b)
        {
            return a.total.CompareTo(b.total) * -1;
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
            _dirty = false;
        }
        
        private void Balance()
        {
            if (_dirty)
            {
                _items.Sort(_comparer); // reverse
                _dirty = false;
            }
        }

        public DtNode Peek()
        {
            Balance();
            return (DtNode)_items[^1];
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

            _items.Add(item);
            _dirty = true;
        }

        public void Remove(DtNode item)
        {
            if (null == item) return;

            for (int i = _items.Count - 1; i >= 0; i--)
            {
                DtNode existingItem = (DtNode)_items[i];
                if (item.Equals(existingItem))
                {
                    _items.RemoveAt(i);
                    return;
                }
            }
        }
    }
}