using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Soundcontroller : MonoBehaviour
{
    public static Soundcontroller instance;

    private void Awake()
    {
        instance = this; 
    }
    public void playThisSound(string clName, float volumeMultiplier)
    {
        AudioSource audioSource = this.gameObject.AddComponent<AudioSource>();
        audioSource.volume *= volumeMultiplier;
        audioSource.PlayOneShot((AudioClip)Resources.Load("Sounds/" + clName, typeof(AudioClip)));
    }
}
