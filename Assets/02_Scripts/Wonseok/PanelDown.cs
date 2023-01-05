using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class PanelDown : MonoBehaviour
{

    public Vector3 originPos;
    [SerializeField]
    private TextMeshProUGUI _timerText;
    public void PanelMove()
    {
        SoundManager.Instance.PlayBGM(5);
        transform.DOMoveY(550, 1f);
        _timerText.text = $"Current Time : {InGameUIManager.CurrentTime} \n Best Time : {PlayerPrefs.GetFloat("BESTTIME")}";
        //transform.position = originPos;
    }

    public void InvokePanelMove()
    {
        Invoke("PanelMove", 2.5f);
    }

    private void Start()
    {
        //PanelMove(); 
        originPos = transform.position;
        GameManager.Instance.ClearAction += InvokePanelMove;
    }

    public void MenuButton()
    {
        //메뉴로 가는 버튼
        GameManager.Instance.GoToMainMenu();
    }

    public void NextStageButton()
    {
        //다음 스테이지로 가는 버튼
        GameManager.Instance.LoadNextScene();
    }
}
