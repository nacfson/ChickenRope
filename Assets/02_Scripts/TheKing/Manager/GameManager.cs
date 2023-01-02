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


    private void Awake()
    {
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

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
