using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Trab2 : MonoBehaviour
{
    private Rigidbody2D _rigid;

    private void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _rigid.gravityScale = 0;
    }

    private void Update()
    {
    }
    


}
