using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioVolumeManager : MonoBehaviour
{
    public Slider slider;

     void Start()
    {
        if(!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume",1);
            Load();
        } else
        {
            Load();
        }
    }
     private void Load()
    {
        slider.value = PlayerPrefs.GetFloat("musicVolume");
    }
}