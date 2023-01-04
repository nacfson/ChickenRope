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
    public Player player;
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
            player = FindObjectOfType<Player>();
            saveData.playerPos = player.transform.position;
            Debug.Log(player.transform.position);

            saveData.SceneIndex = SceneManager.GetActiveScene().buildIndex;

            string json = JsonUtility.ToJson(saveData);
            File.WriteAllText(savePath + saveFileName, json);
            MiniTitleText.Instance.OnText("���� �Ϸ�");
        }
        catch { MiniTitleText.Instance.OnText("���� �� �� �����ϴ�."); }
    }
    public void Load()
    {
        try
        {
            if (File.Exists(savePath + saveFileName))
            {
                MiniTitleText.Instance.OnText("�ε� ����");

                string loadJson = File.ReadAllText(savePath + saveFileName);
                saveData = JsonUtility.FromJson<SaveData>(loadJson);
                player = FindObjectOfType<Player>();

                player.transform.position = saveData.playerPos;
            }
        }
        catch { MiniTitleText.Instance.OnText("�ε���� �ʾҽ��ϴ�."); }
    }
}
