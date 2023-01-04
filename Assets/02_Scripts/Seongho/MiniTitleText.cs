using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniTitleText : MonoBehaviour
{
    public static MiniTitleText Instance;
     TextMeshProUGUI _Text;
    Animator anim;
    private void Awake()
    {
        Instance = this;
        _Text = GetComponent<TextMeshProUGUI>();
        anim = GetComponent<Animator>();
    }
    public void OnText(string text)
    {
        _Text.text = text;
        anim.SetTrigger("IsText");
    }
}
