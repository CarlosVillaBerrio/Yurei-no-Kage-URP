using System;
using System.Collections;
using System.Collections.Generic;
using Invector.vCharacterController;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    
    public AudioSource musicSource;
    public MusicTrack[] musicTracks;
    
    public AudioSource effectSourcePrefab;
    public EffectTrack[] soundEffects;

    private string currentSceneName;
    
    private Dictionary<AudioClip, AudioSource> effectSourceDict = new Dictionary<AudioClip, AudioSource>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
        musicSource = GetComponent<AudioSource>();
        PlayMusic(currentSceneName);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentSceneName = scene.name;
        PlayMusic(currentSceneName);
    }

    public void PlayMusic(string sceneName)
    {
        foreach (var track in musicTracks)
        {
            if (track.sceneName == sceneName)
            {
                musicSource.clip = track.musicClip;
                musicSource.Play();
                return;
            }
        }
    }

    public void PlayEffect(string effectName, float volume = 1, bool loop = false)
    {
        foreach (var effect in soundEffects)
        {
            if (effect.effectName == effectName)
            {
                if (!effectSourceDict.ContainsKey(effect.effectClip))
                {
                    AudioSource effectGameObject = Instantiate(effectSourcePrefab, transform);
                    effectGameObject.clip = effect.effectClip;
                    effectSourceDict[effect.effectClip] = effectGameObject;
                }
                AudioSource effectSource = effectSourceDict[effect.effectClip];
                effectSource.volume = volume;
                effectSource.loop = loop;
                effectSource.Play();
            }
        }
    }
}

[Serializable]
public class MusicTrack
{
    public string sceneName;
    public AudioClip musicClip;
}

[Serializable]
public class EffectTrack
{
    public string effectName;
    public AudioClip effectClip;
}