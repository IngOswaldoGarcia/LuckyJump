using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour {

    public static SoundSystem instance;

    public AudioClip soundJump, soundPause, soundHittingFloor,soundHittingFinalPlatform,clicButtonSound, gamePlayMusic, soundHittingSecundaryPlatform, soundHittingSecundaryPlatformHigherScore;

    public AudioSource audioSourceClip, audioSourceMusic, audioSourceClipExtra;


    void Awake()
    {
        if(SoundSystem.instance == null)
        {
            SoundSystem.instance = this;
        }else if(SoundSystem.instance != this)
        {
            Destroy(gameObject);
        }
        
    }
    public void PlaySoundHittingFinalPlatform()
    {
        PlayAudioClip(soundHittingFinalPlatform);
    }

    public void PlaySoundHittingSecundaryPlatform()
    {
        PlayAudioClip(soundHittingSecundaryPlatform);
    }

    public void PlaySoundHittingSecundaryPlatformHigherScore()
    {
        PlayAudioClipExtra(soundHittingSecundaryPlatformHigherScore);
    }
    public void PlaySoundClicButton()
    {
        PlayAudioClip(clicButtonSound);
    }

    public void PlaySoundHittingFloor()
    {
        PlayAudioClip(soundHittingFloor);
    }
    public void PlaySoundJump()
    {
        PlayAudioClip(soundJump);
    }

    public void PlaySoundPauseButton()
    {
        PlayAudioClip(soundPause);
    }

    public void PlayGamePlayMusic()
    {
        PlayAudioMusic(gamePlayMusic);
    }
    public void StopGamePlayMusic()
    {
        StopAudioMusic(gamePlayMusic);
    }

    private void PlayAudioClip(AudioClip audioClip) {
        audioSourceClip.clip = audioClip;
        audioSourceClip.Play();
    }
    private void PlayAudioClipExtra(AudioClip audioClip)
    {
        audioSourceClipExtra.clip = audioClip;
        audioSourceClipExtra.Play();
    }

    private void PlayAudioMusic(AudioClip audioClip)
    {
        audioSourceMusic.clip = audioClip;
        audioSourceMusic.Play();
        audioSourceMusic.pitch = 1f;
    }
    private void StopAudioMusic(AudioClip audioClip)
    {
        audioSourceMusic.clip = audioClip;
        audioSourceMusic.Stop();
    }

    public void PauseGameMusic()
    {
        audioSourceMusic.Pause();
    }

    public void UnPauseGameMusic()
    {
        audioSourceMusic.UnPause();
    }

    private void OnDestroy()
    {
        if(SoundSystem.instance == this)
        {
            SoundSystem.instance = null;
        }
    }
}
