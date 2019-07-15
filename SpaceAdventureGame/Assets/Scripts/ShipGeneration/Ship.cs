using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

[System.Serializable]
public class Ship
{
    public string shipName = "Argos";
    public Texture2D[] walls, floors, utilities;
    private List<ShipTile> tiles = new List<ShipTile>();
    private List<UtilityTile> utilityTiles = new List<UtilityTile>();

    public void Read(bool rotate, byte shipId)
    {
        tiles = new List<ShipTile>();
        utilityTiles = new List<UtilityTile>();
        Color32 col = Color.black;
        Vector3Int loc = Vector3Int.zero;
        UnityEngine.Debug.Log("Starting: "  + shipId);
        byte alphaCutoff = 1;
        byte colCutoff = 128;
        for (int i = 0; i < walls.Length; i++)
        {
            Color32[] wallTexColors = walls[i].GetPixels32();
            Color32[] floorTexColors = floors[i].GetPixels32();
            Color32[] utilityTexColors = utilities[i].GetPixels32();
            for (int x = 0; x < walls[i].width; x++)
            {
                for (int y = 0; y < walls[i].height; y++)
                {
                    //col = Color.black;
                    col = wallTexColors[x + (y * walls[i].width)];
                    if (!rotate)
                    {
                        loc.x = y;
                        loc.y = x;
                    }
                    else
                    {
                        loc.x = x;
                        loc.y = y;
                    }
                    if (col.a > alphaCutoff)
                    {
                        col.a = 255;
                        if (shipId == 0)
                        {
                            col.a = 192;
                        }
                        else
                        {
                            col.a = 64;
                        }
                        if (col.b > colCutoff)
                        {
                            tiles.Add(new ShipTile(shipName, true, loc, col, 200, shipId));
                        }
                        else if (col.r > colCutoff)
                        {
                            tiles.Add(new ShipTile(shipName, true, loc, col, 100, shipId));
                        }
                        else if (col.g > colCutoff)
                        {
                            tiles.Add(new ShipTile(shipName, true, loc, col, 50, shipId));
                        }

                    }
                    else
                    {
                        col = floorTexColors[x + (y * floors[i].width)];
                        if (!rotate)
                        {
                            loc.x = y;
                            loc.y = x;
                        }
                        else
                        {
                            loc.x = x;
                            loc.y = y;
                        }
                        if (col.a > alphaCutoff)
                        {
                            col.a = 255;
                            if (shipId == 0)
                            {
                                col.a = 192;
                            }
                            else
                            {
                                col.a = 64;
                            }
                            if (col.b > colCutoff)
                            {
                                tiles.Add(new ShipTile(shipName, false, loc, col, 250, shipId));
                            }
                            else if (col.r > colCutoff)
                            {
                                tiles.Add(new ShipTile(shipName, false, loc, col, 150, shipId));
                            }
                            else if (col.g > colCutoff)
                            {
                                tiles.Add(new ShipTile(shipName, false, loc, col, 50, shipId));
                            }
                        }
                    }
                    col = utilityTexColors[x + (y * utilities[i].width)];
                    if (col.a > alphaCutoff)
                    {
                        col.a = 255;
                        if (col.a > alphaCutoff)
                        {
                            col.a = 255;
                            if (shipId == 0)
                            {
                                col.a = 192;
                            }
                            else
                            {
                                col.a = 64;
                            }
                            if (col.b > colCutoff)
                            {
                                utilityTiles.Add(new UtilityTile(shipName, loc, col, shipId));
                            }
                            else if (col.r > colCutoff)
                            {
                                utilityTiles.Add(new UtilityTile(shipName, loc, col, shipId));
                            }
                            else if (col.g > colCutoff)
                            {
                                utilityTiles.Add(new UtilityTile(shipName, loc, col, shipId));
                            }
                        }
                    }
                }
            }
        }
        tiles.OrderBy(o => o.location.x).ThenBy(o => o.location.y);
        UnityEngine.Debug.Log(shipName + " Tile Count: " + tiles.Count);
    }

