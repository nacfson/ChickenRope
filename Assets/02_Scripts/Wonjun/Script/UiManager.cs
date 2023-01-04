using DG.Tweening;
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
    [SerializeField] private GameObject exPanel;
    [SerializeField] private GameObject storyPanel;

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
    public void GameStart()//���� ����
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameExplain()// ���� ���� â ����
    {
        panel.SetActive(true);
    }
    public void ExControl()
    {
        exPanel.SetActive(true);
        panel.SetActive(false);
    }

    public void Story()
    {
        storyPanel.SetActive(true);
        panel.SetActive(false);
    }
    public void GameExQuit()// ���� ���� â ������
    {
        panel.SetActive(false);
    }
    public void ExControlQuit()// ���� ���� â ������
    {
        exPanel.SetActive(false);
        panel.SetActive(true);
    }
    public void StoryQuit()// ���� ���� â ������
    {
        storyPanel.SetActive(false);
        panel.SetActive(true);
        
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

    public void Exit()// ���� ���� ȭ�翡�� ���� ������
    {
        Application.Quit();
        Debug.Log("���ӳ�������");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
