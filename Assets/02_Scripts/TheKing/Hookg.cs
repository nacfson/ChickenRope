using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hookg : MonoBehaviour
{
    GrapplingHook grappling;
    public DistanceJoint2D joint2D;
    private void Start()
    {
        grappling = GameObject.Find("Player").GetComponent<GrapplingHook>();
        joint2D = GetComponent<DistanceJoint2D>();  


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ring"))
        {
            Debug.Log("Success");
            joint2D.enabled = true;
            grappling.isAttach = true;
        }
    }
}
