using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SceneMoveManager : MonoBehaviour
{
   
    public void MoveStage01()
    {
<<<<<<< Updated upstream
        Debug.Log("Move to Stage01 Scene");
=======
        SceneManager.LoadScene("RopeTest");
        StageStart();
>>>>>>> Stashed changes
    }

    public void MoveStage02()
    {
<<<<<<< Updated upstream
        Debug.Log("Move to Stage02 Scene");
=======
        SceneManager.LoadScene("Stage01");
        StageStart();
>>>>>>> Stashed changes
    }
    public void MoveStage03()
    {
<<<<<<< Updated upstream
        Debug.Log("Move to Stage03 Scene");
=======
        SceneManager.LoadScene("Stage01");
        StageStart();
>>>>>>> Stashed changes
    }
    public void MoveStage04()
    {
<<<<<<< Updated upstream
        Debug.Log("Move to Stage04 Scene");
=======
        SceneManager.LoadScene("Stage01");
        StageStart();
    }

    public void MoveStage(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        StageStart();
>>>>>>> Stashed changes
    }
}
