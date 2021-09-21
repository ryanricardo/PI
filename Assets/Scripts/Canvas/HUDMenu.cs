using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDMenu : MonoBehaviour
{

    enum ObjectsMenu
    {
        SliderVolumeMusic,
    }
    
    [SerializeField]private ObjectsMenu objectsMenu;
    [SerializeField]private Slider      SliderObjectVolumeMusic;
    [SerializeField]private AudioSource SourceMusic;
   
    void Start()
    {
        SliderObjectVolumeMusic.value = PlayerPrefs.GetFloat("VolumeMusic");
    }

    
    void Update()
    {
        switch(objectsMenu)
        {
            case ObjectsMenu.SliderVolumeMusic:
            PlayerPrefs.SetFloat("VolumeMusic", SliderObjectVolumeMusic.value);
            SourceMusic.volume = PlayerPrefs.GetFloat("VolumeMusic");
            break;
        }
    }
}
