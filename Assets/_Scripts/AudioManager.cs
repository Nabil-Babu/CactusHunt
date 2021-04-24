using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource BGMusicSource;
    public AudioClip BGMusicClip;
    public AudioSource StunEffectSource;
    public AudioClip StunEffectClip;


    public void PlayBGMusic()
    {
        BGMusicSource.loop = true;
        BGMusicSource.clip = BGMusicClip;
        BGMusicSource.Play();
    }

    public void StopBGMusic()
    {
        BGMusicSource.Stop();
    }

    public void PlayStunEffect()
    {
        StunEffectSource.PlayOneShot(StunEffectClip);
    }
}
