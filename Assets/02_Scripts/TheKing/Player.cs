using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    GrapplingHook hook;
    [SerializeField]
    private float _ropeSpeed = 3f;
    private float _speed = 7.5f;
    [SerializeField]
    private float _jumpPower = 2f;

    public int ropeHP = 3;


    private Rigidbody2D _rigid;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    public UnityAction RopeDie;



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
        OnMove();
    }

    private void ChangeRopeHealth(int plus)
    {
        Debug.Log("ChangeRopeHealthStarted");
        ropeHP += plus;
        Debug.Log(ropeHP);
        if(ropeHP <= 0)
        {
            Debug.Log("RopeDieInvoke");
            RopeDie?.Invoke();
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ring"))
        {
            Debug.Log("TriggerStarted");
            ChangeRopeHealth(-1);
        }
    }



    public void OnMove()
    {
        float input = Input.GetAxis("Horizontal");
        if(Mathf.Abs(input) >0)
        {
            if (hook.isAttach)
            {
                    _rigid.AddForce(new Vector2(input * _ropeSpeed, _rigid.velocity.y).normalized);
                //_rigid.velocity = new Vector2((_rigid.velocity.x + input * _speed / 100),_rigid.velocity.y).normalized;
                Debug.Log("Attach");

            }
            else
            {
                Debug.Log("RUN");
                    _rigid.AddForce(Vector2.right * input * _speed);
                    //_rigid.velocity = new Vector2((_rigid.velocity.x + input * _speed / 100),_rigid.velocity.y).normalized;
            }
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
        Debug.Log("Jump");
        _rigid.AddForce(Vector3.up * _jumpPower );   
    }
}
