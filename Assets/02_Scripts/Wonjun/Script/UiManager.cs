using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
   // public static UiManager Instance;
    public UnityEvent<bool> OnResultData;


    public int saveSceneIndex;
    private string saveFileName = "/SaveTxt.txt";
    private SaveData saveData;

    SaveJson saveJson;

    [SerializeField] private GameObject panel;

    private void Awake()
    {
        string savePath = Application.dataPath + "/SaveData/";
        saveData = new SaveData();
        if (!File.Exists(savePath))
        {
            string loadJson = File.ReadAllText(savePath + saveFileName);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);
            saveSceneIndex = saveData.SceneIndex;
        }

       /* if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else Destroy(gameObject);*/

        OnResultData?.Invoke(File.Exists(Application.dataPath + "/SaveData/SaveTxt.txt"));

    }
    public void GameStart()//게임 시작
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameExplain()// 게임 설명 창 띄우기
    {
        panel.SetActive(true);
    }
    public void GameExQuit()// 게임 설명 창 나가기
    {
        panel.SetActive(false);
    }
    public void GameLoad()
    {
        StartCoroutine("load");
    }
    IEnumerator load()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(saveSceneIndex);
        while (!asyncOperation.isDone) yield return null;

        saveJson = FindObjectOfType<SaveJson>();
        saveJson.Load();
        Destroy(gameObject);
    }

    public void Exit()// 게임 시작 화며에서 게임 나가기
    {
        Application.Quit();
        Debug.Log("게임나가지기");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
