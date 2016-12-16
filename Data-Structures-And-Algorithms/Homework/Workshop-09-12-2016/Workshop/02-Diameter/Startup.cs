using System;
using System.Collections.Generic;

namespace _02_Diameter
{
    internal class Program
    {
        private static void Main()
        {
            var graph = new Graph();
            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n - 1; i++)
            {
                var input = Console.ReadLine().Split(' ');

                var firstNode = int.Parse(input[0]);
                var secondNode = int.Parse(input[1]);
                var weight = int.Parse(input[2]);

                graph.AddConnection(firstNode, secondNode, weight);
            }

            var max = graph.FindLongestWeightedRouteSum();
            Console.WriteLine(max);
        }
    }

    public class Graph
    {
        private readonly Dictionary<int, List<Edge>> nodes;

        public Graph()
        {
            this.nodes = new Dictionary<int, List<Edge>>();
        }

        public Dictionary<int, List<Edge>> Nodes
        {
            get { return this.nodes; }
        }

        public int EdgeNode
        {
            get
            {
                foreach (var item in this.nodes)
                {
                    if (item.Value.Count == 1)
                    {
                        return item.Key;
                    }
                }

                throw new ArgumentException();
            }
        }

        public int FindLongestWeightedRouteSum()
        {
            var nodeToStart = this.EdgeNode;
            this.FindMaxRoute(nodeToStart, 0);
            nodeToStart = this.startNode;
            this.FindMaxRoute(nodeToStart, 0);

            return this.maxValue;
        }

        public void AddConnection(int firstNode, int secondNode, int weight)
        {
            if (!this.Nodes.ContainsKey(firstNode))
            {
                this.Nodes.Add(firstNode, new List<Edge>());
            }

            if (!this.Nodes.ContainsKey(secondNode))
            {
                this.Nodes.Add(secondNode, new List<Edge>());
            }

            var edge = new Edge(firstNode, secondNode, weight);

            this.Nodes[firstNode].Add(edge);
            this.Nodes[secondNode].Add(edge);
        }

        private int maxValue = 0;
        private int startNode = 0;

        private void FindMaxRoute(int node, int current)
        {
            if (current > this.maxValue)
            {
                this.maxValue = current;
                this.startNode = node;
            }

            foreach (var edge in this.Nodes[node])
            {
                if (edge.IsVisited)
                {
                    continue;
                }

                edge.IsVisited = true;
                var nodeToSearch = edge.From == node ? edge.To : edge.From;
                this.FindMaxRoute(nodeToSearch, current + edge.Weight);
                edge.IsVisited = false;
            }
        }
    }

    public class Edge
    {
        public Edge(int from, int to, int weight)
        {
            this.From = from;
            this.To = to;
            this.Weight = weight;
            this.IsVisited = false;
        }

        public int From { get; set; }

        public int To { get; set; }

        public bool IsVisited { get; set; }

        public int Weight { get; set; }
    }
}
