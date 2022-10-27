using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    public void GameStart(string name)//게임 시작
    {
        SceneManager.LoadScene(name);
    }
    public void GameExplain()// 게임 설명 창 띄우기
    {
        panel.SetActive(true);
    }
    public void GameExQuit()// 게임 설명 창 나가기
    {
        panel.SetActive(false);
    }

    public void Exit()// 게임 시작 화며에서 게임 나가기
    {
        Application
            .Quit();
        Debug.Log("게임나가지기");
    }

}
