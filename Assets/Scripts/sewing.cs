using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sewing : MonoBehaviour
{
    int x = 1;
    public int numCapVertices, numCornerVertices;
    public float lineWidth;
    private LineRenderer lineRenderer;
     public List<Vector3> points = new List<Vector3>();
    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = lineWidth;
       
        lineRenderer.numCapVertices = numCapVertices;
        lineRenderer.numCornerVertices = numCornerVertices;
        lineRenderer.loop = false;
        
       // lineRenderer.useWorldSpace = false;
       // print(lineRenderer.GetPosition(0));
        //lineRenderer.SetPosition(0, transform.position);
       // lineRenderer.textureMode = LineTextureMode.Tile;
      
        
    }

    void  OnCollisionEnter(Collision col)
    {   // transform to world coordinate
         // change input type to mouse position
         // undo - eraser
         if(col.gameObject.name == "Canvas"){
           
        Vector3 v  = transform.position;
        Debug.Log("Collision at "+v);
        points.Add(v);
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count-1,v);
       
        
        }
    }

}

