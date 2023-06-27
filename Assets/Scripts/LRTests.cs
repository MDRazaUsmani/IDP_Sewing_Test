using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Linq;
using System.Collections.Generic;
/*
//textureMode: Tiled or Stretched
public class LRTests : MonoBehaviour
{
    public LineTextureMode textureMode = LineTextureMode.Stretch;
    public float tileAmount = 1.0f;
    private LineRenderer lr;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.material = AssetDatabase.GetBuiltinExtraResource<Material>("Default-Particle.mat");

        // Set some positions
        Vector3[] positions = new Vector3[3];
        positions[0] = new Vector3(-2.0f, -1.0f, 0.0f);
        positions[1] = new Vector3(0.0f, -0.5f, 0.0f);
        positions[2] = new Vector3(2.0f, -1.0f, 0.0f);
        lr.positionCount = positions.Length;
        lr.SetPositions(positions);
    }

    void Update()
    {
        lr.textureMode = textureMode;
        lr.material.SetTextureScale("_MainTex", new Vector2(tileAmount, 1.0f));
    }

    void OnGUI()
    {
        textureMode = GUI.Toggle(new Rect(25, 25, 200, 30), textureMode == LineTextureMode.Tile, "Tiled") ? LineTextureMode.Tile : LineTextureMode.Stretch;

        if (textureMode == LineTextureMode.Tile)
        {
            GUI.Label(new Rect(25, 60, 200, 30), "Tile Amount");
            tileAmount = GUI.HorizontalSlider(new Rect(125, 65, 200, 30), tileAmount, 0.1f, 4.0f);
        }
    }
}*/


//Module: OnCollisionEnter in Update() using Bool
//Notes: Updates collision position every frame = points generated every frame = problem
public class LRTests:MonoBehaviour{
    public LineRenderer lr;
    
    
    public List<Vector3> points = new List<Vector3>();
    private void Start() {

    }
       
     
    void OnCollisionEnter(Collision col) {
        if(col.gameObject.name == "Canvas"){
           
        Vector3 v  = transform.position;
        Debug.Log("Collision at "+v);
        points.Add(v);
        lr.positionCount = points.Count;
        lr.SetPosition(points.Count-1,v);
       
        
        }
    }
   

}

