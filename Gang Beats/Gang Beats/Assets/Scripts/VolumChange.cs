﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumChange : MonoBehaviour
{

    // Reference to Audio Source component
    private AudioSource audioSrc;

    // Music volume variable that will be modified
    // by dragging slider knob
    private float musicVolume = 1f;
    //private float masterVolume = 1.0f;

    // Use this for initialization
    void Start()
    {

        // Assign Audio Source component to control it
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        // Setting volume option of Audio Source to be equal to musicVolume
        audioSrc.volume = musicVolume;
        //AudioListener.volume = musicVolume;
    }


    public void SetVolume(float vol)
    {
        musicVolume = vol;
        //masterVolume = vol;

    }
}