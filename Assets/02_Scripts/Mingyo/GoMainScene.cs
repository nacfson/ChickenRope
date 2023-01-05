using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoMainScene : MonoBehaviour
{
    public void GOMainBtn()
    {
        SoundManager.Instance.EffectSource.PlayOneShot(SoundManager.Instance.PlaySound(0));
        SceneManager.LoadScene("StartScene");
    }
}
