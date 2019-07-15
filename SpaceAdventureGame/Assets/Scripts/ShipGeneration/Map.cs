using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

public class Map : MonoBehaviour {

    //public Texture2D aFloor, bFloor, aWall, bWall, aUtility, bUtility;
    public int chunk_size = 64;
    public ShipScriptableObject shipA, shipB;
    [HideInInspector]
    public Ship a, b;
    public Material baseMat;
    public int force = 100;

    List<int> cubeTriangles = new List<int>();
    private List<Vector3> cubeVerts = new List<Vector3>();
    private List<int> quadTriangles = new List<int>();
    private List<Vector3> quadVerts = new List<Vector3>();
    private Dictionary<Vector2Int, ShipTile> mapTiles;
    private int tileDimX, tileDimY = 0;
    private List<BoxCollider> colliders;
    private Dictionary<Vector2Int, Dictionary<Vector3Int, ShipTile>> chunkTiles;
	// Use this for initialization
	async void Start () {
        a = shipA.ship;
        b = shipB.ship;
        a.Read(false, 0);
        b.Read(Random.Range(0, 100) > 50, 1);
        Debug.Log(a.GetTiles().Count);
        Debug.Log(b.GetTiles().Count);
        Debug.Log("Tiles Gotten: " + Time.realtimeSinceStartup);
        GameObject primitiveData = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cubeTriangles = primitiveData.GetComponent<MeshFilter>().mesh.triangles.ToList();
        cubeVerts = primitiveData.GetComponent<MeshFilter>().mesh.vertices.ToList();
        //GameObject quadData = GameObject.CreatePrimitive(PrimitiveType.Quad);
        quadTriangles = primitiveData.GetComponent<MeshFilter>().mesh.triangles.ToList();
        quadVerts = primitiveData.GetComponent<MeshFilter>().mesh.vertices.ToList();
        for (int i = 0; i < cubeVerts.Count; i++)
        {
            if(cubeVerts[i].y > 0)
            {
                cubeVerts[i] = new Vector3(cubeVerts[i].x, 3, cubeVerts[i].z);
            }
        }
        for (int i = 0; i < quadVerts.Count; i++)
        {
                quadVerts[i] = new Vector3(quadVerts[i].x, quadVerts[i].y * .01f, quadVerts[i].z);
        }
        Destroy(primitiveData);
        //Destroy(quadData);
        await InitializeMap(a, b);
    }

    public async Task NewMap(Ship a, Ship b)
    {
        await InitializeMap(a, b);
    }

    public Vector2Int ChunkFinder(Vector3Int input)
    {
        return new Vector2Int(input.x / chunk_size, input.y / chunk_size);
    }

    public async Task InitializeMap(Ship a, Ship b)
    {
        Debug.Log("Initing: " + Time.realtimeSinceStartup);
        mapTiles = new Dictionary<Vector2Int, ShipTile>();
        chunkTiles = new Dictionary<Vector2Int, Dictionary<Vector3Int, ShipTile>>();
        Vector2Int currentChunk;
        foreach(ShipTile t in a.GetTiles())
        {
                currentChunk = ChunkFinder(t.location);
                if (chunkTiles.ContainsKey(currentChunk))
                {
                    chunkTiles[currentChunk][t.location] = t;
                }
                else
                {
                    chunkTiles.Add(currentChunk, new Dictionary<Vector3Int, ShipTile>());
                    chunkTiles[currentChunk][t.location] = t;
                }
        }
        Debug.Log("Ship 1 Inited: " + Time.realtimeSinceStartup);
        await new WaitForSeconds(1);
        Vector3Int offset = a.Offset();
        List<ShipTile> tilesToMove = new List<ShipTile>();
        foreach (ShipTile t in b.GetTiles())
        {
                t.location += offset;
                tilesToMove.Add(t);
        }
        tilesToMove.OrderBy(o => o.location.x).ThenBy(o => o.location.y).ThenBy(o=>o.location.z);
        Dictionary<Vector2Int, List<ShipTile>> rows = new Dictionary<Vector2Int, List<ShipTile>>();
        List<List<ShipTile>> rowList = new List<List<ShipTile>>();
        Vector2Int key = Vector2Int.zero;
        Dictionary<Vector2Int, int> indices = new Dictionary<Vector2Int, int>();
        foreach (ShipTile t in tilesToMove)
        {
            key.x = t.location.y;
            key.y = t.location.z;
            if(!indices.ContainsKey(key))
            {
                indices.Add(key, rows.Keys.Count);
                rows[key] = new List<ShipTile>();
                rows[key].Add(t);
            }
            else
            {
                rows[key].Add(t);
            }
            
        }
        foreach(List<ShipTile> tiles in rows.Values)
        {
            rowList.Add(tiles);
        }
        Debug.Log("Ship 2 Inited: " + Time.realtimeSinceStartup);
        await new WaitForBackgroundThread();
        Task<List<ShipTile>> smashed = Smash(force, rowList);
        foreach (ShipTile t in await smashed)
        {
            currentChunk = ChunkFinder(t.location);
            if (chunkTiles.ContainsKey(currentChunk))
            {
                if (chunkTiles[currentChunk].ContainsKey(t.location))
                {
                    ShipTile conflictChunk = chunkTiles[currentChunk][t.location];
                    int index = 0;
                    foreach(List<ShipTile> list in rowList)
                    {
                        if (list.Contains(conflictChunk))
                        {
                            index = list.IndexOf(list.First(o=>o.location == conflictChunk.location)); // newTilesToMove[i].IndexOf(newTilesToMove[i].First(o => o.location.x == newTilesToMove[i].Min(no => no.location.x)));
                        }
                    }
                }
                chunkTiles[currentChunk][t.location] = t;
            }
            else
            {
                chunkTiles.Add(currentChunk, new Dictionary<Vector3Int, ShipTile>());
                chunkTiles[currentChunk][t.location] = t;
            }
        }
        await new WaitForUpdate();
        Debug.Log("Inited: " + Time.realtimeSinceStartup);
        await GenerateColliders();
    }

