using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InGameSceneManager : MonoBehaviour
{
    public void Start()
    {
        GameUIScene();
    }
    public void GameUIScene()
    {
        SceneManager.LoadScene("InGameUI",LoadSceneMode.Additive);
    }

}
