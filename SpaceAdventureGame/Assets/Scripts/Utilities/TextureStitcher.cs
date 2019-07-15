using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class TextureStitcher {

	public static Texture2D Stitch(string fileLocation, string saveLocation, int tileHeight, int tileWidth, int tileSize)
    {
        Texture2D stitchedTex = new Texture2D(tileSize * tileWidth, tileSize * tileHeight);
        Color32[] stitchedColors = stitchedTex.GetPixels32();
        string[,] localStrings = new string[tileWidth, tileHeight];
        byte[,][] localBytes = new byte[tileWidth, tileHeight][];
        Texture2D[,] localTextures = new Texture2D[tileWidth, tileHeight];
        for (int x = 0; x < tileWidth; x++)
        {
            for (int y = 0; y < tileHeight; y++)
            {
                localStrings[x,y] = string.Format("{2}/{0}-{1}.png", x, y, fileLocation);
            }
        }
        for (int x = 0; x < tileWidth; x++)
        {
            for (int y = 0; y < tileHeight; y++)
            {
                if (!File.Exists(localStrings[x, y]))
                {
                    Debug.Log(string.Format("{0} does not exist", localStrings[x, y]));
                }
                else
                {
                    localBytes[x, y] = File.ReadAllBytes(localStrings[x, y]);
                    ImageConversion.LoadImage(localTextures[x, y], localBytes[x, y]);
                    if(localTextures[x, y].width != tileSize || localTextures[x, y].height != tileSize)
                    {
                        Debug.Log(string.Format("{0} is wrong size", localStrings[x, y]));
                    }
                }
            }
        }
        for (int x = 0; x < tileWidth; x++)
        {
            for (int y = 0; y < tileHeight; y++)
            {
                Color32[] colorsToStitch = localTextures[x, y].GetPixels32();
                stitchedTex.SetPixels32(tileWidth * x, tileHeight * y, tileSize, tileSize, colorsToStitch);
            }
        }
        stitchedTex.Apply();
        return stitchedTex;
    }

}
