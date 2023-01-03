using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelDown : MonoBehaviour
{
    public Vector3 originPos;
    public void PanelMove()
    {
        transform.DOMoveY(550, 1f);
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
        GameManager.Instance.GoToMainMenu();
    }

    public void NextStageButton()
    {
        //다음 스테이지로 가는 버튼
        GameManager.Instance.LoadNextScene();
    }
}
