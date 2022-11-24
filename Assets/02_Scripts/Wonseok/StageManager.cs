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
    [SerializeField] Button previousButton;
    [SerializeField] Button nextButton;
    [SerializeField] Button startButton;
    [SerializeField] Image stageImage;
    [SerializeField] TextMeshProUGUI stageName;
    [SerializeField] SceneMoveManager sceneManager;

    public List<MapDataProperty> mapData; 

    public int currentPage;

    private void Start()
    {
        UpdateUI();
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
        stageImage.sprite = mapData[currentPage].mapSprite;
        stageName.text = mapData[currentPage].mapName;
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
