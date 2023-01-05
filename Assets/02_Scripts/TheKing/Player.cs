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
    private PlayerTest PlayerTest;

    private float input;

    public static UnityAction RopeDie;

    public int SuperjumpCount;

    public bool canMove;
    public Transform playerParentTr;



    private void Awake()
    {
        playerParentTr = transform.parent;
        PlayerTest = GetComponent<PlayerTest>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigid = GetComponent<Rigidbody2D>();
        hook = GetComponent<GrapplingHook>();
        _cameraShake = GetComponentInChildren<CameraShake>();
        RopeDie += hook.RopeDead;
        canMove = true;
        GameManager.Instance.ClearAction += ClearGame;
    }


    void Update()
    {
        input = Input.GetAxis("Horizontal");
        //playerParentTr.position = this.transform.position;
        //Debug.Log(_rigid.velocity.y);
    }
    public void ClearGame()
    {
        try 
        {
            StartCoroutine(ClearGameCor());

        }
        catch
        {
            GameManager.Instance.GoToMainMenu();
        }
    }
    private void FixedUpdate()
    {
        OnMove();
    }

    private void ChangeRopeHealth(int plus)
    {
        ropeHP += plus;
        if (ropeHP <= 0)
        {
            RopeDie?.Invoke();
        }

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ring") && hook.isAttach)
        {
            //ChangeRopeHealth(-1);

        }
    }



    public void OnMove()
    {
        if (Mathf.Abs(input) > 0)
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
        if (x > 0)
        {
            _spriteRenderer.flipX = true;
            _animator.SetBool("run", true);
        }
        else if (x < 0)
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
        if (CheckGround())
        {
            if (SuperjumpCount >= 1) //��������
            {
                PlayerTest.SuperJump();
                SoundManager.Instance.EffectSource.PlayOneShot(SoundManager.Instance.PlaySound(2));

                SuperjumpCount--;
            }
            else if(SuperjumpCount <=0)// �⺻����
            {
                SoundManager.Instance.EffectSource.PlayOneShot(SoundManager.Instance.PlaySound(5));
                _rigid.AddForce(Vector3.up * _jumpPower);
            }
        }
    }
    public void Jump()
    {
        _rigid.AddForce(Vector3.up * _jumpPower);
    }

    public bool CheckGround()
    {
        bool grounded = Physics2D.Raycast(transform.position, Vector2.down, 0.5f, _layerMask);
        return grounded;
    }

    IEnumerator ClearGameCor()
    {
        canMove = false;
        _rigid.gravityScale = 0f;
        _rigid.velocity = Vector3.zero;
        yield return new WaitForSeconds(3f);
        canMove = true;
        _rigid.gravityScale = 1f;

    }
}
