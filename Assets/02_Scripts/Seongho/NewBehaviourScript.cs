using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("WEQr");
            SoundManager.Instance.EffectSource.PlayOneShot(SoundManager.Instance.PlaySound(0));
        }
    }
}
