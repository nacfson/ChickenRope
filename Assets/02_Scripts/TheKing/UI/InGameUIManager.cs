using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _timerText;

    private float _currentTime;

    void Awake()
    {
        _currentTime = 0f;
        StartCoroutine(TimerCor());
        Player.RopeDie += DieProcess;
    }

    public void DieProcess()
    {
        StopCoroutine(TimerCor());
        if(PlayerPrefs.GetFloat("BESTTIME") < _currentTime)
        {
            PlayerPrefs.SetFloat("BESTIME", _currentTime);
        }
    }

    IEnumerator TimerCor()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            _currentTime += 0.5f;
            _timerText.text = _currentTime.ToString();

        }
    }


}
