using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource EffectSource;
    public AudioClip[] cd;

    Stack<float>[] stack;

    public bool BG_IsCanMute = true;
    public bool EF_IsCanMute = true;

    [Header("¹è°æ À½¾Ç")]
    [SerializeField] private Button BackGroundBtn;
    [SerializeField] private Sprite MuteBackGorundSprite;
    [SerializeField] private Sprite BackGoundSprite;

    [Header("ÀÌÆåÆ® À½¾Ç")]
    [SerializeField] private Button EffectBtn;
    [SerializeField] private Sprite MuteEffectSprite;
    [SerializeField] private Sprite EffectSprite;
    // »ç¿ë¹ý : sound.EffectSource.PlayOneShot(sound.PlaySound(0));

    #region SoundPanel
    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        stack[0].Push(volume);
    }
    public void SetSoundEffect(float volume)
    {
        EffectSource.volume = volume;
        stack[1].Push(volume);
    }
    public void MuteBackGroundSound()
    {
        SetCanMute(ref BG_IsCanMute, 0, musicSource, MuteBackGorundSprite, BackGoundSprite, BackGroundBtn);
    }

    public void MuteEffectSound()
    {
        SetCanMute(ref EF_IsCanMute, 1, EffectSource, MuteEffectSprite, EffectSprite, EffectBtn);
    }
    public void SetCanMute(ref bool Mute, int index, AudioSource audioSource, Sprite MuteSprite, Sprite sprite, Button button)
    {
        if (Mute)
        {
            button.image.sprite = MuteSprite;
            //audioSource.Pause();

            audioSource.volume = 0;
            Mute = false;
        }
        else if (!Mute)
        {
            button.image.sprite = sprite;
            //audioSource.UnPause();

            audioSource.volume = stack[index].Pop();
            Mute = true;
        }
    }
    #endregion
    public AudioClip PlaySound(int index)
    {
        EffectSource.clip = cd[index];
        return cd[index];
    }
}
