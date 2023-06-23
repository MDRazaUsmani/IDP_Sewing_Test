using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sewing : MonoBehaviour
{
    int x = 1;
    public int lengthOfLineRenderer, numCapVertices, numCornerVertices;
    public float lineWidth;
    private LineRenderer lineRenderer;


    void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = lineWidth;
        lineRenderer.positionCount = lengthOfLineRenderer;
        lineRenderer.numCapVertices = numCapVertices;
        lineRenderer.numCornerVertices = numCornerVertices;
        lineRenderer.loop = false;
       // lineRenderer.useWorldSpace = false;
       // print(lineRenderer.GetPosition(0));
        lineRenderer.SetPosition(0, transform.position);
       // lineRenderer.textureMode = LineTextureMode.Tile;
      
        
    }

    void  OnCollisionEnter(Collision col)
    {
        
        if(col.gameObject.name == "Canvas"){
            lineRenderer.SetPosition(x, transform.position);
          //  Debug.DrawLine(transform.position, new Vector3(x,0,0),Color.red,3f, false);
            Debug.Log("Collision at "+transform.position);
            x++;
        }
    }

}
