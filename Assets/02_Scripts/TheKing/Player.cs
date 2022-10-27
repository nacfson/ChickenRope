using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector3(x, 0,0));
    }
}
