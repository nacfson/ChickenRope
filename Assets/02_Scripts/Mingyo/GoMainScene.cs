using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMainScene : MonoBehaviour
{
    public void GOMainBtn()
    {
        SceneManager.LoadScene("StartScene");
    }
}
