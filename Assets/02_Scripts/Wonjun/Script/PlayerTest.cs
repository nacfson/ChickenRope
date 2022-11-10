using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public LayerMask a;
    public bool below;

    private ReBack reback;
    [SerializeField] private bool back;

    private Rigidbody2D _rigid;
    public float Speed = 3f;
    public int jumpCount = 1;
    public float returntime = 10;

    public bool Back { get => back; set => back = value; }

    // Start is called before the first frame update
    void Start()
    {
        back = false;
        _rigid = GetComponent<Rigidbody2D>();
        reback = GameObject.Find("trab").GetComponent<ReBack>();
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

        float x = Input.GetAxisRaw("Horizontal");
        Vector3 dir = new Vector3(x, 0, 0);  
        transform.position += dir * Speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount >=1 && below == true)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, 20f);
            jumpCount--;
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

}
