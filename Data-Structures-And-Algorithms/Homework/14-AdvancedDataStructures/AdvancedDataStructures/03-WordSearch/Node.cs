using System.Collections.Generic;
using System.Linq;

namespace _03_WordSearch
{
    public class Node
    {
        public Node(char value, int depth, Node parent)
        {
            this.Value = value;
            this.Children = new List<Node>();
            this.Depth = depth;
            this.Parent = parent;
        }

        public char Value { get; set; }

        public List<Node> Children { get; set; }

        public Node Parent { get; set; }

        public int Depth { get; set; }

        public bool IsLeaf()
        {
            return this.Children.Count == 0;
        }

        public Node FindChildNode(char ch)
        {
            return this.Children.FirstOrDefault(child => child.Value == ch);
        }

        public void DeleteChildNode(char ch)
        {
            for (var i = 0; i < this.Children.Count; i++)
            {
                if (this.Children[i].Value == ch)
                {
                    this.Children.RemoveAt(i);
                }
            }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
