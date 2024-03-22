using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class StSP_Player : MonoBehaviour
{
    [Header("Player Assignment:")]
	public AudioMixerGroup audioMixerGroup;
    [Space]
    public AudioClip monoSpatialClip;
    public AudioClip stereoStaticClip;

	[Header("Player Settings:")]
    public bool showDebug = false;
    public bool useDistanceAttenuation = true;
    public bool isLooping = false;

    [Header("Debug Inspector:")]
    public float _currentTime;

    private AudioSource mono_source;
    private AudioSource stereo_source;

    // Start is called before the first frame update
    void Start()
    {
        // assign mixer groups
        mono_source.outputAudioMixerGroup = audioMixerGroup;
        stereo_source.outputAudioMixerGroup = audioMixerGroup;
        // assign audio clips to sources
        mono_source.clip = monoSpatialClip;
        stereo_source.clip = stereoStaticClip;

        // mono settings
        mono_source.spatialize = true;
        mono_source.spatialBlend = 1.0f;
        mono_source.loop = isLooping;
        // stereo settings
        stereo_source.spatialize = false;
        stereo_source.spatialBlend = 0.0f;
        stereo_source.loop = isLooping;
    }

    // Update is called once per frame
    void Update()
    {
        _currentTime = mono_source.time;
    }

    public void Play()
    {        
        if (monoSpatialClip != null && stereoStaticClip != null)
        {
            mono_source.Play();
            stereo_source.Play();
            if (showDebug) Debug.Log("[AUDIO] Played");
        }
    }

    public void Stop()
    {        
        if (mono_source.isPlaying)
        {
            mono_source.Stop();
            stereo_source.Stop();
            if (showDebug) Debug.Log("[AUDIO] Stopped");
        }
    }
 
    public void Pause()
    {
        if (mono_source.isPlaying) 
        {
            _currentTime = mono_source.time;
            mono_source.Pause();
            stereo_source.Pause();
            if (showDebug) Debug.Log("[AUDIO] Paused at "+_currentTime);
        }
    }
 
    public void UnPause()
    {
        if (monoSpatialClip != null && !mono_source.isPlaying) 
        {
            mono_source.UnPause();
            stereo_source.UnPause();
            if (showDebug) Debug.Log("[AUDIO] UnPaused at "+_currentTime);
        }
    }

    public void Seek(float time_in_seconds)
    {
        if (monoSpatialClip != null && !mono_source.isPlaying) 
        {
            mono_source.time = time_in_seconds;
            stereo_source.time = time_in_seconds;
            mono_source.Play();
            stereo_source.Play();
            if (showDebug) Debug.Log("[AUDIO] Played at "+_currentTime);
        }
    }
}
