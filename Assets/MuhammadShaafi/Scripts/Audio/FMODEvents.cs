using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Ben SFX")]
    [field: SerializeField] public EventReference benSound { get; private set; }

    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference playerFootstepsRef { get; private set; }

    public EventInstance playerFootsteps;

    public static FMODEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one FMOD Events instance in the scene.");
        }

        instance = this;
    }

    public void Start()
    {
        playerFootsteps = AudioManager.instance.CreateEventInstance(playerFootstepsRef);
    }
}
