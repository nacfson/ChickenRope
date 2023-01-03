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
    [SerializeField]
    private float _maxSpeed = 5f;

    public int ropeHP = 3;


    private Rigidbody2D _rigid;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private CameraShake _cameraShake;

    private float input;

    public static UnityAction RopeDie;
    public int jumpCount;
    public bool canMove;



    private void Awake()
    {
        jumpCount = 1;
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigid = GetComponent<Rigidbody2D>();
        hook = GetComponent<GrapplingHook>();
        _cameraShake = GetComponentInChildren<CameraShake>();
        RopeDie += hook.RopeDead;
        canMove = true;
        //GameManager.Instance.ClearAction += ClearGame;
    }

    public void Start()
    {
        //GameManager.Instance.ClearAction += ClearGame;
    }

    void Update()
    {
        input = Input.GetAxis("Horizontal");
        //Debug.Log(_rigid.velocity.y);
    }
    public void ClearGame()
    {
        StartCoroutine(ClearGameCor());
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
            //ChangeRopeHealth(-1);
        }
    }

    

    public void OnMove()
    {
        if(Mathf.Abs(input) >0)
        {
            if (canMove)
            {
                _rigid.velocity = new Vector2(Mathf.Clamp(_rigid.velocity.x + input * 0.2f, -_maxSpeed, _maxSpeed), _rigid.velocity.y);
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
        if(CheckGround())
        {
            _rigid.AddForce(Vector3.up * _jumpPower);
            jumpCount--;
        }
    }
    public void Jump()
    {
        _rigid.AddForce(Vector3.up * _jumpPower);
    }

    public bool CheckGround()
    {
        bool grounded = Physics2D.Raycast(transform.position,Vector2.down, 0.5f,_layerMask);
        if(_rigid.velocity.y <= -0.3f && grounded)
        {
            Debug.Log("CameraShake");
            _cameraShake.CrashShake();
        }
        return grounded;
    }

    IEnumerator ClearGameCor()
    {
        _rigid.Sleep();
        yield return new WaitForSeconds(3f);
        _rigid.WakeUp();
    }
}
