using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource Audio;

    public AudioClip Announcement, Bubbling, Clink, Correct, Door, Paper, Scribble, Splash, Wrong;


    public static AudioManager audioInstance;

    private void Awake()
    {
        //checking to see if the background music gameObject is active and if it isn't make a new one.
        if (audioInstance != null && audioInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        audioInstance = this;
        DontDestroyOnLoad(this);
    }
}
