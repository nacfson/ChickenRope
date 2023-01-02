using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMoveManager : MonoBehaviour
{
   
    public void MoveStage01()
    {
        SceneManager.LoadScene("RopeTest");
        Debug.Log("Move to Stage01 Scene");
    }

    public void MoveStage02()
    {
        SceneManager.LoadScene("Stage01");
        Debug.Log("Move to Stage02 Scene");
    }

    public void MoveStage03()
    {
        SceneManager.LoadScene("Stage01");
        Debug.Log("Move to Stage03 Scene");
    }

    public void MoveStage04()
    {
        SceneManager.LoadScene("Stage01");
        Debug.Log("Move to Stage04 Scene");
    }


}
