using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionCheck : MonoBehaviour
{
    public static UnityAction DieObstacle;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("DieObstacle"))
        {
            DieObstacle?.Invoke();
        }
    }
}
