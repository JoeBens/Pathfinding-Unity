using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {

    public Node[,] nodes;
    public List<Node> walls = new List<Node>();

    int[,] m_mapData;
    int m_width;
    int m_height;

    public static readonly Vector2[] allDirections =
    {
        new Vector2(0f,1f),
         new Vector2(1f,1f),
          new Vector2(1f,0f),
           new Vector2(1f,-1f),
            new Vector2(0f,-1f),
             new Vector2(-1f,-1f),
              new Vector2(-1f,0f),
               new Vector2(-1f,1f)
    };

    public void Init(int[,] mapData)
    {
        m_mapData = mapData;
        m_width = mapData.GetLength(0);
        m_height = mapData.GetLength(1);


        nodes = new Node[m_width, m_height];

        for (int i = 0; i < m_width; i++)
        {
            for (int j = 0; j < m_height; j++)
            {
                NodeType type = (NodeType)mapData[i, j];
                Node newNode = new Node(i, j, type);
                nodes[i, j] = newNode;

                newNode.position = new Vector3(i, 0, j);

                if(type == NodeType.Blocked)
                {
                    walls.Add(newNode);
                }
            }
        }
        for (int i = 0; i < m_width; i++)
        {
            for (int j = 0; j < m_height; j++)
            {
                if(nodes[i, j].nodeType != NodeType.Blocked)
                {
                    nodes[i, j].neighbors = GetNeighbors(i, j);
                }
            }
        }
    }

    public bool IsWithinBounds(int x, int y)
    {
        return (x >= 0 && x < m_width && y >= 0 && y < m_height);
    }

    List<Node> GetNeighbors(int x, int y, Node[,] nodeArray, Vector2[] directions)
    {
        List<Node> neighborNodes = new List<Node>();

        foreach (Vector2 dir in directions)
        {

            int newX = x + (int)dir.x;
            int newY = y + (int)dir.y;

            //8 neighbors
            if(IsWithinBounds(newX, newY) && nodeArray[newX, newY] != null && nodeArray[newX, newY].nodeType != NodeType.Blocked)
            {
                neighborNodes.Add(nodeArray[newX, newY]);
            }
        }
        return neighborNodes;
    }

    List<Node> GetNeighbors(int x, int y)
    {
        return GetNeighbors(x, y, nodes, allDirections);
    }


}
