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


    public bool BG_IsCanMute = true;
    public bool EF_IsCanMute = true;

    public float[] stackValue = new float[2];
    public Slider[] slider = new Slider[2];
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

    private void Start()
    {
        slider[0].value = 0;
        slider[1].value = 0;
        musicSource.volume = 0;
        EffectSource.volume = 0;
    }
    public void SetMusicVolume(int index)
    {
        BackGroundBtn.image.sprite = BackGoundSprite;
        BG_IsCanMute = true;

        stackValue[index] = slider[index].value;
        musicSource.volume = stackValue[index];

    }
    public void SetSoundEffect(int index)
    {
        EffectBtn.image.sprite = EffectSprite;
        EF_IsCanMute = true;

        EffectSource.volume = slider[index].value;
        stackValue[index] = slider[index].value;

    }
    public void MuteBackGroundSound()
    {
        SetCanMute_BackGound(BG_IsCanMute, 0);
    }

    public void MuteEffectSound()
    {
        SetCanMute_Effect(EF_IsCanMute, 1);
    }
    public void SetCanMute_BackGound(bool Mute, int index)
    {
        if (Mute)
        {
            BackGroundBtn.image.sprite = MuteBackGorundSprite;
            musicSource.volume = 0;
            BG_IsCanMute = false;
        }
        else if (!Mute)
        {
            slider[index].value = stackValue[index];
            musicSource.volume = stackValue[index];
            BackGroundBtn.image.sprite = BackGoundSprite;
            BG_IsCanMute = true;
        }
    }
    public void SetCanMute_Effect(bool Mute, int index)
    {
        if (Mute)
        {
            EffectBtn.image.sprite = MuteEffectSprite;
            EffectSource.volume = 0;
            EF_IsCanMute = false;
        }
        else if (!Mute)
        {
            slider[index].value = stackValue[index];
            EffectSource.volume = stackValue[index];
            EffectBtn.image.sprite = EffectSprite;
            EF_IsCanMute = true;
        }
    }
    #endregion
    public AudioClip PlaySound(int index)
    {
        EffectSource.clip = cd[index];
        return cd[index];
    }
}
