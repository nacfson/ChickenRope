using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trab2 : MonoBehaviour
{
    private Rigidbody2D _rigid;
    private void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _rigid.gravityScale -= 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _rigid.gravityScale += 1;
        }
    }
}
