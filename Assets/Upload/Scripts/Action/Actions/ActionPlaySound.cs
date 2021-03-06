using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using Lowscope.ScriptableObjectUpdater;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(menuName = "Actions/Play Sound")]
public class ActionPlaySound : ScriptableObject
{
    [SerializeField, HideInInspector]
    private static AudioSource fxAudioSource;

    [SerializeField, HideInInspector]
    private static AudioSource musicAudioSource;

    [SerializeField]
    private BoolEvent fxMutedEvent = null;

    [SerializeField]
    private FloatEvent fxVolumeEvent = null;

    [SerializeField]
    private AudioMixerGroup fxAudioMixer;

    [SerializeField]
    private FloatEvent musicVolumeEvent = null;

    [SerializeField]
    private BoolEvent musicMutedEvent = null;

    [SerializeField]
    private AudioMixerGroup musicAudioMixer;

    private bool musicEnabled = true;

    private bool fxEnabled = true;

    private SaveConfig save => SaveUtility.LoadOrCreateConfig();

    private float FxVolume
    {
        get
        {
            float volume;
            fxAudioMixer.audioMixer.GetFloat("FX Volume", out volume);

            return Math.Abs(volume / 80);
        }

        set
        {
            // Mixer sound gets represented in decibel. Which means -80 is fully silent, And 0 is normal.
            // The curve is based on a logarithmic scale. Which is why the Mathf.Log calculation is required.
            //0.001-1  转换到log函数值 -3-0 因精度丢失 -0.001.00005 log值 超-140 可视为置零
            fxAudioMixer.audioMixer.SetFloat("FX Volume", Mathf.Log(Mathf.Lerp(0.001f, 1, value)) * 20);
        }
    }

    private float MusicVolume
    {
        get
        {
            float volume;
            fxAudioMixer.audioMixer.GetFloat("Music Volume", out volume);

            return Mathf.Abs(volume / 80);
        }

        set
        {
            // Mixer sound gets represented in decibel. Which means -80 is fully silent, And 0 is normal.
            // The curve is based on a logarithmic scale. Which is why the Mathf.Log calculation is required.
            fxAudioMixer.audioMixer.SetFloat("Music Volume", Mathf.Log(Mathf.Lerp(0.001f, 1, value)) * 20);
        }
    }

    [UpdateScriptableObject(eventType = EEventType.Awake)]
    public void Initialize()
    {
        musicAudioSource = CreateAudioSource();
        musicAudioSource.outputAudioMixerGroup = musicAudioMixer;

        fxAudioSource = CreateAudioSource();
        fxAudioSource.outputAudioMixerGroup = fxAudioMixer;

        musicEnabled = save.musicEnabled;
        fxEnabled = save.fxEnabled;

        hideFlags = HideFlags.DontUnloadUnusedAsset;//Scriptable 会自动回收？
    }

    [UpdateScriptableObject(eventType = EEventType.Start)]
    public void OnGameStart ()
    {
        SetFXVolume(save.fxVolume);
        SetMusicVolume(save.musicVolume);

        ResendEvents();
    }

    public void ResendEvents ()
    {
        musicMutedEvent?.Invoke(!musicEnabled);
        musicVolumeEvent?.Invoke(save.musicVolume);
        fxVolumeEvent?.Invoke(save.fxVolume);
        fxMutedEvent?.Invoke(!fxEnabled);
    }

    public void SetFXVolume(float volume)
    {
        FxVolume = (fxEnabled) ? volume : 0;
        fxVolumeEvent?.Invoke(volume);

        save.fxVolume = volume;
        SaveUtility.WriteConfig(save);
    }

    public void SetMusicVolume(float volume)
    {
        MusicVolume = (musicEnabled) ? volume : 0;
        musicVolumeEvent?.Invoke(volume);

        save.musicVolume = volume;
        SaveUtility.WriteConfig(save);
    }

    public void ToggleSound()
    {
        fxEnabled = !fxEnabled;

        FxVolume = (fxEnabled) ? save.fxVolume : 0;

        fxMutedEvent?.Invoke(!fxEnabled);

        save.fxEnabled = fxEnabled;

        SaveUtility.WriteConfig(save);
    }

    public void ToggleMusic()
    {
        musicEnabled = !musicEnabled;

        MusicVolume = (musicEnabled) ? save.musicVolume : 0;

        musicMutedEvent?.Invoke(!musicEnabled);

        save.musicEnabled = musicEnabled;
        
        SaveUtility.WriteConfig(save);
    }

    public void PlayMusic(AudioClip clip)
    {
        if (musicAudioSource.clip != clip)
        {
            musicAudioSource.Stop();

            musicAudioSource.loop = true;
            musicAudioSource.clip = clip;

            if (musicAudioSource.enabled)
            {
                musicAudioSource.Play();
            }
        }
    }

    public void PlaySoundCollection(SoundCollection soundCollection)
    {
        if (soundCollection != null)
        {
            soundCollection.Play(fxAudioSource);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        if (fxAudioSource.enabled)
        {
            fxAudioSource.PlayOneShot(clip);
        }
    }

    private AudioSource CreateAudioSource()
    {
        AudioSource newSource = new GameObject().AddComponent<AudioSource>();
        GameObject.DontDestroyOnLoad(newSource);

#if UNITY_EDITOR
        newSource.name = "Audio Source";
#endif
        return newSource;
    }
}
