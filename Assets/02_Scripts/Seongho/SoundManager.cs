using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource EffectSource;
    public AudioClip[] cd;

    // »ç¿ë¹ý : sound.EffectSource.PlayOneShot(sound.PlaySound(0));

    #region SoundPanel
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }
    public void SetSoundEffect(float volume)
    {
        EffectSource.volume = volume;
    }
    #endregion
    public AudioClip PlaySound(int index)
    {
        EffectSource.clip = cd[index];
        return cd[index];
    }
}
