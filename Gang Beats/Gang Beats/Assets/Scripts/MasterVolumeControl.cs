using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterVolumeControl : MonoBehaviour
{
    //[Range(0.0f, 1.0f)]
    //[SerializeField]
    //private AudioSource audioSrc;
    private float masterVolume = 1.0f;
    public Slider volumeSlider;

    private void Start()
    {
        volumeSlider.value = AudioListener.volume;
    }
    void Update()
    {
        //Debug.Log(masterVolume);
        AudioListener.volume = masterVolume;
    }

    public void SetVolume(float vol)
    {
        masterVolume = vol;
        //Debug.Log(vol);
    }

}
