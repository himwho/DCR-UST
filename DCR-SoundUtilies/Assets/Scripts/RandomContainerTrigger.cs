using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class RandomContainerTrigger : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] container;
    private AudioClip clip;
    [Header("Audio Settings:")]
    public AudioMixerGroup containerMixerGroup;
    public bool spatialize;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    /* 
     * Trigger function for scalable random container
     */

    public void TriggerContainer()
    {
        int index = Random.Range(0, container.Length);
        clip = container[index];
        //Check that GameObject has an empty AudioSource Component
        audioSource.outputAudioMixerGroup = containerMixerGroup;
        audioSource.spatialize = spatialize;
        audioSource.clip = clip;
        audioSource.Play();
    }
}
