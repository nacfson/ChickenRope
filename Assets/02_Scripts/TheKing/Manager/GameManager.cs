using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string clearIndexName = "CLEARINDEX";
    public UnityAction ClearAction;
    public UnityAction LoadSceneAction;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SaveClearScene()
    {
        if(PlayerPrefs.GetInt(clearIndexName) < SceneManager.GetActiveScene().buildIndex)
        {
            PlayerPrefs.SetInt(clearIndexName, SceneManager.GetActiveScene().buildIndex);
        }
    }

    public int LoadClearScene()
    {
        return PlayerPrefs.GetInt(clearIndexName);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
    [ContextMenu("LoadNextScene")]
    public void LoadNextScene()
    {
        SaveClearScene();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("InGameUI",LoadSceneMode.Additive);
        UISceneLoad();
        //AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        //while(!operation.isDone)
        //{
        //    return;
        //}
        LoadSceneAction?.Invoke();
        Debug.Log("LoadAction");
    }

    public void UISceneLoad()
    {
        SceneManager.LoadScene("InGameUI", LoadSceneMode.Additive);
        SceneManager.LoadScene("ClearPanel", LoadSceneMode.Additive);
    }
}
