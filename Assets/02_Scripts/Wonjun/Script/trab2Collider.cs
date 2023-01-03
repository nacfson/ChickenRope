using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trab2Collider : MonoBehaviour
{
    [SerializeField] private Trab2 _trab2;

    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject.Find("trab2").GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
}
