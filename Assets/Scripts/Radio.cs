using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : Interactable
{
    private AudioSource tapeOne;
    
    protected override void Interact()
    {
        tapeOne = GetComponent<AudioSource>();
        if(tapeOne.isPlaying){
            tapeOne.Pause();
        } else {
            tapeOne.Play();
        }
        Debug.Log($"Playing {tapeOne}");
    }
}
