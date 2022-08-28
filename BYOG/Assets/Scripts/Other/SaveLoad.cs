using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{
    public float Defvalue;
    public string LoadSaveString;

    public int slidernumber;

   

    private void OnEnable()
    {
        if (PlayerPrefs.GetFloat(LoadSaveString) != 0f)
        {
            GetComponent<Slider>().value = PlayerPrefs.GetFloat(LoadSaveString);
        }
        else
        {
            GetComponent<Slider>().value = Defvalue;

        }

        if (slidernumber == 1)
        {
            MenuManager.instance.Sensitivity = this.GetComponent<Slider>();
        }
        else
        {
            MenuManager.instance.Audio = this.GetComponent<Slider>();
        }
        MenuManager.instance.SetUp();
    }

}
