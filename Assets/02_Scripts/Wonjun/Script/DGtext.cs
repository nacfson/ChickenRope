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
        exText.DOText("���� ����忡 ���� �ִٰ� \r\nģ������ �� ���� ���ϴ� ���� ����ϰ� \r\n�̰��� Ż���ϱ�� ���� �Ծ� \r\n����� ���Ͽ��� �߰��� ������ ����Ͽ� \r\n�̰��� ������������ �ϴ� �̾߱��.", 3f)
            .SetEase(Ease.Linear);
    }
}
