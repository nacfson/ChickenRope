using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GrapplingHook hook;
    [SerializeField]
    private float _speed = 3f;
    [SerializeField]
    private float _jumpPower = 2f;
    private Rigidbody2D _rigid;
    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        hook = GetComponent<GrapplingHook>();   
    }

    public void OnMove(Vector2 input)
    {
        if(hook.isAttach)
        {
            transform.Translate(input * Time.fixedDeltaTime * _speed);

        }
    }
    public void OnJump()
    {
        _rigid.AddForce(Vector3.up * _jumpPower);   
    }
}
