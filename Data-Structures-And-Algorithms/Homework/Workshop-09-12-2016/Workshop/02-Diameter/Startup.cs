using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_Diameter
{
    public class Startup
    {
        // TODO: 4/100
        private static void Main()
        {
            var graph = new Graph();
            int numberOfNodes = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfNodes - 1; i++)
            {
                var edges = Console.ReadLine().Split(' ');

                var firstNodeId = int.Parse(edges[0]);
                var secondNodeId = int.Parse(edges[1]);
                var weight = ulong.Parse(edges[2]);

                graph.AddConnection(firstNodeId, secondNodeId, weight, true);
            }

            ulong max = ulong.MinValue;
            foreach (var node in graph.EdgeNodes)
            {
                var current = LongestPathFromNode(0, node, new bool[numberOfNodes]);
                if (current > max)
                {
                    max = current;
                }
            }

            Console.WriteLine(max);
        }

        private static int previousNodeId = int.MinValue;

        private static ulong LongestPathFromNode(ulong currentSum, Node currentNode, bool[] traversed)
        {
            foreach (var connection in currentNode.Connections)
            {
                if (traversed[connection.Target.Id] || previousNodeId == currentNode.Id)
                {
                    continue;
                }

                traversed[currentNode.Id] = true;
                currentSum += LongestPathFromNode(connection.Distance, connection.Target, traversed);
                traversed[currentNode.Id] = false;

                previousNodeId = currentNode.Id;
            }

            return currentSum;
        }
    }

    public class Node
    {
        private readonly IList<Edge> connections;

        public Node(int id)
        {
            this.Id = id;
            this.connections = new List<Edge>();
        }

        public int Id { get; private set; }

        public IEnumerable<Edge> Connections
        {
            get { return this.connections; }
        }

        public void AddConnection(Node targetNode, ulong distance, bool twoWay)
        {
            if (targetNode == null)
            {
                throw new ArgumentNullException("targetNode");
            }

            if (targetNode == this)
            {
                throw new ArgumentException("Node may not connect to itself.");
            }

            if (distance <= 0)
            {
                throw new ArgumentException("Distance must be positive.");
            }

            this.connections.Add(new Edge(targetNode, distance));
            if (twoWay)
            {
                targetNode.AddConnection(this, distance, false);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.Id.ToString());
            foreach (var connection in Connections)
            {
                sb.AppendLine(connection.ToString());
            }

            return sb.ToString();
        }
    }

    public class Edge
    {
        public Edge(Node target, ulong distance)
        {
            this.Target = target;
            this.Distance = distance;
        }

        public Node Target { get; private set; }

        public ulong Distance { get; private set; }

        public override string ToString()
        {
            return string.Format("T: {0}, D: {1}", this.Target, this.Distance);
        }
    }

    public class Graph
    {
        public Graph()
        {
            this.Nodes = new Dictionary<int, Node>();
        }

        internal IDictionary<int, Node> Nodes { get; private set; }

        public IList<Node> EdgeNodes
        {
            get { return this.Nodes.Where(n => n.Value.Connections.Count() < 2).Select(x => x.Value).ToList(); }
        }

        public void AddNode(int name)
        {
            var node = new Node(name);
            this.Nodes.Add(name, node);
        }

        public void AddConnection(int fromNode, int toNode, ulong distance, bool twoWay)
        {
            if (!this.Nodes.ContainsKey(fromNode))
            {
                this.AddNode(fromNode);
            }

            if (!this.Nodes.ContainsKey(toNode))
            {
                this.AddNode(toNode);
            }

            this.Nodes[fromNode].AddConnection(this.Nodes[toNode], distance, twoWay);
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var node in this.Nodes)
            {
                result.Append(node.Key + " -> ");

                foreach (var connection in node.Value.Connections)
                {
                    result.Append(connection.Target + "-" + connection.Distance + " ");
                }

                result.AppendLine();
            }

            return result.ToString();
        }
    }
}
