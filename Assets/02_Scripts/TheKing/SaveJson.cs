using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SaveData
{
    public Vector2 playerPos;
}

public class SaveJson : MonoBehaviour
{
    private SaveData _saveData;
    private string _savePath;
    private string _saveFileName ="/SaveFile.txt";
    private Transform _player;
    void Awake()
    {
        _saveData = new SaveData();
        //_saveData = Application.dataPath + "/SaveData/";
        if(!Directory.Exists(_savePath))
        {
            Directory.CreateDirectory(_savePath);
        }
    }

    public void Save()
    {
        //_player = GameObject
        string json = JsonUtility.ToJson(_saveData);
        File.WriteAllText(_savePath + _saveFileName , json);
    }
}