    private async Task<List<ShipTile>> Smash(int force, List<List<ShipTile>> tilesToMove)
    {
        List<int> tilesToRemove = new List<int>();
        ShipTile t = null;
        ShipTile ot, ft;
        Vector2Int currentChunk= Vector2Int.zero;
        List<int> dists = new List<int>();
        List<List<ShipTile>> newTilesToMove = new List<List<ShipTile>>();
        foreach(List<ShipTile> list in tilesToMove)
        {
            newTilesToMove.Add(list.OrderBy(o => o.location.x).ToList());
            dists.Add(0);
        }
        bool hit = false;
        int dist = 0;
        List<ShipTile> output = new List<ShipTile>();
        while (force > 0)
        {
            for (int i = 0; i < newTilesToMove.Count; i++)
            {
                if (newTilesToMove[i].Count > 0)
                {
                    ShipTile tip = newTilesToMove[i][0];
                    tip.location -= Vector3Int.right;
                    ft = ot = null;
                    currentChunk = ChunkFinder(tip.location);
                    if (chunkTiles.ContainsKey(currentChunk))
                    {

                        if (chunkTiles[currentChunk].ContainsKey(tip.location))
                        {
                            ot = chunkTiles[currentChunk][tip.location];
                            if (ot.shipId != tip.shipId)
                            {
                                ft = ShipTile.Impact(ot, tip);

                                force--;
                                if (ft.shipId == ot.shipId)
                                {
                                    if (newTilesToMove[i].Count > 1)
                                    {
                                        newTilesToMove[i][1].location -= Vector3Int.right * (dists[i] - 1);//tip.location;//  += Vector3Int.right;
                                    }
                                    chunkTiles[currentChunk][ot.location].strength = ft.strength;
                                    newTilesToMove[i].RemoveAt(0);
                                }
                                else
                                {
                                    newTilesToMove[i][0].strength = ft.strength;
                                    chunkTiles[currentChunk].Remove(tip.location);
                                }
                            }
                        }
                    }
                    dists[i]++;
                }

            }
            dist++;
        }
         output = new List<ShipTile>();
        await new WaitForUpdate();
        for (int i = 0; i < newTilesToMove.Count; i++)
        {
            for (int j = 1; j < newTilesToMove[i].Count; j++)
            {
                newTilesToMove[i][j].location -= Vector3Int.right * (dists[i]);
            }
            output.AddRange(newTilesToMove[i]);
        }
            return output;
    }


