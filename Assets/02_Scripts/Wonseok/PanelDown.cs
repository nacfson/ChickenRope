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
        //�޴��� ���� ��ư
    }

    public void NextStageButton()
    {
        //���� ���������� ���� ��ư
    }
}
