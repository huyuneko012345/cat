using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public AudioSource audioSource;
    [SerializeField] SoundEffect soundEffect ;
    [SerializeField] AudioClip clip1;
    [SerializeField] AudioClip clip2;
    [SerializeField] AudioClip clip3;

    public void RandomizeSfx( params AudioClip[] clips)
    {
        var randamIndex = Random.Range(0, clips.Length);
        audioSource.PlayOneShot(clips[randamIndex]);

    }

    private void PlaySfx()
    {
        soundEffect.RandomizeSfx(clip1, clip2, clip3);
    }
}
