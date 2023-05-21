using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    [Range(0, 1)]
    public float stepVolume = 1;
    public AudioClip step;
    [Range(0, 1)]
    public float outStepVolume = 1;
    public AudioClip outStep;
    [Range(0,1)]
    public float jumpVolume = 1;
    public AudioClip jump;
    [Range(0, 1)]
    public float landVolume = 1;
    public AudioClip land;

    bool jumped;

    private void Update()
    {
        if (GetComponent<Animator>().GetBool("Grounded"))
        {
            jumped = false;
        }
        else
        {
            if (!jumped && GetComponent<Animator>().GetFloat("ySpeed") > 0 )
            {
                Jump();
                jumped = true;
            }
        }
    }

    public void Step()
    {
        GetComponent<AudioSource>().PlayOneShot(step, stepVolume);
    }

    public void Jump()
    {
        GetComponent<AudioSource>().PlayOneShot(jump, jumpVolume);
    }

    public void Land()
    {
        GetComponent<AudioSource>().PlayOneShot(land, landVolume);
    }
}
