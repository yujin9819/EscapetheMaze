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
    private string NowBGMname = "";

    static AudioSource effectSound;
    public AudioClip crossZombie;

    void Start()
    {
        BGM = gameObject.AddComponent<AudioSource>();
        effectSound = GetComponent<AudioSource>();

        BGM.loop = true;
        if (BGMList.Length > 0) PlayBGM(BGMList[0].name);
        EventManager.instance.AddEvent("PlayGoalBGM", p =>
        {
            PlayBGM((string)p);
        });

        Events();
    }

    private void Events()
    {
        EventManager.instance.AddEvent("Sound :: CrossTheZombie", p =>
        {
            effectSound.PlayOneShot(crossZombie);
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
