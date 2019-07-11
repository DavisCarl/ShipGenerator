using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

//public class Ship : MonoBehaviour {

//    public string className;
//    public Sprite floors, walls;
//    [SerializeField]
//    private AtmosphereController atmo;
//    [SerializeField]
//    private Upscaler upscaler;
//    [SerializeField]
//    private SpriteRenderer wallSprite, floorSprite;

//    public int xDim, yDim;
//	// Use this for initialization
//	void Start () {

//	}

//    private void OnValidate()
//    {
//        upscaler.inputTex = walls.texture;
//        wallSprite.sprite = walls;
//        floorSprite.sprite = floors;
//        upscaler.Revalidate();
//    }


//    // Update is called once per frame
//    void Update () {

//	}
//}
public class Ship
{
    public string shipName = "Argos";
    public Texture2D walls, floors;
    private List<ShipTile> tiles;

    public  Ship(string shipName, Texture2D walls, Texture2D floors, byte shipId, bool rotate)
    {
        this.shipName = shipName;
        this.walls = walls;
        this.floors = floors;
        this.tiles = new List<ShipTile>();
        Color32 col = Color.black;
        ShipTile t;
        Vector3Int loc = Vector3Int.zero;
        Color32[] wallTexColors = walls.GetPixels32();
        Color32[] floorTexColors = floors.GetPixels32();
        byte alphaCutoff = 1;
        byte colCutoff = 128;
        for (int x = 0; x < walls.width; x++)
        {
            for (int y = 0; y < walls.height; y++)
            {
                //col = Color.black;
                col = wallTexColors[x + (y * walls.width)];
                t = null;
                if(!rotate)
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
                        t = new ShipTile(shipName, true, loc, col, 200, shipId);
                        //t.col.a /= (byte)(shipId + 1);
                        //t.col.a -= 5;
                        tiles.Add(t);
                    }
                    else if (col.r > colCutoff)
                    {
                        t = new ShipTile(shipName, true, loc, col, 100, shipId);
                        //t.col.a /= (byte)(shipId + 1);
                        //t.col.a -= 5;
                        tiles.Add(t);
                    }
                    else if (col.g > colCutoff)
                    {
                        t = new ShipTile(shipName, true, loc, col, 50, shipId);
                        //t.col.a /= (byte)(shipId + 1);
                        //t.col.a -= 5;
                        tiles.Add(t);
                    }
                }
                else
                {
                    col = floorTexColors[x + (y * floors.width)];
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
                        if(shipId == 0)
                        {
                            col.a = 192;
                        }
                        else
                        {
                            col.a = 64;
                        }
                        if (col.b > colCutoff)
                        {
                            t = new ShipTile(shipName, false, loc, col, 200, shipId);
                            //t.col.a /= (byte)(shipId + 1);
                            //t.col.a -= 5;
                            tiles.Add(t);
                        }
                        else if (col.r > colCutoff)
                        {
                            t = new ShipTile(shipName, false, loc, col, 100, shipId);
                            //t.col.a /= (byte)(shipId + 1);
                            //t.col.a -= 5;
                            tiles.Add(t);
                        }
                        else if (col.g > colCutoff)
                        {
                            t = new ShipTile(shipName, false, loc, col, 50, shipId);
                            //t.col.a /= (byte)(shipId + 1);
                            //t.col.a -= 5;
                            tiles.Add(t);
                        }
                    }
                }
                
            }
        }

        tiles.OrderBy(o => o.location.x).ThenBy(o => o.location.y);
        //Debug.Log(tiles.Count * System.Runtime.InteropServices.Marshal.SizeOf(tiles[0]));
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
        return new Vector3Int(Mathf.Max(walls.height, floors.height), 0, 0);

        return new Vector3Int(Mathf.Max(walls.height, floors.height), Random.Range(0,Mathf.Max(walls.width, floors.width)/2), 0);
    }
}
