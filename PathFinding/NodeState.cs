// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NodeState.cs" company="Andrew Jackson">
//   2012
// </copyright>
// <summary>
//   The states a node can be in.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace PathFinding
{
    /// <summary>
    /// The states a node can be in.
    /// </summary>
    public enum NodeState
    {
        /// <summary>
        /// The node is clear and passable.
        /// </summary>
        Clear, 

        /// <summary>
        /// The node is blocked.
        /// </summary>
        Blocked, 

        /// <summary>
        /// The node is the start node.
        /// </summary>
        Start, 

        /// <summary>
        /// The node is the end node.
        /// </summary>
        End, 

        /// <summary>
        /// The node is a node in the path.
        /// </summary>
        Path
    }
}