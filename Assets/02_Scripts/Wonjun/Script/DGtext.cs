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
        exText.DOText("닭이 양계장에 갇혀 있다가 \r\n친구들이 끔 살을 당하는 것을 목격하고 \r\n이곳을 탈출하기로 맘을 먹어 \r\n양계장 지하에서 발견한 로프를 사용하여 \r\n이곳을 빠져나가고자 하는 이야기다.", 3f)
            .SetEase(Ease.Linear);
    }
}
