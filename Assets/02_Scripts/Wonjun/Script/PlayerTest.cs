using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    public LayerMask a;
    public bool below;

    private Rigidbody2D _rigid;
    public float Speed = 3f;
    public int jumpCount = 1;
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();   
        
    }

    // Update is called once per frame
    void Update()
    {
        below = Physics2D.Raycast(transform.position, Vector2.down, 3f, a);


        float x = Input.GetAxisRaw("Horizontal");
        Vector3 dir = new Vector3(x, 0, 0);  
        transform.position += dir * Speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount >=1 && below == true)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, 20f);
            jumpCount--;
        }

    }

}
