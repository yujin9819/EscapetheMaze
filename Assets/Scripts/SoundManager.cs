using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource BGM;
    public AudioSource walkSound;
    public AudioSource crossZombie;

    public void SetVolume(float volume)
    {
        BGM.volume = volume;
        walkSound.volume = volume;
        crossZombie.volume = volume;
    }

    private void Start()
    {
        BGMPlayer();
        SoundPlay();
    }

    private void SoundPlay()
    {
        EventManager.instance.AddEvent("Sound :: CrossTheZombie", p =>
        {
            crossZombie.Play();
        });

        EventManager.instance.AddEvent("Sound :: isWalking", p =>
        {
            WalkSoundPlayer((bool)p);
        });
    }

    private void BGMPlayer()
    {
        BGM.Play();
        BGM.loop = true;
        BGM.volume = .5f;
    }

    private void WalkSoundPlayer(bool isWalking)
    {
        if (isWalking)
        {
            if (!walkSound.isPlaying)
            {
                walkSound.Play();
            }
        }
        else
        {
            walkSound.Stop();
        }
    }
}
