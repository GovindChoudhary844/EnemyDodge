using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] explosionAudios;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        int randomsound = Random.Range(0, explosionAudios.Length);
        audioSource.clip = explosionAudios[randomsound];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
