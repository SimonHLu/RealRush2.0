using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node // This became a data class, only will contain data
{
    public Vector2Int coordinates; // this.coordinates goes here.
    public bool isWalkable; // this.isWalkable goes here.
    public bool isExpored;
    public bool isPath;
    public Node connectedTo;

    //Constructor, method name same as class name
    //Constructs Node object when u want to use it.
    public Node(Vector2Int coordinates, bool isWalkable)
    {
        this.coordinates = coordinates;
        this.isWalkable = isWalkable;
    }
    


}
