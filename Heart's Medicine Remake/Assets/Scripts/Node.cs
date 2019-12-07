using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public int gridX;// positin in node array
    public int gridY;

    public bool isBlock;
    public Vector2 position; // world position of the node

    public Node parent; // store the previous node?

    public int gCost; //cost of moving to next suqare
    public int hCost; //distance to the goal from this node

    public int FCost { get { return gCost + hCost; } }

    public Node(bool isBlock, Vector2 position, int gridX, int gridY)
    {
        this.isBlock = isBlock;
        this.position = position;
        this.gridX = gridX;
        this.gridY = gridY;
    }
}
