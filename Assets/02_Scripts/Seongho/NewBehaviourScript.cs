using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] SoundManager sound;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("WEQr");
            sound.EffectSource.PlayOneShot(sound.PlaySound(0));
        }
    }
}
