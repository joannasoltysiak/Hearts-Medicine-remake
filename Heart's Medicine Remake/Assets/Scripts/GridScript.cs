using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    public Transform startPosition;
    public LayerMask blockMask;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    public float distance;

    Node[,] grid;
    public List<Node> finalPath;

    float nodeDiameter;
    int gridSizeX, gridSizeY;

    private void Start()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        CreateGrid();
    }

    void CreateGrid()
    {
        grid = new Node[gridSizeX, gridSizeY];
        Vector2 v = transform.position;
        Vector2 bottomLeft = v - Vector2.right * gridWorldSize.x / 2 - Vector2.up * gridWorldSize.y / 2;
        for(int y = 0; y < gridSizeY; y++)
        {
            for(int x = 0; x< gridSizeX; x++)
            {
                Vector2 worldPoint = bottomLeft + Vector2.right * (x * nodeDiameter + nodeRadius) + Vector2.up * (y * nodeDiameter + nodeRadius);
                bool Block = true;

                if (Physics.CheckSphere(worldPoint, nodeRadius, blockMask))
                    Block = false;

                grid[x, y] = new Node(Block, worldPoint, x, y);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector2(gridWorldSize.x, gridWorldSize.y));
        if(grid != null)
        {
            foreach(Node node in grid)
            {
                if (node.isBlock)
                    Gizmos.color = Color.white;
                else
                    Gizmos.color = Color.yellow;

                if (finalPath != null)
                    Gizmos.color = Color.red;

                Gizmos.DrawCube(node.position, Vector2.one * (nodeDiameter - distance));
            }
        }
    }

}

