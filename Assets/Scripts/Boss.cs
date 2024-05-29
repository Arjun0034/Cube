using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;

    private Animator anim;
    private Transform currentPoint;

    private void Start()
    {
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform;
    }

    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;

        if (currentPoint == pointB.transform)
        {
            anim.SetBool("JumpForward",true);
            anim.SetBool("JumpBackward",false);
            anim.SetBool("IsIdle", false);
        }
        else
        {
            anim.SetBool("JumpBackward", true);
            anim.SetBool("JumpForward", false);
            anim.SetBool("IsIdle", false);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
    }



}
