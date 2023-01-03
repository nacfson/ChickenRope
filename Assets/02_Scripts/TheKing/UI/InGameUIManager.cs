using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _timerText;
    [SerializeField]
    private GameObject _topUI;
    private float _currentTime;
    public bool canTimer;

    void Awake()
    {
        StartTimer();
        StartCoroutine(TimerCor());
        Player.RopeDie += DieProcess;
        GameManager.Instance.ClearAction += StopTimer;
        GameManager.Instance.LoadSceneAction += StartTimer;
    }

    public void DieProcess()
    {
        StopCoroutine(TimerCor());


        if(PlayerPrefs.GetFloat("BESTTIME") < _currentTime)
        {
            PlayerPrefs.SetFloat("BESTTIME", _currentTime);
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
            _timerText.text = _currentTime.ToString();
        }
    }
}
