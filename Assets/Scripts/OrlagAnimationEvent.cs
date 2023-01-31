using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class OrlagAnimationEvent : MonoBehaviour
{
    private AudioSource source;
    [SerializeField] AudioClip clip;
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    private void PlayHitSound()
    {
        Debug.Log("Chop");
        source.clip = clip;
        source.Play();
    }
}
