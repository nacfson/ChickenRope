using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPoint : MonoBehaviour
{ 
    [SerializeField]
    private float _reproduceDelay = 5f;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.gameObject.GetComponent<Player>().SuperjumpCount = 1;

            collision.collider.gameObject.GetComponent<PlayerTest>().sp.color = Color.red;
            gameObject.SetActive(false);
            Invoke("ReProduce",_reproduceDelay);
        }
    }
    public void ReProduce()
    {
        gameObject.SetActive(true);
    }
}
