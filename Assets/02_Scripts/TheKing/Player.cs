using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GrapplingHook hook;
    [SerializeField]
    private float _speed = 100f;
    [SerializeField]
    private float _jumpPower = 2f;
    private Rigidbody2D _rigid;
    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        hook = GetComponent<GrapplingHook>();   
    }

    void Update()
    {
        OnMove();
    }

    public void OnMove()
    {
        float input = Input.GetAxis("Horizontal");
        if(true)
        {
            Debug.Log(input);
            Debug.Log(_speed);

            _rigid.AddForce(Vector3.right * input * _speed * Time.deltaTime,ForceMode2D.Impulse);
        }
    }
    public void OnJump()
    {
        _rigid.AddForce(Vector3.up * _jumpPower);   
    }
}
