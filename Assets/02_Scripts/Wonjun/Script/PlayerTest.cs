using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public LayerMask a;
    public bool below;
    SpriteRenderer sp;


    [SerializeField] private ReBack reback;
    [SerializeField] private bool back;

    private BoxCollider2D _boxcol;
    private Rigidbody2D _rigid;
    private Animator pAnimation;


    public float Speed = 3f;
    public int jumpCount = 1;
    public float returntime = 10;

    public bool Back { get => back; set => back = value; }

    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        back = false;
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

         returntime += Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.R) && back == true && returntime <= 10)
        {
            transform.position = reback.Backpos;
            back = false;
            returntime = 0;
        }


        
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
