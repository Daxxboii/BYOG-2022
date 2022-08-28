using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject SettingsPanel;

    public GameObject FirstSettingsSelected;
    public GameObject MainMenuFirstSelected;

    public static MenuManager instance;

    public void Awake()
    {
        instance = this;
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
    
}
