using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] GameObject panel;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(SetActive());
        }
    }
    public bool SetActive()
    {
        if (panel.activeInHierarchy == false)
            return true;
        else return false;
    }
}
