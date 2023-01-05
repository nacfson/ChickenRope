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

    [SerializeField] Button _previousButton;
    [SerializeField] Button _nextButton;
    [SerializeField] Button _startButton;
    [SerializeField] Image _stageImage;
    [SerializeField] TextMeshProUGUI _stageName;
    [SerializeField] SceneMoveManager _sceneManager;

    public List<LevelDataProperty> mapData;

    public static int currentPage;
    public int definitionInt = 4;


    private void Update()
    {
        UpdateUI();

    }

    public void EnableStartButton()
    {
        GameManager.Instance.SaveClearScene();
        if(currentPage <= GameManager.Instance.ReturnStageClearIndex())
        {
            Color color = _startButton.GetComponent<Image>().color;
            color.a = 1f;
            _startButton.GetComponent<Image>().color = color;
            _startButton.enabled = true;
        }
        else
        {
            Color color = _startButton.GetComponent<Image>().color;
            color.a = 0.3f;
            _startButton.GetComponent<Image>().color = color;
            _startButton.enabled = false;
        }
    }




    public void OnClickStart()
    {
        if(currentPage == 0)
        {
            _sceneManager.MoveStage01();
        }
        if (currentPage == 1)
        {
            _sceneManager.MoveStage02();
        }
        if (currentPage == 2)
        {
            _sceneManager.MoveStage03();
        }
        if (currentPage == 3)
        {
            _sceneManager.MoveStage04();
        }
    }

    public void UpdateUI()
    {
        _previousButton.interactable = currentPage > 0;
        _nextButton.interactable = currentPage < mapData.Count - 1;

        UpdateContents();
    }

    public void UpdateContents()
    {
        _stageImage.sprite = mapData[currentPage].levelSprite;
        _stageName.text = mapData[currentPage].levelName;
    }

    public void OnClickPrevious()
    {
        currentPage--;
        EnableStartButton();

        UpdateUI();
    }

    public void OnClickNext()
    {
        currentPage++;
        EnableStartButton();

        UpdateUI();
    }
}
