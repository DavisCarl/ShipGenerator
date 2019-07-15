using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags()]
public enum Connections
{
    Left = 0,
    Right = 1,
    North = 2,
    South = 4,
    Up = 8,
    Down = 16
}


public class UtilityTile {

    public byte shipId;
    public bool pipe, duct, wire;
    public bool valve, vent, socket;
    public bool exposed, floor;
    public Connections pipeConnections, ductConnections, wireConnections;
    public Vector3Int location;
    public Color32 col;
    public int originalIndex;
    public Vector3Int originalLocation;
    public UtilityTile(string shipName, Vector3Int location, Color32 col, byte shipId)
    {
        this.location = location;
        this.col = col;
        this.shipId = shipId;
        exposed = false;
        floor = false;
        if (col.r > 128)
        {
            wire = true;
        }
        if (col.g > 128)
        {
            duct = true;
        }
        if (col.b > 128)
        {
            pipe = true;
        }
        originalLocation = location;
    }

    public UtilityTile(string shipName, Vector3Int location, Color32 col, byte shipId, bool ex, bool flo)
    {
        this.location = location;
        this.col = col;
        this.shipId = shipId;
        exposed = ex;
        floor = flo;
        if(col.r > 128)
        {
            wire = true;
        }
        if (col.g > 128)
        {
            duct = true;
        }
        if (col.b > 128)
        {
            pipe = true;
        }
        originalLocation = location;
    }

    public UtilityTile(byte shipId, bool pipe, bool duct, bool wire, bool valve, bool vent, bool socket, bool exposed, bool floor, Vector3Int location, Color32 col, int originalIndex, Vector3Int originalLocation)
    {
        this.shipId = shipId;
        this.pipe = pipe;
        this.duct = duct;
        this.wire = wire;
        this.valve = valve;
        this.vent = vent;
        this.socket = socket;
        this.exposed = exposed;
        this.floor = floor;
        this.location = location;
        this.col = col;
        this.originalIndex = originalIndex;
        this.originalLocation = originalLocation;
    }

    public UtilityTile(UtilityTile t)
    {

        this.shipId = t.shipId;
        this.pipe = t.pipe;
        this.duct = t.duct;
        this.wire = t.wire;
        this.valve = t.valve;
        this.vent = t.vent;
        this.socket = t.socket;
        this.exposed = t.exposed;
        this.floor = t.floor;
        this.location = t.location;
        this.col = t.col;
        this.originalIndex = t.originalIndex;
        this.originalLocation = t.originalLocation;
    }
}
