using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    [System.Serializable]
    public class LevelDataProperty
    {
        public Sprite levelSprite;
        public string levelName;
    }
    [SerializeField] Button previousButton;
    [SerializeField] Button nextButton;
    [SerializeField] Button startButton;
    [SerializeField] Image stageImage;
    [SerializeField] TextMeshProUGUI stageName;
    [SerializeField] SceneMoveManager sceneManager;

    public List<LevelDataProperty> mapData; 

    public int currentPage;
    public int definitionInt = 2;

    private void Start()
    {
        PlayerPrefs.SetInt(GameManager.Instance.clearIndexName,1);
        UpdateUI();
    }

    private void Update()
    {
        SetStartButton();
    }

    public void SetStartButton()
    {
        if(currentPage <= PlayerPrefs.GetInt(GameManager.Instance.clearIndexName) - definitionInt)
        {
            startButton.enabled = true;
        }
        else
        {
            startButton.enabled = false;
        }
    }

    public void OnClickStart()
    {
        if(currentPage == 0)
        {
            sceneManager.MoveStage01();
        }
        if (currentPage == 1)
        {
            sceneManager.MoveStage02();
        }
        if (currentPage == 2)
        {
            sceneManager.MoveStage03();
        }
        if (currentPage == 3)
        {
            sceneManager.MoveStage04();
        }
    }

    public void UpdateUI()
    {
        previousButton.interactable = currentPage > 0;
        nextButton.interactable = currentPage < mapData.Count - 1;

        UpdateContents();
    }

    public void UpdateContents()
    {
        stageImage.sprite = mapData[currentPage].levelSprite;
        stageName.text = mapData[currentPage].levelName;
    }

    public void OnClickPrevious()
    {
        currentPage--;
        UpdateUI();
    }

    public void OnClickNext()
    {
        currentPage++;
        UpdateUI();
    }
}
