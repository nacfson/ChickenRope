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
    private string saveFileName ="/SaveTxt.txt";
    private Player player;
    void Awake() 
    {
        saveData = new SaveData();
        savePath = Application.dataPath + "/SaveData/";
        player = FindObjectOfType<Player>();

        if(!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }
    }
    public void Save()
    {
        saveData.playerPos = player.transform.position;
        saveData.SceneIndex = SceneManager.GetActiveScene().buildIndex;

        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(savePath + saveFileName , json);
        Debug.Log("저장 완료");
    }
    public void Load()
    {
        if (!File.Exists(savePath))
        {
            string loadJson = File.ReadAllText(savePath + saveFileName);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);
            player.transform.position = saveData.playerPos;
        }
    }
}
