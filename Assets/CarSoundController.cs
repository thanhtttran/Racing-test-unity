using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CarSoundController : MonoBehaviour
{
    public AudioClip idleClip;
    public AudioClip forwardClip;
    public AudioClip backwardClip;

    private AudioSource audioSource;
    private Rigidbody carRigidbody;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        carRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float speed = carRigidbody.velocity.magnitude;
        float dotProduct = Vector3.Dot(carRigidbody.velocity.normalized, transform.forward);

        if (speed < 0.1f)
        {
            audioSource.clip = idleClip;
        }
        else if (dotProduct > 0)
        {
            audioSource.clip = forwardClip;
        }
        else
        {
            audioSource.clip = backwardClip;
        }

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}