using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    GrapplingHook hook;
    [SerializeField]
    private float _ropeSpeed = 3f;
    private float _speed = 1f;
    [SerializeField]
    private float _jumpPower = 2f;
    [SerializeField]
    private LayerMask _layerMask;

    public int ropeHP = 3;


    private Rigidbody2D _rigid;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    private float input;

    public static UnityAction RopeDie;



    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigid = GetComponent<Rigidbody2D>();
        hook = GetComponent<GrapplingHook>();
        RopeDie += hook.RopeDead;
    }

    void Update()
    {
        input = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    private void ChangeRopeHealth(int plus)
    {
        ropeHP += plus;
        if(ropeHP <= 0)
        {
            RopeDie?.Invoke();
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ring")&& hook.isAttach)
        {
            ChangeRopeHealth(-1);
        }
    }



    public void OnMove()
    {
        if(Mathf.Abs(input) >0)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x + input * _speed * 0.2f,_rigid.velocity.y);
            FlipCharacter(input);
        }
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
        if(CheckGround())
        {
            _rigid.AddForce(Vector3.up * _jumpPower);   
        }
    }

    public bool CheckGround()
    {
        bool grounded = Physics2D.Raycast(transform.position,Vector2.down, 0.5f,_layerMask);
        Debug.Log(grounded);
        Debug.DrawRay(transform.position, Vector2.down, Color.blue, 0.2f);
        return grounded;
    }
}
