/*
Copyright (c) 2009-2010 Mikko Mononen memon@inside.org
recast4j copyright (c) 2015-2019 Piotr Piastucki piotr@jtilia.org
DotRecast Copyright (c) 2023 Choi Ikpil ikpil@naver.com

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

using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DotRecast.Detour
{
    public class DtNodePool
    {
        private readonly Dictionary<long, DtNode> m_map = new Dictionary<long, DtNode>();
        private readonly List<DtNode> m_nodes = new List<DtNode>();
        private readonly Stack<DtNode> _nodesRealPool = new Stack<DtNode>();

        public DtNodePool()
        {
        }

        public void Clear()
        {
            foreach (var dtNode in m_nodes)
            {
                dtNode.cost = 0;
                dtNode.pidx = 0;
                _nodesRealPool.Push(dtNode);
            }
            
            m_nodes.Clear();
            m_map.Clear();
        }
        

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DtNode FindNode(long id)
        {
            var hasNode = m_map.TryGetValue(id, out var node);
            ;
            if (hasNode)
            {
                return node;
            }

            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DtNode GetNode(long id, int state)
        {
            var hasNode = m_map.TryGetValue(id, out var node);
            if (hasNode)
            {
                if (node.state == state)
                {
                    return node;
                }
            }

            return Create(id, state);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected DtNode Create(long id, int state)
        {
            if (_nodesRealPool.TryPop(out var newNode))
            {
                newNode.index = m_nodes.Count + 1;
                newNode.id = id;
                newNode.state = state;
                newNode.pos = default;
                newNode.cost = default;
                newNode.total = default;
                newNode.pidx = default;
                newNode.flags = default;
                
                m_nodes.Add(newNode);
                m_map.Add(id, newNode);
                return newNode;
            }

            DtNode node = new DtNode(m_nodes.Count + 1);
            node.id = id;
            node.state = state;
            m_nodes.Add(node);
            m_map.Add(id, node);
            return node;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetNodeIdx(DtNode node)
        {
            return node != null ? node.index : 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DtNode GetNodeAtIdx(int idx)
        {
            return idx != 0 ? m_nodes[idx - 1] : null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DtNode GetNode(long refs)
        {
            return GetNode(refs, 0);
        }
    }
}