    public Ship(string shipName, Texture2D[] walls, Texture2D[] floors, Texture2D[] utilities, byte shipId, bool rotate)
    {
        this.shipName = shipName;
        this.walls = walls;
        this.floors = floors;
        this.utilities = utilities;
        this.tiles = new List<ShipTile>();
        utilityTiles = new List<UtilityTile>();
        Color32 col = Color.black;
        ShipTile t;
        UtilityTile ut;
        Vector3Int loc = Vector3Int.zero;
        
        byte alphaCutoff = 1;
        byte colCutoff = 128;
        for (int i = 0; i < walls.Length; i++)
        {
            Color32[] wallTexColors = walls[i].GetPixels32();
            Color32[] floorTexColors = floors[i].GetPixels32();
            Color32[] utilityTexColors = utilities[i].GetPixels32();
            for (int x = 0; x < walls[i].width; x++)
            {
                for (int y = 0; y < walls[i].height; y++)
                {
                    //col = Color.black;
                    col = wallTexColors[x + (y * walls[i].width)];
                    t = null;
                    if (!rotate)
                    {
                        loc.x = y;
                        loc.y = x;
                    }
                    else
                    {
                        loc.x = x;
                        loc.y = y;
                    }
                    if (col.a > alphaCutoff)
                    {
                        col.a = 255;
                        if (shipId == 0)
                        {
                            col.a = 192;
                        }
                        else
                        {
                            col.a = 64;
                        }
                        if (col.b > colCutoff)
                        {
                            tiles.Add(new ShipTile(shipName, true, loc, col, 200, shipId));
                        }
                        else if (col.r > colCutoff)
                        {
                            tiles.Add(new ShipTile(shipName, true, loc, col, 100, shipId));
                        }
                        else if (col.g > colCutoff)
                        {
                            tiles.Add(new ShipTile(shipName, true, loc, col, 50, shipId));
                        }
                        
                    }
                    else
                    {
                        col = floorTexColors[x + (y * floors[i].width)];
                        t = null;
                        if (!rotate)
                        {
                            loc.x = y;
                            loc.y = x;
                        }
                        else
                        {
                            loc.x = x;
                            loc.y = y;
                        }
                        if (col.a > alphaCutoff)
                        {
                            col.a = 255;
                            if (shipId == 0)
                            {
                                col.a = 192;
                            }
                            else
                            {
                                col.a = 64;
                            }
                            if (col.b > colCutoff)
                            {
                                tiles.Add(new ShipTile(shipName, false, loc, col, 250, shipId));
                            }
                            else if (col.r > colCutoff)
                            {
                                tiles.Add(new ShipTile(shipName, false, loc, col, 150, shipId));
                            }
                            else if (col.g > colCutoff)
                            {
                                tiles.Add(new ShipTile(shipName, false, loc, col, 50, shipId));
                            }
                        }
                    }
                    col = utilityTexColors[x + (y * utilities[i].width)];
                    if (col.a > alphaCutoff)
                    {
                        col.a = 255;
                        if (col.a > alphaCutoff)
                        {
                            col.a = 255;
                            if (shipId == 0)
                            {
                                col.a = 192;
                            }
                            else
                            {
                                col.a = 64;
                            }
                            if (col.b > colCutoff)
                            {
                                utilityTiles.Add(new UtilityTile(shipName, loc, col, shipId));
                            }
                            else if (col.r > colCutoff)
                            {
                                utilityTiles.Add(new UtilityTile(shipName, loc, col, shipId));
                            }
                            else if (col.g > colCutoff)
                            {
                                utilityTiles.Add(new UtilityTile(shipName, loc, col, shipId));
                            }
                        }
                    }
                }
            }
        }
        tiles.OrderBy(o => o.location.x).ThenBy(o => o.location.y);
    }
    public List<ShipTile> GetTiles()
    {
        return tiles;
    }

    public void ClearTiles()
    {
        tiles.Clear();
    }

    public Vector3Int Offset()
    {
        return new Vector3Int(Mathf.Max(walls[0].height, floors[0].height), 0, 0);

        //return new Vector3Int(Mathf.Max(walls[0].height, floors[0].height), Random.Range(0,Mathf.Max(walls[0].width, floors[0].width)/2), 0);
    }
}
