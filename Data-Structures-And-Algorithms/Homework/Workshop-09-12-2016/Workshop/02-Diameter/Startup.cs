using System;
using System.Collections.Generic;
using System.Text;

namespace _02_Diameter
{
    public class Startup
    {
        private static void Main()
        {
            var graph = new Graph();
            int numberOfNodes = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfNodes - 1; i++)
            {
                var edges = Console.ReadLine().Split(' ');
                var firstNodeId = int.Parse(edges[0]);
                var secondNodeId = int.Parse(edges[1]);
                if (!graph.Nodes.ContainsKey(firstNodeId))
                {
                    graph.AddNode(firstNodeId);
                }

                if (!graph.Nodes.ContainsKey(secondNodeId))
                {
                    graph.AddNode(secondNodeId);
                }

                var weight = int.Parse(edges[2]);
                graph.AddConnection(firstNodeId, secondNodeId, weight, true);
            }

            double max = double.MinValue;
            foreach (var node in graph.Nodes)
            {
                var current = Dfs(0, node, new Dictionary<int, Node>());

                if (current > max)
                {
                    max = current;
                }
            }

            //Console.WriteLine(graph);
            Console.WriteLine("max: " + max);
        }

        private static double Dfs(double current, KeyValuePair<int, Node> node, IDictionary<int, Node> traversed)
        {
            foreach (var connection in node.Value.Connections)
            {
                current += connection.Distance;
                if (!traversed.ContainsKey(connection.Target.Name))
                {
                    traversed.Add(connection.Target.Name, connection.Target);
                    current += Dfs(0, new KeyValuePair<int, Node>(connection.Target.Name, connection.Target), traversed);
                    traversed.Remove(connection.Target.Name);
                }

            }

            return current;
        }
    }

    public class Node
    {
        private readonly IList<Edge> connections;

        public Node(int name)
        {
            this.Name = name;
            this.connections = new List<Edge>();
        }

        public int Name { get; private set; }

        public IEnumerable<Edge> Connections
        {
            get { return this.connections; }
        }

        public void AddConnection(Node targetNode, double distance, bool twoWay)
        {
            if (targetNode == null)
            {
                throw new ArgumentNullException(nameof(targetNode));
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
            return this.Name.ToString();
        }
    }

    public class Edge
    {
        public Edge(Node target, double distance)
        {
            this.Target = target;
            this.Distance = distance;
        }

        public Node Target { get; private set; }

        public double Distance { get; private set; }
    }

    public class Graph
    {
        public Graph()
        {
            this.Nodes = new Dictionary<int, Node>();
        }

        internal IDictionary<int, Node> Nodes { get; private set; }

        public void AddNode(int name)
        {
            var node = new Node(name);
            this.Nodes.Add(name, node);
        }

        public void AddConnection(int fromNode, int toNode, int distance, bool twoWay)
        {
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
