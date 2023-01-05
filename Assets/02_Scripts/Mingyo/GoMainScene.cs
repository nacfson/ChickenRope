using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GoMainScene : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _text;
    private void Awake() {
        //SceneManager.LoadScene("EndScene");
        _text.text = $"Time : {InGameUIManager.CurrentTime}";
    }
    public void GOMainBtn()
    {
        SoundManager.Instance.EffectSource.PlayOneShot(SoundManager.Instance.PlaySound(0));
        SceneManager.LoadScene("StartScene");
    }
}
