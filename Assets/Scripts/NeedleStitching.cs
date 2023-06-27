using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class NeedleStitching : MonoBehaviour
{
    // The canvas object
    public GameObject canvas;

    // The needle object
    public GameObject needle;

    // The thread prefab
    public GameObject threadPrefab;

    // The distance between thread points
    public float threadSpacing = 0.1f;

    // Update is called once per frame
    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Perform the raycast and check for hit on the canvas
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == canvas)
            {
                // Get the hit point on the canvas
                Vector3 stitchPosition = hit.point;

                // Instantiate a new needle object at the hit position
                GameObject newNeedle = Instantiate(needle, stitchPosition, Quaternion.identity);

                // Attach a NeedleCollision script to the needle object
                NeedleCollision needleCollision = newNeedle.AddComponent<NeedleCollision>();
                needleCollision.threadPrefab = threadPrefab;
                needleCollision.threadSpacing = threadSpacing;
            }
        }
    }
}

public class NeedleCollision : MonoBehaviour
{
    // The thread prefab
    public GameObject threadPrefab;

    // The distance between thread points
    public float threadSpacing = 0.1f;

    // Called when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        // Check if colliding with the canvas
        if (collision.collider.gameObject.CompareTag("Canvas"))
        {
            // Get the contact point
            ContactPoint contactPoint = collision.GetContact(0);

            // Calculate the direction and distance between thread points
            Vector3 direction = (contactPoint.point - contactPoint.normal) - contactPoint.point;
            float distance = direction.magnitude;

            // Calculate the number of thread points based on spacing
            int threadPointCount = Mathf.RoundToInt(distance / threadSpacing);

            // Instantiate the thread points
            for (int i = 0; i < threadPointCount; i++)
            {
                Vector3 threadPointPosition = contactPoint.point + (direction.normalized * (i * threadSpacing));
                Instantiate(threadPrefab, threadPointPosition, Quaternion.identity);
            }
        }
    }
}