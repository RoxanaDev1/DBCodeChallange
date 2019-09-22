using System;
using System.Collections.Generic;

namespace Solution
{
    public class Node
    {
        //A list containing the neigbors of this node. Those are all the possible nodes we can  navigate to.
        public List<Node> neighbors { get; private set; }
        //The number which was read from the input.
        public int weight { get; private set; }
        //Unique identifier of the node.
        public Guid id { get; private set; }
        //A boolean to hold if the weight is even. The weight defines if a node is even or not
        private bool isEven;
        //A boolean to hold if this node was at the bottom of the input triangle.
        public bool isLast;

        /// <summary>
        /// Empty constructor of a node
        /// </summary>
        /// <returns>
        /// An empty node with a new empty list of neighbors and 0 weight.
        /// </returns>
        public Node()
        {
            this.neighbors = new List<Node>();
            this.weight = 0;
            this.id = Guid.NewGuid();
            this.isEven = true;
        }

        /// <summary>
        /// Constructor which accepts only the weight.
        /// </summary>
        /// <param name="weight">An integer number that defines the node weight.</param>
        /// <returns>
        /// A node with the given weight and an empty neighbors list.
        /// </returns>
        public Node(int weight)
        {
            this.neighbors = new List<Node>();
            this.weight = weight;
            this.id = Guid.NewGuid();
            this.isEven = weight % 2 == 0;
        }

        /// <summary>
        /// A method to add a new neighbor for this node. The method will only add the new node neigbor if the even/odd rules are kept.
        /// </summary>
        /// <param name="potentialNeighbor">The wanted node to be added.</param>
        /// <returns>
        /// Returns a true or false if the addition is successful or not.
        /// </returns>
        public bool AddNeighbor(Node potentialNeighbor)
        {
            bool isNeighborEven = potentialNeighbor.weight % 2 == 0;
            if ((this.isEven && !isNeighborEven) || (!this.isEven && isNeighborEven))
            {
                this.neighbors.Add(potentialNeighbor);
                return true;
            }
            return false;
        }
    }
}