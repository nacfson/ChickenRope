using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SceneMoveManager : MonoBehaviour
{
   
    public void MoveStage01()
    {
        SceneManager.LoadScene("Stage01");
        MainTitleText.Instance.OnText("Move to Stage01 Scene");
        StageStart();
    }

    public void MoveStage02()
    {
        SceneManager.LoadScene("Stage02");
        MainTitleText.Instance.OnText("Move to Stage02 Scene");
        StageStart();
    }
    public void MoveStage03()
    {
        SceneManager.LoadScene("Stage03");
        MainTitleText.Instance.OnText("Move to Stage03 Scene");
        StageStart();
    }
    public void MoveStage04()
    {
        SceneManager.LoadScene("Stage04");
        MainTitleText.Instance.OnText("Move to Stage04 Scene");
        StageStart();
        GameManager.Instance.SaveClearScene();
    }

    //public void MoveStage(string sceneName)
    //{
    //    SceneManager.LoadScene(sceneName);
    //    StageStart();
    //}
    public void MainMenu()
    {
        SceneManager.LoadScene("StartScene");
        MainTitleText.Instance.OnText("Move to MainMenu");
    }
    public void StageStart()
    {
        SceneManager.LoadScene("InGameUI", LoadSceneMode.Additive);
        SceneManager.LoadScene("ClearPanel", LoadSceneMode.Additive);
    }
}
