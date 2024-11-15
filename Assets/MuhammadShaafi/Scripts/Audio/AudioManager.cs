using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using STOP_MODE = FMOD.Studio.STOP_MODE;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    private void Awake()
    {
        {
            if (instance != null)
            {
                Debug.LogError("Found more than one Audio Manager in the scene.");
            }

            instance = this;
        }
    }

    public void PlayOneShot(EventReference sound, Vector3 worldPos)
    {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    public void PlayLoop(EventInstance eventInstance)
    {
        PLAYBACK_STATE playbackState;
        eventInstance.getPlaybackState(out playbackState);
        if (playbackState.Equals(PLAYBACK_STATE.STOPPED))
        {
            eventInstance.start();
        }
    }

    public void StopLoop(EventInstance eventInstance, STOP_MODE stopMode = STOP_MODE.ALLOWFADEOUT)
    {
        eventInstance.stop(STOP_MODE.ALLOWFADEOUT);
    }


    public EventInstance CreateEventInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        return eventInstance;
    }

}
