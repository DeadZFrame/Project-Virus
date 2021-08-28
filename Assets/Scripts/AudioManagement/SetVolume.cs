using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class SetVolume : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetLevel(float sliderValue)
    {
        audioMixer.SetFloat("MusicVal", Mathf.Log10(sliderValue) * 20);
    }

}
