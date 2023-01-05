using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string clearIndexName = "CLEARINDEX";
    public UnityAction ClearAction;
    public UnityAction LoadSceneAction;
    public UnityAction SaveLoadAction;

    [SerializeField]
    private GameObject _clearObject;
    private Transform _player;
    private int _denfinitionInt = 4;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        StartCoroutine(AdministatorCor());

        ClearAction += SaveClearScene;
    }
    IEnumerator AdministatorCor()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                AdministratorFunction();
            }
            yield return null;
        }
    }

    public void Load(SaveJson s)
    {
        StartCoroutine(AA(s));
    }

    IEnumerator AA(SaveJson s)
    {
        yield return new WaitForSeconds(0.01f);
        s.Load();
    }

    private void AdministratorFunction()
    {
        _player = GameObject.Find("RealFinalPlayer").transform;
        GameObject obj = Instantiate(_clearObject);
        obj.transform.position = _player.position;
    }
    [ContextMenu("SetSceneIndex")]

    public void SetSceneIndex()
    {
        PlayerPrefs.SetInt(clearIndexName, SceneManager.GetActiveScene().buildIndex - _denfinitionInt);
    }
    public void SaveClearScene()
    {
        if (PlayerPrefs.GetInt(clearIndexName) < SceneManager.GetActiveScene().buildIndex)
        {
            PlayerPrefs.SetInt(clearIndexName, SceneManager.GetActiveScene().buildIndex - _denfinitionInt);
        }
    }

    public int ReturnStageClearIndex()
    {
        return PlayerPrefs.GetInt(clearIndexName);
    }

    public int LoadClearScene()
    {
        return PlayerPrefs.GetInt(clearIndexName);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
    [ContextMenu("LoadNextScene")]
    public void LoadNextScene()
    {
        SaveClearScene();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("InGameUI", LoadSceneMode.Additive);
        UISceneLoad();
        //AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        //while(!operation.isDone)
        //{
        //    return;
        //}
        LoadSceneAction?.Invoke();
        Debug.Log("LoadAction");
    }

    public void UISceneLoad()
    {
        SceneManager.LoadScene("InGameUI", LoadSceneMode.Additive);
        SceneManager.LoadScene("ClearPanel", LoadSceneMode.Additive);
    }
}
