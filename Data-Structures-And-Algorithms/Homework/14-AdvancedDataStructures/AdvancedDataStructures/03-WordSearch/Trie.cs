using System.Collections.Generic;
using System.Linq;

namespace _03_WordSearch
{
    public class Trie
    {
        private const char TerminatorChar = '$';
        private const char RootChar = '^';

        private readonly Node root;

        public Trie()
        {
            this.root = new Node(RootChar, 0, null);
        }

        public Node Prefix(string str)
        {
            var currentNode = this.root;
            var result = currentNode;

            foreach (var ch in str)
            {
                currentNode = currentNode.FindChildNode(ch);
                if (currentNode == null)
                {
                    break;
                }

                result = currentNode;
            }

            return result;
        }

        public Node CompletePrefix(string str)
        {
            var currentNode = this.root;
            var result = currentNode;

            foreach (var ch in str)
            {
                currentNode = currentNode.FindChildNode(ch);
                if (currentNode == null)
                {
                    return null;
                }

                result = currentNode;
            }

            return result;
        }

        public bool Search(string str)
        {
            var prefix = this.Prefix(str);
            return prefix.Depth == str.Length && prefix.FindChildNode(TerminatorChar) != null;
        }

        public int CountWord(string word)
        {
            var prefix = this.CompletePrefix(word);
            if (prefix == null)
            {
                return 0;
            }

            return prefix.Children.Count(x => x.Value == TerminatorChar);
        }

        public void InsertRange(IEnumerable<string> items)
        {
            foreach (var str in items)
            {
                this.Insert(str);
            }
        }

        public void Insert(string str)
        {
            var commonPrefix = this.Prefix(str);
            var current = commonPrefix;

            for (var i = current.Depth; i < str.Length; i++)
            {
                var newNode = new Node(str[i], current.Depth + 1, current);
                current.Children.Add(newNode);
                current = newNode;
            }

            current.Children.Add(new Node(TerminatorChar, current.Depth + 1, current));
        }

        public void Delete(string str)
        {
            if (this.Search(str))
            {
                var node = this.Prefix(str).FindChildNode(TerminatorChar);

                while (node.IsLeaf())
                {
                    var parent = node.Parent;
                    parent.DeleteChildNode(node.Value);
                    node = parent;
                }
            }
        }
    }
}
