using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;

    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayeSound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void PlayOnlyThisSound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
