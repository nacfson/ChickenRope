using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelDown : MonoBehaviour
{
    public void PanelMove()
    {
        Invoke("DelayMove", 3f);
    }
    void DelayMove()
    {
        transform.DOMoveY(550, 1f);

    }
    private void Awake()
    {
        GameManager.Instance.ClearAction += PanelMove;
    }

    public void MenuButton()
    {
        GameManager.Instance.GoToMainMenu();
    }

    public void NextStageButton()
    {
        GameManager.Instance.LoadNextScene();
        //다음 스테이지로 가는 버튼
    }
}
