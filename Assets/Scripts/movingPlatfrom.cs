using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatfrom : MonoBehaviour
{
    public float speed;
    private int startingPoint;
    public Transform[] points; // an array of transfrom points (position where the platform needs to move)


    private int i; //index of the array

    private Vector3 initialScale;


    void Start()
    {
        transform.position = points[startingPoint].position;  // setting the position of the platform to the position of one of the points using index "StartingPoint"

        // Store the initial scale 
        initialScale = transform.localScale;
    }

    void LateUpdate()
    {
        // Ensure the scale remains locked to the initial scale
        transform.localScale = initialScale;
    }

    void Update()
    {
        //checking the distance of the platform and the point 
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i == points.Length)  //check if the platform was on the last point after the index increase
            {
                i = 0; // reset the index 
            }
        }

        //moving the platform to the point position with the index "i"
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
