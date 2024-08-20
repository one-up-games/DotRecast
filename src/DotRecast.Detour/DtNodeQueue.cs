/*
Copyright (c) 2009-2010 Mikko Mononen memon@inside.org
recast4j copyright (c) 2015-2019 Piotr Piastucki piotr@jtilia.org
DotRecast Copyright (c) 2023-2024 Choi Ikpil ikpil@naver.com

This software is provided 'as-is', without any express or implied
warranty.  In no event will the authors be held liable for any damages
arising from the use of this software.
Permission is granted to anyone to use this software for any purpose,
including commercial applications, and to alter it and redistribute it
freely, subject to the following restrictions:
1. The origin of this software must not be misrepresented; you must not
 claim that you wrote the original software. If you use this software
 in a product, an acknowledgment in the product documentation would be
 appreciated but is not required.
2. Altered source versions must be plainly marked as such, and must not be
 misrepresented as being the original software.
3. This notice may not be removed or altered from any source distribution.
*/

namespace DotRecast.Detour
{
    public class DtNodeQueue
    {
        private readonly DtNodeSortedQueue m_heap;

        public DtNodeQueue()
        {
            m_heap = new DtNodeSortedQueue();
        }

        public int Count()
        {
            return m_heap.Count();
        }

        public void Clear()
        {
            m_heap.Clear();
        }

        public DtNode Peek()
        {
            return m_heap.Peek();
        }

        public DtNode Pop()
        {
            return m_heap.Dequeue();
        }

        public void Push(DtNode node)
        {
            m_heap.Enqueue(node);
        }

        public void Modify(DtNode node)
        {
            m_heap.Remove(node);
            Push(node);
        }

        public bool IsEmpty()
        {
            return m_heap.IsEmpty();
        }
    }
}
