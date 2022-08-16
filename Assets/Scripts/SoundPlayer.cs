using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [System.Serializable]
    public struct BgmType
    {
        public string name;
        public AudioClip audio;
    }

    public BgmType[] BGMList;

    private AudioSource BGM;
    private AudioSource SFX;
    private string NowBGMname = "";

    public AudioSource walkSound;

    public AudioClip crossZombie;

    void Start()
    {
        BGM = gameObject.AddComponent<AudioSource>();
        SFX = gameObject.AddComponent<AudioSource>();
        walkSound = GetComponent<AudioSource>();

        BGM.loop = true;
        BGM.volume = .5f;
        if (BGMList.Length > 0) PlayBGM(BGMList[0].name);
        Events();
    }

    private void Events()
    {
        //EventManager.instance.AddEvent("PlayBGM", p =>
        //{
        //    PlayBGM((string)p);
        //});

        EventManager.instance.AddEvent("Sound :: CrossTheZombie", p =>
        {
            SFX.PlayOneShot(crossZombie);
        });

        EventManager.instance.AddEvent("Sound :: isWalk", p =>
        {
            if ((bool)p)
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
        });


    }

    public void PlayBGM(string name)
    {
        if (NowBGMname.Equals(name)) return;

        for (int i = 0; i < BGMList.Length; ++i)
            if (BGMList[i].name.Equals(name))
            {
                BGM.clip = BGMList[i].audio;
                BGM.Play();
                NowBGMname = name;
            }
    }
}
