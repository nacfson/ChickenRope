using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public LayerMask a;
    public bool below;
    SpriteRenderer sp;



    private BoxCollider2D _boxcol;
    private Rigidbody2D _rigid;
    private Animator pAnimation;


    public int jumpCount = 1;


    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        _rigid = GetComponent<Rigidbody2D>();
        //reback = GameObject.Find("trab").GetComponent<ReBack>();
        _boxcol = GetComponent<BoxCollider2D>();
        pAnimation = GetComponent<Animator>();
        Debug.Log(pAnimation + "dds");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Speedtrab"))
        {
            _rigid.gravityScale = 5;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        below = Physics2D.Raycast(transform.position, Vector2.down, 3f, a);

        


        
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount >=1 && below == true)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, 10f);
            jumpCount--;
            StartCoroutine(Jump());
        }

        

       

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("trab2"))
        {
        transform.position = new Vector3(0, 0, 0);
        Debug.Log("dd");
        Destroy(collision.gameObject);

        }
        
    }

    IEnumerator Jump()
    {
        pAnimation.SetBool("Jump", true);
        yield return new WaitForSeconds(1);
        pAnimation.SetBool("Jump", false);
    }
    

}
