using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelDown : MonoBehaviour
{
    public void PanelMove()
    {
        transform.DOMoveY(550, 1f);
    }

    private void Start()
    {
        PanelMove(); 
    }

    public void MenuButton()
    {
        //메뉴로 가는 버튼
    }

    public void NextStageButton()
    {
        //다음 스테이지로 가는 버튼
    }
}
