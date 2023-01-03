using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReBack : MonoBehaviour
{
    private PlayerTest _player;
    private Player _player1;
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 backpos;
    Animator anim;
    private bool isStop;

    public Vector3 Backpos { get => backpos; set => backpos = value; }

    private void Start()
    {
        anim = GetComponent<Animator>();
        _player = GameObject.Find("Player").GetComponent<PlayerTest>();
        _player1 = GameObject.Find("Player").GetComponent<Player>();
            isStop = true;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player") &&isStop)
        {
            Rigidbody2D rigid = collision.gameObject.GetComponent<Rigidbody2D>();
            StartCoroutine(trabCol(rigid));
            
            isStop = false;
        }
    }
    public void trab1()
    {
        player.transform.localPosition = new Vector3(0, 0, 0);
        Destroy(gameObject);
    }

    IEnumerator trabCol(Rigidbody2D rigid)
    {
        Vector2  vec = rigid.velocity;
        rigid.velocity = Vector2.zero;
        Debug.Log("dd");
        yield return new WaitForSeconds(2f);
        rigid.WakeUp();
        rigid.velocity = vec;
        _player.Back = true;
        _player.returntime = 0;
        Backpos = transform.position;
        anim.SetTrigger("trabcl");

    }
}
