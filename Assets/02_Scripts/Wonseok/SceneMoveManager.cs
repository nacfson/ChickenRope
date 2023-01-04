using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SceneMoveManager : MonoBehaviour
{
   
    public void MoveStage01()
    {
        Debug.Log("Move to Stage01 Scene");
        SceneManager.LoadScene("Stage01");
        StageStart();
    }

    public void MoveStage02()
    {
        Debug.Log("Move to Stage02 Scene");
        SceneManager.LoadScene("Stage02");
        StageStart();
    }
    public void MoveStage03()
    {
        Debug.Log("Move to Stage03 Scene");
        SceneManager.LoadScene("Stage03");
        StageStart();
    }
    public void MoveStage04()
    {
        Debug.Log("Move to Stage04 Scene");
        SceneManager.LoadScene("Stage04");
        StageStart();
    }

    //public void MoveStage(string sceneName)
    //{
    //    SceneManager.LoadScene(sceneName);
    //    StageStart();
    //}

    public void StageStart()
    {
        SceneManager.LoadScene("InGameUI", LoadSceneMode.Additive);
        SceneManager.LoadScene("ClearPanel", LoadSceneMode.Additive);
    }
}
