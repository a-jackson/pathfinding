// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Node.cs" company="Andrew Jackson">
//   2012
// </copyright>
// <summary>
//   A single node.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace PathFinding
{
    using System;

    /// <summary>
    /// A single node.
    /// </summary>
    public class Node
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Node"/> class.
        /// </summary>
        /// <param name="passable">
        /// A value indcating if the node is passable.
        /// </param>
        /// <param name="x">
        /// The x coordinate of the node.
        /// </param>
        /// <param name="y">
        /// The y coordinate of the node.
        /// </param>
        public Node(bool passable, int x, int y, int cost)
        {
            this.Parent = null;
            this.H = 0;
            this.G = 0;
            this.X = x;
            this.Y = y;
            this.Cost = cost;
            this.NodeState = passable ? NodeState.Clear : NodeState.Blocked;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the F variable.
        /// </summary>
        public int F
        {
            get
            {
                return this.G + this.H;
            }
        }

        /// <summary>
        /// Gets the G variable.
        /// </summary>
        public int G { get; private set; }

        /// <summary>
        /// Gets the H variable.
        /// </summary>
        public int H { get; private set; }

        /// <summary>
        /// Gets or sets the state of the node.
        /// </summary>
        public NodeState NodeState { get; set; }

        /// <summary>
        /// Gets or sets the Parent node.
        /// </summary>
        public Node Parent { get; set; }

        /// <summary>
        /// Gets the node's X location.
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// Gets the node's Y location.
        /// </summary>
        public int Y { get; private set; }

        public int Cost { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Calculates G using the specified parent node.
        /// </summary>
        /// <param name="parent">
        /// The parent node.
        /// </param>
        public void CalculateG(Node parent)
        {
            int tempG = parent.G + 1 + Cost;
            if (parent.Parent != null)
            {
                // Check if in order to get here, the path has to turn. 
                // Add 1 to the cost.
                if (parent.X == parent.Parent.X && parent.X != this.X)
                {
                    tempG++;
                }
                else if (parent.Y == parent.Parent.Y && parent.Y != this.Y)
                {
                    tempG++;
                }
            }

            // If the calculated G is lower than the current G then
            // update it and the parent.
            if (this.G == 0 || tempG < this.G)
            {
                this.G = tempG;
                this.Parent = parent;
            }
        }

        /// <summary>
        /// Estimate the H value based on the node's location.
        /// </summary>
        /// <param name="endNode">
        /// The end node.
        /// </param>
        public void EstimateH(Node endNode)
        {
            this.H = Math.Abs(this.X - endNode.X) + Math.Abs(this.Y - endNode.Y);
        }

        public void ResetG()
        {
            this.G = 0;
        }

        #endregion
    }
}