using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource wolf;
    public AudioClip wolfClip;

    private void Start()
    {
        instance = this;
    }
    public void PlayWolf()
    {
        wolf.PlayOneShot(wolfClip);
    }
}
