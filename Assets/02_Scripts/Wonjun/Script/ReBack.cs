using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReBack : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.transform.localPosition = new Vector3(0, 0, 0);
            Destroy(gameObject);
        }
    }
}
