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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ring"))
        {
            Debug.Log("Success");
            joint2D.enabled = true;
            grappling.isAttach = true;
        }
    }
}
