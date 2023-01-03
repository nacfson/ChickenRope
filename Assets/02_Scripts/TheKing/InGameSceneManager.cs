using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InGameSceneManager : MonoBehaviour
{
    void Start()
    {
        GameUIScene();
    }

    public void GameUIScene()
    {
        GameManager.Instance.UIScenes();
    }

}
