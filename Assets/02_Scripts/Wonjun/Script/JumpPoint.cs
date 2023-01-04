using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPoint : MonoBehaviour
{ 
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.gameObject.GetComponent<PlayerTest>().jumpCount = 1;
            collision.collider.gameObject.GetComponent<PlayerTest>().sp.color = Color.red;
            Destroy(gameObject);
        }
    }
}
