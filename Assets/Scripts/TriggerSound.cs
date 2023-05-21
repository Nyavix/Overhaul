using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{
    public AudioClip mainAudio;
    public AudioClip bossAudio;

    private void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(mainAudio, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().PlayOneShot(bossAudio, 0.65f);
        }
    }
}
