using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public float superJumpValue = 70;
    public LayerMask a;     
    public bool below;
    public SpriteRenderer sp;

    private BoxCollider2D _boxcol;
    private Rigidbody2D _rigid;
    private Animator pAnimation;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        _rigid = GetComponent<Rigidbody2D>();
        _boxcol = GetComponent<BoxCollider2D>();
        pAnimation = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Speedtrab"))
        {
            _rigid.gravityScale = 5;
        }
    }
    public void SuperJump()
    {
        //_rigid.velocity = new Vector2(_rigid.velocity.x, 100f);
        Debug.Log("1");
        _rigid.AddForce(Vector2.up * superJumpValue, ForceMode2D.Impulse);
        StartCoroutine(Jump());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trab2"))
        {
            transform.position = new Vector3(0, 0, 0);
            Debug.Log("dd");
            Destroy(collision.gameObject);

        }
    }

    IEnumerator Jump()
    {
        sp.color = Color.white;
        pAnimation.SetBool("Jump", true);
        yield return new WaitForSeconds(1);
        pAnimation.SetBool("Jump", false);
    }


}
