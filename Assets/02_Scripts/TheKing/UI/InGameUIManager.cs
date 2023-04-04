using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class InGameUIManager : MonoBehaviour
{
    public static float CurrentTime
    {
        get
        {
            return _currentTime;
        }
    }

    [SerializeField]
    private TextMeshProUGUI _timerText;
    [SerializeField]
    private GameObject _topUI;
    private static float _currentTime;
    public bool canTimer;

    void Start()
    {
        StartTimer();
        GameManager.Instance.SaveLoadAction += SaveNLoadTimer;
        StartCoroutine(TimerCor());

        //GameManager.Instance.ClearAction += StopTimer;
        GameManager.Instance.ClearAction += DieProcess;
        GameManager.Instance.LoadSceneAction += StartTimer;
    }

    private void SaveNLoadTimer()
    {
        _currentTime = PlayerPrefs.GetFloat("CURRENTTIME");
        canTimer = true;
        _topUI.SetActive(true);
    }

    

    public void DieProcess()
    {
        StopCoroutine(TimerCor());

        if(PlayerPrefs.GetFloat("BESTTIME") < 1f)
        {
            PlayerPrefs.SetFloat("BESTTIME",_currentTime);
            PlayerPrefs.SetFloat("CURRENTTIME",_currentTime);
        }
        if(PlayerPrefs.GetFloat("BESTTIME") > _currentTime)
        {
            PlayerPrefs.SetFloat("BESTTIME", _currentTime);
            PlayerPrefs.SetFloat("CURRENTTIME",_currentTime);
        }
    }

    public void StopTimer()
    {
        canTimer = false;
        _topUI.SetActive(false);
    }

    public void StartTimer()
    {
        _currentTime = 0f;
        canTimer = true;
        _topUI.SetActive(true);
    }

    IEnumerator TimerCor()
    {
        while(canTimer)
        {
            yield return new WaitForSeconds(0.5f);
            _currentTime += 0.5f;
            _timerText.text = _currentTime.ToString("F0");
        }
    }
}
