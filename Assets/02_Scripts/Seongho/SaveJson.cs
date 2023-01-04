using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SaveData
{
    public Vector2 playerPos;
    public int SceneIndex;
}

public class SaveJson : MonoBehaviour
{

    private SaveData saveData;
    private string savePath;
    private string saveFileName = "/SaveTxt.txt";
    public Transform player;
    void Awake()
    {

        saveData = new SaveData();
        savePath = Application.dataPath + "/SaveData/";

        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }
    }
    public void Save()
    {
        try
        {
            player = GameObject.Find("FinalPlayer").transform;
            saveData.playerPos = player.transform.position;
            Debug.Log(player.transform.position);

            saveData.SceneIndex = SceneManager.GetActiveScene().buildIndex;

            string json = JsonUtility.ToJson(saveData);
            File.WriteAllText(savePath + saveFileName, json);
            MiniTitleText.Instance.OnText("저장 완료");
        }
        catch { MiniTitleText.Instance.OnText("저장 할 수 없습니다."); }
    }
    public void Load()
    {
        Debug.Log("123");
        if (File.Exists(savePath + saveFileName))
        {
            Debug.Log("1234");
            player = GameObject.Find("FinalPlayer").transform;
            Debug.Log(player.transform.position);

            string loadJson = File.ReadAllText(savePath + saveFileName);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);
            player.position = saveData.playerPos;
        }
    }
}
