using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{   
    public static AudioManager audioManager;


    [SerializeField] private Image muteButtonImage;
    [SerializeField] private Sprite audioOnSprite;
    [SerializeField] private Sprite audioOffSprite;


    public const string prefAudioMute = "prefAudioMute";
    [SerializeField] private Sound [] sounds;

    private void Awake() 
    {
        if (PlayerPrefs.HasKey(prefAudioMute))
        {
            AudioListener.volume = PlayerPrefs.GetFloat(prefAudioMute);
        }

       UpdateMuteButtonImageSprite();

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            //GALIMA REGULIUOTI 
            //s.source.volume = 1;

            s.source.clip = s.clip;
            s.source.loop = s.isLoop;
            s.source.playOnAwake = s.playOnAwake;
            s.source.volume = s.volume;

            if (s.source.playOnAwake)
            {
                s.source.Play();
            }

        }
    }

    private void UpdateMuteButtonImageSprite()
    {
        if (AudioListener.volume == 0)
        {
            muteButtonImage.sprite = audioOffSprite;
        }
        else
        {
            muteButtonImage.sprite = audioOnSprite;
        }
    }

    public void PlayClipByName(string cliPName)
    {
        Sound soundToPlay = Array.Find(sounds, s => s.clipName == cliPName);

        if (soundToPlay != null)
        {
           soundToPlay.source.Play(); 
        }       

        //GALIMA TAIP (Cia tas pats)
        // foreach (Sound s in sounds)
        // {
        //     if (s.clipName == cliPName)
        //     {
        //         soundToPlay = s;
        //     }
        // }
    }

    public void StopClipByName(string cliPName)
    {
        Sound soundToPlay = Array.Find(sounds, s => s.clipName == cliPName);
        if (soundToPlay != null)
        {
           soundToPlay.source.Stop(); 
        }        

    }

    public void ToggleMute()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = 1;
        }

        PlayerPrefs.SetFloat(prefAudioMute, AudioListener.volume);

        UpdateMuteButtonImageSprite();
    }
}
