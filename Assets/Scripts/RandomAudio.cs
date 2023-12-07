using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAudio : MonoBehaviour
{
    public AudioClip[] audioClips;
    public float minDelay = 5.0f;
    public float maxDelay = 10.0f;

    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(PlayRandomAudio());
    }

    IEnumerator PlayRandomAudio()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minDelay, maxDelay));

            if (audioClips.Length > 0)
            {
                AudioClip randomClip = audioClips[Random.Range(0, audioClips.Length)];
                source.clip = randomClip;
                source.Play();

                PlayRandomAudio();
                
            }
        }
    }
}
