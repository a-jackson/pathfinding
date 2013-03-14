// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PathfindingForm.cs" company="Andrew Jackson">
//   2012
// </copyright>
// <summary>
//   The command.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PathFinding
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// The pathfinding form.
    /// </summary>
    public partial class PathfindingForm : Form
    {
        #region Constants and Fields

        /// <summary>
        /// The pathfinding algorithm.
        /// </summary>
        private readonly Pathfinding pathfinding;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PathfindingForm"/> class.
        /// </summary>
        public PathfindingForm()
        {
            this.InitializeComponent();
            this.pathfinding = new Pathfinding();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles painting the grid.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void GridPaint(object sender, PaintEventArgs e)
        {
            var blackPen = new Pen(new SolidBrush(Color.Black), 2);
            var grayBrush = new SolidBrush(Color.LightGray);
            var blueBrush = new SolidBrush(Color.Blue);
            var greenBrush = new SolidBrush(Color.Green);
            var redBrush = new SolidBrush(Color.Red);
            var blackBrush = new SolidBrush(Color.Black);

            int nodeHeight = this.grid.Size.Height / Pathfinding.GridSize;
            int nodeWidth = this.grid.Size.Width / Pathfinding.GridSize;

            // Draw nodes
            for (int x = 0; x < Pathfinding.GridSize; x++)
            {
                for (int y = 0; y < Pathfinding.GridSize; y++)
                {
                    Node node = this.pathfinding.Nodes[x, y];
                    var r = new Rectangle(x * nodeWidth, y * nodeHeight, nodeWidth, nodeHeight);
                    switch (node.NodeState)
                    {
                        case NodeState.Clear:
                            e.Graphics.FillRectangle(grayBrush, r);
                            e.Graphics.DrawString(node.Cost.ToString(), this.Font, blackBrush, r);
                            break;
                        case NodeState.Blocked:
                            e.Graphics.FillRectangle(blackBrush, r);
                            break;
                        case NodeState.End:
                            e.Graphics.FillRectangle(redBrush, r);
                            break;
                        case NodeState.Path:
                            e.Graphics.FillRectangle(blueBrush, r);
                            break;
                        case NodeState.Start:
                            e.Graphics.FillRectangle(greenBrush, r);
                            break;
                    }
                }
            }

            // Draw grid  
            for (int x = nodeWidth, i = 1; i < Pathfinding.GridSize; i++, x += nodeWidth)
            {
                e.Graphics.DrawLine(blackPen, x, 0, x, this.grid.Size.Height);
            }

            for (int y = nodeHeight, i = 1; i < Pathfinding.GridSize; i++, y += nodeHeight)
            {
                e.Graphics.DrawLine(blackPen, 0, y, this.grid.Size.Width, y);
            }
        }

        /// <summary>
        /// The form 1_ load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void PathfindingFormLoad(object sender, EventArgs e)
        {
            this.pathfinding.Reset();
        }

        /// <summary>
        /// Handles the reset button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event args.
        /// </param>
        private void ResetClick(object sender, EventArgs e)
        {
            this.pathfinding.Reset();
            this.grid.Invalidate();
        }

        /// <summary>
        /// Handles the start button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event args.
        /// </param>
        private void StartClick(object sender, EventArgs e)
        {
            if (!this.pathfinding.Run())
            {
                MessageBox.Show("No path");
            }

            this.grid.Invalidate();
        }

        #endregion
    }
}