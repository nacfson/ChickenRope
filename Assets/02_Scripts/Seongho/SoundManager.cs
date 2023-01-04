using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public GameObject settingPannel;
    public static SoundManager Instance;
    public AudioSource musicSource;
    public AudioSource EffectSource;

    public AudioClip[] cd; // 사용법 :SoundManager.Instance.EffectSource.PlayOneShot(SoundManager.Instance.PlaySound(0));



    #region 사운드 이미지 설정
    public bool BG_IsCanMute = true;
    public bool EF_IsCanMute = true;

    public float[] stackValue = new float[2];
    public Slider[] slider = new Slider[2];

    [Header("배경 음악")]
    [SerializeField] private Button BackGroundBtn;

    [SerializeField] private Sprite MuteBackGorundSprite;
    [SerializeField] private Sprite BackGoundSprite;

    [SerializeField] private Image BackGround_image;

    [SerializeField] private Sprite BG_image;
    [SerializeField] private Sprite BG_Muteimage;

    [Header("이펙트 음악")]
    [SerializeField] private Button EffectBtn;

    [SerializeField] private Sprite MuteEffectSprite;
    [SerializeField] private Sprite EffectSprite;

    [SerializeField] private Image EffectGround_image;

    [SerializeField] private Sprite EF_image;
    [SerializeField] private Sprite EF_Muteimage;
    #endregion
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            settingPannel.SetActive(!settingPannel.activeInHierarchy);
        if (settingPannel.activeInHierarchy == true) Time.timeScale = 0;
        else if (settingPannel.activeInHierarchy == false) Time.timeScale = 1;
    }
    #region 사운드 설정
    private void Awake()
    {
        Instance = this;
    }

    public void SetActiveFalseSettingPanel()
    {
        settingPannel.SetActive(false);
    }
    private void Start()
    {
        slider[0].value = 0;
        slider[1].value = 0;
        musicSource.volume = 0;
        EffectSource.volume = 0;
    }
    public void SetMusicVolume()
    {
        BackGroundBtn.image.sprite = BackGoundSprite;
        BG_IsCanMute = true;

        stackValue[0] = slider[0].value;
        musicSource.volume = stackValue[0];

    }
    public void SetSoundEffect()
    {
        EffectBtn.image.sprite = EffectSprite;
        EF_IsCanMute = true;

        EffectSource.volume = slider[1].value;
        stackValue[1] = slider[1].value;

    }
    public void MuteBackGroundSound()
    {
        SoundManager.Instance.EffectSource.PlayOneShot(SoundManager.Instance.PlaySound(0));
        SetCanMute_BackGound(BG_IsCanMute, 0);
    }

    public void MuteEffectSound()
    {
        SoundManager.Instance.EffectSource.PlayOneShot(SoundManager.Instance.PlaySound(0));
        SetCanMute_Effect(EF_IsCanMute, 1);
    }
    public void SetCanMute_BackGound(bool Mute, int index)
    {
        if (Mute)
        {
            BackGroundBtn.image.sprite = MuteBackGorundSprite;
            BackGround_image.sprite = BG_Muteimage;
            musicSource.volume = 0;
            BG_IsCanMute = false;
        }
        else if (!Mute)
        {
            slider[index].value = stackValue[index];
            musicSource.volume = stackValue[index];

            BackGroundBtn.image.sprite = BackGoundSprite;
            BackGround_image.sprite = BG_image;
            BG_IsCanMute = true;
        }
    }
    public void SetCanMute_Effect(bool Mute, int index)
    {
        if (Mute)
        {
            EffectBtn.image.sprite = MuteEffectSprite;
            EffectGround_image.sprite = EF_Muteimage;
            EffectSource.volume = 0;
            EF_IsCanMute = false;
        }
        else if (!Mute)
        {
            slider[index].value = stackValue[index];
            EffectSource.volume = stackValue[index];

            EffectBtn.image.sprite = EffectSprite;
            EffectGround_image.sprite = EF_image;
            EF_IsCanMute = true;
        }
    }
    #endregion

    public void Cancel()
    {
        SoundManager.Instance.EffectSource.PlayOneShot(SoundManager.Instance.PlaySound(0));

        settingPannel.SetActive(false);
    }

    public void Replay()
    {
        SoundManager.Instance.EffectSource.PlayOneShot(SoundManager.Instance.PlaySound(0));
        SetActiveFalseSettingPanel();
        if (SceneManager.GetActiveScene().buildIndex > 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            GameManager.Instance.UISceneLoad();
        }
        else
            Debug.LogError("게임 씬이 아닙니다.");
    }
    public void Exit()
    {
        SoundManager.Instance.EffectSource.PlayOneShot(SoundManager.Instance.PlaySound(0));
        SetActiveFalseSettingPanel();

        GameManager.Instance.GoToMainMenu();
    }
    public AudioClip PlaySound(int index)
    {
        EffectSource.clip = cd[index];
        return cd[index];
    }
}
