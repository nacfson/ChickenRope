using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPoint : MonoBehaviour
{
    public PlayerTest _player;

    private void Start()
    {

    }
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerTest>().jumpCount += 1;
            Destroy(gameObject);
        }
    }
}
