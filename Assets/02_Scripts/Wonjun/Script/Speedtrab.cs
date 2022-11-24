using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedtrab : MonoBehaviour
{
    private PlayerTest playerTest;

    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject.Find("testPlayer").GetComponent<Rigidbody2D>().gravityScale = 5;
        }
    }
}
