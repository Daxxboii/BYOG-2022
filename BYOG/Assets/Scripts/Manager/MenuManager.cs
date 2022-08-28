using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Video;
using DG.Tweening;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{
    public delegate void ChangedValues();
    public static ChangedValues ChangedSensitivity;

    public AudioMixer mixer;

    public GameObject MenuPanel;
    public GameObject SettingsPanel;

    public GameObject FirstSettingsSelected;
    public GameObject MainMenuFirstSelected;

    public static MenuManager instance;

    public VideoPlayer IntroPlayer;
    public RawImage IntroPlayerpanel;

    public float SensitivityValue, AudioValue;

    public Slider Sensitivity, Audio;

    public void Awake()
    {
        instance = this;
        IntroPlayer.Prepare();

       

    }

    public void SetUp()
    {
        SetUpSliders();
        SetSensitivity();
        SetAudio();
    }

    void SetUpSliders()
    {
        Sensitivity.onValueChanged.AddListener(ctx=>SetSensitivity());
        Audio.onValueChanged.AddListener(ctx => SetAudio());

    }
    public void Quit()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        MenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);

        EventSystem.current.SetSelectedGameObject(MainMenuFirstSelected);
    }

    public void Settings()
    {
        MenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);

        EventSystem.current.SetSelectedGameObject(FirstSettingsSelected);
    }

    private void Update()
    {
        
        if (IntroPlayer!=null && !IntroPlayer.isPlaying)
        {
            IntroPlayerpanel.DOFade(0, 1);
            MenuPanel.GetComponent<CanvasGroup>().interactable = true;
            IntroPlayer = null;
        }
    }

    public void SetSensitivity()
    {
        SensitivityValue = Sensitivity.value;
        ChangedSensitivity.Invoke();
        PlayerPrefs.SetFloat("Sensitivity", Sensitivity.value);
        PlayerPrefs.Save();
    }

    public void SetAudio()
    {
        AudioValue = Mathf.Log10(Audio.value) * 20;
        mixer.SetFloat("Master", AudioValue);
        PlayerPrefs.SetFloat("Audio", AudioValue);
        PlayerPrefs.Save();
    }

}
