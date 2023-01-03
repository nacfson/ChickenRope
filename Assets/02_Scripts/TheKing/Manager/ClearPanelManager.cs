using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearPanelManager : MonoBehaviour
{
    [SerializeField] private Button _menuButton;
    [SerializeField] private Button _nextButton;

    public void ButtonClicked(Button button)
    {
        _nextButton.onClick.AddListener(() => GameManager.Instance.LoadNextScene());
        _menuButton.onClick.AddListener(() => GameManager.Instance.GoToMainMenu());
        Debug.Log("OnClickAddListener");
        ExecuteFunction(button);
    }

    void ExecuteFunction(Button button)
    {
        button.onClick?.Invoke();
        Debug.Log("ExecuteFunction");

    }
}
