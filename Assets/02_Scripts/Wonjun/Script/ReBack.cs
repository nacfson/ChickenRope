using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReBack : MonoBehaviour
{
    private PlayerTest _player;
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 backpos;

    public Vector3 Backpos { get => backpos; set => backpos = value; }

    private void Start()
    {
        _player = GameObject.Find("testPlayer").GetComponent<PlayerTest>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            _player.Back = true;
            _player.returntime = 0;
            Backpos = transform.position;
            player.transform.localPosition = new Vector3(0, 0, 0);
            Destroy(gameObject);
            
        }
    }
}
