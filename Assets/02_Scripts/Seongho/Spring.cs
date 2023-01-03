using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public float springUpValue;
    public float springValue;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpriteRenderer spriteRenderer = collision.gameObject.GetComponent<SpriteRenderer>();
            Rigidbody2D rigid = collision.gameObject.GetComponent<Rigidbody2D>();
            rigid.AddForce(Vector2.up * springUpValue, ForceMode2D.Impulse);
            if (spriteRenderer.flipX == true)
                rigid.AddForce(Vector2.left * springValue, ForceMode2D.Impulse);
            else rigid.AddForce(Vector2.right * springValue, ForceMode2D.Impulse);
        }
    }
}
