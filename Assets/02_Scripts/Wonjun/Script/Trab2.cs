using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Trab2 : MonoBehaviour
{
    
    private Rigidbody2D _rigid;

    public Collider2D[] colliders;
    private void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _rigid.gravityScale = 0;
    }

    private void Update()
    {
    }
    


}
