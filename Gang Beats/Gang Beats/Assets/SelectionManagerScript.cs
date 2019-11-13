using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;
using System.IO;
using UnityEngine.UI;
public class SelectionManagerScript : MonoBehaviour
{
    public Texture2D inside;
    public static Texture2D LoadPNG(string filePath)
    {

        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
        }
        return tex;
    }

    // Start is called before the first frame update
    void Start()
    {
        // inside = Resources.Load("Grass.png") as Texture;
        inside = LoadPNG("../images/Grass.png");
        Rect rect1 = new Rect(300, 0, 200, 100);

        GUI.DrawTexture(rect1, inside);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
