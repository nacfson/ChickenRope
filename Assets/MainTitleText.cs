using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainTitleText : MonoBehaviour
{
    public static MainTitleText Instance;
    TextMeshProUGUI _Text;
    public Animator anim;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
            else
            Destroy(gameObject);
        _Text = GetComponent<TextMeshProUGUI>();
        anim = GetComponent<Animator>();
    }
    public void OnText(string text)
    {
        _Text.text = text;
        anim.SetTrigger("IsText");
    }
}
