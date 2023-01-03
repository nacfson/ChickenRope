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

    public int currentPage;
    public int definitionInt = 2;

    private void Start()
    {
        SetBuildIndex();
    }

    private void Update()
    {
        SetStartButton();
        UpdateUI();

    }

    void SetBuildIndex()
    {
        definitionInt = 2;
        if (!(PlayerPrefs.GetInt(GameManager.Instance.clearIndexName) > 3))
        {
            PlayerPrefs.SetInt(GameManager.Instance.clearIndexName, 3);
        }
    }

    public void SetStartButton()
    {
        //Debug.Log(currentPage);
        //Debug.Log(PlayerPrefs.GetInt(GameManager.Instance.clearIndexName) - definitionInt);
        if (currentPage < PlayerPrefs.GetInt(GameManager.Instance.clearIndexName) - definitionInt)
        {
            _startButton.enabled = true;
        }
        else
        {
            _startButton.enabled = false;
        }
    }

    public void OnClickStart()
    {
        string path = SceneUtility.GetScenePathByBuildIndex(currentPage + definitionInt + 1);
        string name = System.IO.Path.GetFileNameWithoutExtension(path);

        //if(currentPage == 0)
        //{
        //    _sceneManager.MoveStage01();
        //}
        //if (currentPage == 1)
        //{
        //    _sceneManager.MoveStage02();
        //}
        //if (currentPage == 2)
        //{
        //    _sceneManager.MoveStage03();
        //}
        //if (currentPage == 3)
        //{
        //    _sceneManager.MoveStage04();
        //}
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
        UpdateUI();
    }

    public void OnClickNext()
    {
        currentPage++;
        UpdateUI();
    }
}
