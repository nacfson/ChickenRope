using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GetInputs : MonoBehaviour
{
    public UnityEvent leftMouseClicked;



    void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            leftMouseClicked?.Invoke();
        }
    }
}
