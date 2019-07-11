using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMeshData
{
    public Vector3[] vertices;
    public int[] triangles;
    public Color32[] vertexColor;
    public BasicMeshData(Mesh m)
    {
        vertices = m.vertices;
        triangles = m.triangles;
        vertexColor = m.colors32;
    }

    public BasicMeshData(Vector3[] vertices, int[] triangles, Color32[] inColors)
    {
        this.triangles = triangles;
        this.vertices = vertices;
        vertexColor = inColors;
    }
}
