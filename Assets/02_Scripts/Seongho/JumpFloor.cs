using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFloor : MonoBehaviour
{
    public float JumpPower = 10f;
    public void Update()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.position,new Vector2(1,1) ,90, Vector2.up);
        if (hit.collider && hit.collider.CompareTag("Player"))
        {
            Debug.Log("!");
            Rigidbody2D rigid = hit.collider.GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        }
        //Debug.DrawRay(transform.position, Vector2.up,Color.red ,1);
    }
}
