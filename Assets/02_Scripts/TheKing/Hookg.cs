using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hookg : MonoBehaviour
{
    GrapplingHook grappling;
    public SpringJoint2D joint2D;
    public Transform player;
    private void Start()
    {
        grappling = GameObject.Find("Player").GetComponent<GrapplingHook>();
        joint2D = GetComponent<SpringJoint2D>();  
        player = FindObjectOfType<Player>().transform;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ring"))
        {
            Debug.Log("Success");
            joint2D.enabled = true;
            grappling.isAttach = true;
            joint2D.distance = Vector2.Distance(player.transform.position, collision.gameObject.transform.position) - 5f;
             
        }
    }
}
