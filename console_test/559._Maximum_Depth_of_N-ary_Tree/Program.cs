using System;
using System.Collections.Generic;

namespace _559_Maximum_Depth_of_N_ary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            int?[] nodes = { 1, null, 2, 3, 4, 5, null, null, 6, 7, null, 8, null, 9, 10, null, null, 11, null, 12, null, 13, null, null, 14 };
            Tree tree = new Tree();
            int idx = 0;
            while (idx < nodes.Length)
            {
                tree.AddLevel(nodes, ref idx);
                tree.PrintLeaves();
                Console.WriteLine(" Hello World! "+ idx);
            }
        }
    }

    public class Tree
    {
        public Node root;
        public IList<Node> _leaves;

        public void AddLevel(int?[] nodes, ref int idx)
        {
            if (nodes.Length == 0 || idx == nodes.Length)
            {
                return;
            }
            if (_leaves == null)
            {
                _leaves = new List<Node>
                {
                    new Node(nodes[idx].GetValueOrDefault())
                };
                idx += 2;
            }
            else
            {
                IList<Node> nextLevelLeaves = new List<Node>();
                IEnumerator<Node> leafEnumerator = GetNodes();
                while (leafEnumerator.MoveNext() && idx < nodes.Length)
                {
                    Node curChild = leafEnumerator.Current;
                    while (idx < nodes.Length && nodes[idx]!=null)
                    {
                        if(curChild.children == null)
                        {
                            curChild.children = new List<Node>();
                        }
                        Node node = new Node(nodes[idx].GetValueOrDefault());
                        curChild.children.Add(node);
                        nextLevelLeaves.Add(node);
                        idx++;
                    }
                    idx++;
                }
                _leaves = nextLevelLeaves;
            }
        }

        public void PrintLeaves()
        {
            foreach(Node node in _leaves)
            {
                Console.Write(node.val);
            }
        }

        public IEnumerator<Node> GetNodes()
        {
            foreach (Node node in _leaves)
            {
                yield return node;
            }
        }
    }

    public class Node {
        public int val;
        public IList<Node> children;

        public Node(int _val) {
            val = _val;
        }

        public Node(int _val, IList<Node> _children) {
            val = _val;
            children = _children;
        }
    }

    public class Solution
    {
        public int MaxDepth(Node root)
        {
            return 0;
        }
    }
}
