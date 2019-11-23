using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterVolumeControl : MonoBehaviour
{
    //[Range(0.0f, 1.0f)]
    //[SerializeField]
    //private AudioSource audioSrc;
    private float masterVolume = 1.0f;


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
