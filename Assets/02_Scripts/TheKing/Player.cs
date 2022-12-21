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
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
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
        FlipCharacter(input);


        _rigid.AddForce(Vector3.right * input * _speed * Time.deltaTime,ForceMode2D.Impulse);
        
    }
    void FlipCharacter(float x)
    {
        if(x > 0 )
        {
            _spriteRenderer.flipX = true;
            _animator.SetBool("run",true);
        }
        else if( x < 0)
        {
            _spriteRenderer.flipX = false;
            _animator.SetBool("run", true);
        }
        else
        {
            _animator.SetBool("run", false);
        }
    }
    public void OnJump()
    {
        _rigid.AddForce(Vector3.up * _jumpPower);   
    }
}
