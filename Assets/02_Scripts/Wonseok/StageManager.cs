using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageManager : MonoBehaviour
{
    [System.Serializable]
    public class MapDataProperty
    {
        public Sprite mapSprite;
        public string mapName;
    }
    [SerializeField] Button _previousButton;
    [SerializeField] Button _nextButton;
    [SerializeField] Button _startButton;
    [SerializeField] Image _stageImage;
    [SerializeField] TextMeshProUGUI _stageName;
    [SerializeField] SceneMoveManager _sceneManager;

    public List<MapDataProperty> mapData; 

    public int currentPage;

    private void Start()
    {
<<<<<<< Updated upstream
        UpdateUI();
    }

=======
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
        if(currentPage < PlayerPrefs.GetInt(GameManager.Instance.clearIndexName) - definitionInt)
        {
            _startButton.enabled = true;
        }
        else
        {
            _startButton.enabled = false;
        }
    }

>>>>>>> Stashed changes
    public void OnClickStart()
    {
        string path = SceneUtility.GetScenePathByBuildIndex(currentPage + definitionInt + 1);
        string name = System.IO.Path.GetFileNameWithoutExtension(path);    
        _sceneManager.MoveStage(name);
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
<<<<<<< Updated upstream
        stageImage.sprite = mapData[currentPage].mapSprite;
        stageName.text = mapData[currentPage].mapName;
=======
        _stageImage.sprite = mapData[currentPage].levelSprite;
        _stageName.text = mapData[currentPage].levelName;
>>>>>>> Stashed changes
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
