using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using DG.Tweening;
using UnityEngine.UI;

public class DGtext : MonoBehaviour
{

    public Text exText = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void extext()
    {
        exText.DOKill();
        exText.text = "";
        exText.DOText("양계장에 갇혀있던 닭은 \r\n어느날 자신의 친구들이 끔살을 당하는 것을 목격하고 \r\n이곳을 탈출하기로 맘을 먹는다. \r\n지하에서 발견한 로프를 사용하여 \r\n양계장을 빠져나가고자 하는 이야기다.", 3f)
            .SetEase(Ease.Linear);
    }
}
