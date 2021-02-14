using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Final Harvest
Franz Cadiente 301098663
Sydney Huang 301068497
Kautuk Udavant 301072587

    Date last modified: 02/14/21

 */
public class Footsteps : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] clips;
    private AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Jump()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);

    }

    private AudioClip GetRandomClip()
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }
}
