using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlaying : MonoBehaviour
{
    public AudioSource GhostApp;

    public void PlayGhostApp()
    {
        GhostApp.Play();
    }

    void OnTriggerEnter()
    {
        GhostApp.Play();
    }
}
