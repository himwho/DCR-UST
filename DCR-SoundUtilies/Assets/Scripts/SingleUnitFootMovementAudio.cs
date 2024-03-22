using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SingleUnitFootMovementAudio : MonoBehaviour
{
	[Header("Audio Settings:")]
	public AudioMixerGroup FootUnitMixerGroup;
	public bool spatialize = true;

	[Header("Project Settings:")]
	public float minVelocity = 0.0f; 
	public float maxVelocity = 10.0f; 

	void Start()
    {
        
    }

    void Update()
    {
        
    }

    float normalize(float input, float min, float max)
	{
		return (input - min) / (max - min);
	}

    public void StepTrigger(float velocity)
	{
		float normVelocity = normalize(velocity, minVelocity, maxVelocity);


        //TODO: fill the rest of this
        //random container - foot
        //random container - gun jingle
        //random container - gear jingle
        //random container - floor material
        //random container - breath

	}

    public void stopTrigger(float velocity)
	{
        //TODO: fill the rest of this
	}
}

//TODO: rewrite this as ECS compliant, breaking into modular groups:
// foot & material
// gun
// gear - subgroups of gear depending on ownership of different gear?
// breathing