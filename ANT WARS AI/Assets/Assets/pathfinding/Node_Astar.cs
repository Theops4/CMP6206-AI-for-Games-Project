using UnityEngine;

public class Node_Astar 
{
    public bool walkable;
    public Vector3 worldPosition;
    public int gridX;
    public int gridY;
    public Node_Astar parent;
    public int gCost;
    public int hCost;

    public Node_Astar(bool _walkable, Vector3 _worldPosition, int _gridX, int _gridY)
    {
        walkable = _walkable;
        worldPosition = _worldPosition;
        gridX = _gridX;
        gridY = _gridY;
    }
    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }
}
