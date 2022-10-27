using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    public void GameStart(string name)//���� ����
    {
        SceneManager.LoadScene(name);
    }
    public void GameExplain()// ���� ���� â ����
    {
        panel.SetActive(true);
    }
    public void GameExQuit()// ���� ���� â ������
    {
        panel.SetActive(false);
    }

    public void Exit()// ���� ���� ȭ�翡�� ���� ������
    {
        Application
            .Quit();
        Debug.Log("���ӳ�������");
    }

}
