// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Pathfinding.cs" company="Andrew Jackson">
//   2012
// </copyright>
// <summary>
//   Perform A* Pathfinding.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PathFinding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Perform A* Pathfinding.
    /// </summary>
    public class Pathfinding
    {
        #region Constants and Fields

        /// <summary>
        /// The size of the grid.
        /// </summary>
        public const int GridSize = 10;

        /// <summary>
        /// The percentage probability that a tile will be blocked.
        /// </summary>
        private const int BlockedProbability = 25;

        /// <summary>
        /// The closed list.
        /// </summary>
        private List<Node> closedList;

        /// <summary>
        /// The end node.
        /// </summary>
        private Node endNode;

        /// <summary>
        /// The open list.
        /// </summary>
        private List<Node> openList;

        /// <summary>
        /// The start node.
        /// </summary>
        private Node startNode;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the nodes.
        /// </summary>
        public Node[,] Nodes { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Resets the grid.
        /// </summary>
        public void Reset()
        {
            this.Nodes = new Node[GridSize, GridSize];
            var r = new Random();
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    this.Nodes[i, j] = new Node(r.Next(100) > BlockedProbability, i, j);
                }
            }

            this.startNode = this.Nodes[0, 0];
            this.startNode.NodeState = NodeState.Start;
            this.endNode = this.Nodes[GridSize - 1, GridSize - 1];
            this.endNode.NodeState = NodeState.End;
            this.openList = new List<Node>();
            this.closedList = new List<Node>();

            foreach (Node node in this.Nodes)
            {
                node.EstimateH(this.endNode);
            }
        }

        /// <summary>
        /// Runs the pathfinding.
        /// </summary>
        /// <returns>
        /// A value indicating whether the a path was found.
        /// </returns>
        public bool Run()
        {
            // Clear the lists.
            this.openList.Clear();
            this.closedList.Clear();

            // Reset path nodes to clear.
            foreach (Node node in this.Nodes)
            {
                if (node.NodeState == NodeState.Path)
                {
                    node.NodeState = NodeState.Clear;
                }
            }

            // Start the with the start node.
            Node currentNode = this.startNode;
            while (true)
            {
                this.openList.Remove(currentNode);
                this.closedList.Add(currentNode);
                if (currentNode.Equals(this.endNode))
                {
                    break;
                }

                // Look for adjacent nodes not on closed list
                for (int x = currentNode.X - 1; x <= currentNode.X + 1; x++)
                {
                    if (x < 0 || x >= GridSize)
                    {
                        continue;
                    }

                    for (int y = currentNode.Y - 1; y <= currentNode.Y + 1; y++)
                    {
                        if (y < 0 || y >= GridSize)
                        {
                            continue;
                        }

                        if (x != currentNode.X && y != currentNode.Y)
                        {
                            continue;
                        }

                        Node node = this.Nodes[x, y];
                        if (node.NodeState == NodeState.Blocked || this.closedList.Contains(node))
                        {
                            continue;
                        }

                        if (this.openList.Contains(this.Nodes[x, y]))
                        {
                            // Recalcuate the G
                            node.CalculateG(currentNode);
                        }
                        else
                        {
                            node.Parent = currentNode;
                            this.openList.Add(node);
                            node.CalculateG(currentNode);
                        }
                    }
                }

                if (this.openList.Count == 0)
                {
                    return false; // No path.
                }

                currentNode = this.openList.Last(n => n.F == this.openList.Min(m => m.F));
            }

            // Loop backwards through the parents' nodes setting them to Path until the start node is reached.
            while ((currentNode = currentNode.Parent) != null && !currentNode.Equals(this.startNode))
            {
                currentNode.NodeState = NodeState.Path;
            }

            return true;
        }

        #endregion
    }
}