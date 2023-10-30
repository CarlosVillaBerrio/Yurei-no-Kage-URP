using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public void FullScreenOption(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    public void ChangeVolumen(float volumen)
    {
        audioMixer.SetFloat("Volumen", volumen);
    }

    public void ChangeQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
}