    public void Chunk()
    {
        int xMax, xMin, yMax, yMin = 0;
        xMax = mapTiles.Keys.Max(o => o.x);
        xMin = mapTiles.Keys.Min(o => o.x);
        yMax = mapTiles.Keys.Max(o => o.y);
        yMin = mapTiles.Keys.Min(o => o.y);
        tileDimX = Mathf.CeilToInt((xMax - xMin) / (1f* (chunk_size)));
        tileDimY = Mathf.CeilToInt((yMax - yMin) / (1f * (chunk_size)));        
    }
    private async Task<List<BasicMeshData>> BasicMeshDataset(List<Dictionary<Vector3Int, ShipTile>> inputList)
    {
        await new WaitForBackgroundThread();
        List<Task> dataTasks = new List<Task>();
        List<BasicMeshData> data = new List<BasicMeshData>();
        foreach(Dictionary<Vector3Int, ShipTile> dict in inputList)
        {
            data.Add(GenerateBasicMesh(dict));
        }
        return data;
    }
    private BasicMeshData GenerateBasicMesh(Dictionary<Vector3Int, ShipTile> inChunk)
    {
            
            List<Vector3> vertices = new List<Vector3>();
            List<int> triangles = new List<int>();
            List<Color32> colors = new List<Color32>();
        Vector3 adjustment = (Vector3.up) / 2;
            foreach (ShipTile tile in inChunk.Values)
            {
                Vector3 pos = new Vector3(tile.location.x, tile.location.z, tile.location.y);
                int firstVert = vertices.Count;
                if (tile.wall)
                {
                    foreach (Vector3 v in cubeVerts)
                    {
                        vertices.Add(v + pos);
                        colors.Add(tile.col);
                    }
                    foreach (int t in cubeTriangles)
                    {
                        triangles.Add(t + firstVert);
                    }
                }
                else
                {
                    foreach (Vector3 v in quadVerts)
                    {
                        vertices.Add(v + pos);
                        colors.Add(tile.col);
                    }
                    foreach (int t in quadTriangles)
                    {
                        triangles.Add(t + firstVert);
                    }
                }

            }
        BasicMeshData mData = new BasicMeshData(vertices.ToArray(), triangles.ToArray(), colors.ToArray());
        return mData;
    }

    private async Task GenerateColliders()
    {
        Debug.LogFormat("Generating {0} chunks: " + Time.realtimeSinceStartup, chunkTiles.Count);
        float ct = Time.realtimeSinceStartup;
        int count = 0;
        List<Dictionary<Vector3Int, ShipTile>> chunkList = chunkTiles.Values.ToList();
        int thread_count = 7;
        List<List<Dictionary<Vector3Int, ShipTile>>> chunkThreads = new List<List<Dictionary<Vector3Int, ShipTile>>>();
        int index = 0;
        while(chunkList.Count > 0)
        {
            if(chunkThreads.Count < thread_count)
            {
                chunkThreads.Add(new List<Dictionary<Vector3Int, ShipTile>>());
            }
            chunkThreads[index % thread_count].Add(chunkList[0]);
            chunkList.RemoveAt(0);
            index++;
        }
        List<Task<List<BasicMeshData>>> taskList = new List<Task<List<BasicMeshData>>>();
        foreach(List<Dictionary<Vector3Int, ShipTile>> chunkData in chunkThreads)
        {
            taskList.Add(BasicMeshDataset(chunkData));
        }
        List<BasicMeshData> basicMeshes = new List<BasicMeshData>();
        List<GameObject> chunkObjects = new List<GameObject>();
        for(int i = 0; i < chunkTiles.Count; i++ )
        {
            GameObject chunkObj = new GameObject("Chunk: " + chunkTiles.Keys.ElementAt(count));
            chunkObj.transform.position = Vector3.zero;
            chunkObj.transform.parent = transform;
            Mesh m = new Mesh();
            MeshFilter filter = chunkObj.AddComponent<MeshFilter>();
            filter.mesh = m;
            MeshRenderer render = chunkObj.AddComponent<MeshRenderer>();
            render.material = baseMat;
            chunkObjects.Add(chunkObj);
            count++;
        }
        foreach (Task<List<BasicMeshData>> task in taskList)
        {
            basicMeshes.AddRange(await task);
        }
        await new WaitForUpdate();
        for (int i = 0; i < basicMeshes.Count; i++)
        {
            GameObject chunkObj = chunkObjects[i];
            
            MeshFilter filter = chunkObj.GetComponent<MeshFilter>();
            Mesh m = filter.mesh;
            m.Clear();
            m.vertices = basicMeshes[i].vertices.ToArray();
            m.triangles = basicMeshes[i].triangles.ToArray();
            m.colors32 = basicMeshes[i].vertexColor;
            m.RecalculateBounds();
            m.RecalculateNormals();
            filter.mesh = m;
            MeshCollider col = chunkObj.AddComponent<MeshCollider>();
        }
        Debug.Log("Generated: " + (Time.realtimeSinceStartup - ct));
    }
}
