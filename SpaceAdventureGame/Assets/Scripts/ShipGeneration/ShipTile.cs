using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTile {
    public byte shipId;
    //public string shipName = "Argos";
    public bool wall = true;
    public int floor = 0;
    public Vector3Int location;
    public Color32 col;
    public int strength = 100;
    public int originalIndex;
    //public Vector2Int chunkLocation;
    public Vector3Int originalLocation;
    public ShipTile(string shipName, bool wall, Vector3Int location, Color32 col, int strength, byte shipId)
    {
        //this.shipName = shipName;
        this.wall = wall;
        this.location = location;
        this.col = col;
        this.strength = strength;
        this.shipId = shipId;
        originalLocation = location;
    }
    public ShipTile(ShipTile t)
    {
        this.wall = t.wall;
        this.location = t.location;
        this.col = t.col;
        this.strength = t.strength;
        this.shipId = t.shipId;
        originalLocation = location;
    }
    public static ShipTile Impact(ShipTile a, ShipTile b)
    {
        if(a.strength >= b.strength)
        {
            //Debug.Log("A Stronger");
            a.strength -= b.strength;
            return a;
        }
        else
        {
            //Debug.Log("B Stronger");
            b.strength -= a.strength;
            return b;
        }
    }
}
