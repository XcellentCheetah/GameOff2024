using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class AudioTest : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.instance.PlayOneShot(FMODEvents.instance.benSound, this.transform.position);
        }

        UpdateSound();
    }


    private void UpdateSound()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            AudioManager.instance.PlayLoop(FMODEvents.instance.playerFootsteps);
        }
        else
        {
            AudioManager.instance.StopLoop(FMODEvents.instance.playerFootsteps);
        }
    }
}
