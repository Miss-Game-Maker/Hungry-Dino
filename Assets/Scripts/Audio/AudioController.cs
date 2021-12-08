using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private static AudioController instance;
    private GameObject audioGameObject;
    private static AudioSource[] audioSources;
    public static float loopStartTime;
    public static float loopEndTime;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this);
            return;
        }
    }

    void Start()
    {
        audioSources = GameObject.FindGameObjectWithTag("AudioSources").GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        AudioPlayLoop((int)AudioType.BGM, 0f, 37.868f);
    }

    public static void AudioPlayOnce(int i)
    {
        audioSources[i].Play();
    }

    public static void AudioPlayLoop(int i, float loopStartTime = 0f, float loopEndTime = 0f)
    {
        if (loopEndTime == 0)
        {
            loopEndTime = audioSources[i].clip.length;
        }
        if (audioSources[i] != null &&
        audioSources[i].isPlaying &&
        audioSources[i].time > loopEndTime)
        {
            audioSources[i].time = loopStartTime;
        }
        else if (!audioSources[i].isPlaying)
        {
            audioSources[i].Play();
        }
    }

    public static void AudioStop(int i)
    {
        audioSources[i].Stop();
    }

    public static void AudioMute(int i)
    {
        audioSources[i].volume = 0f;
    }

    public static void AudioUnmute(int i, float vol = 1f)
    {
        audioSources[i].volume = vol;
    }
    public static void AudioPause(int i, float vol = 1f)
    {
        audioSources[i].Pause();
    }
    public static void AudioResume(int i, float vol = 1f)
    {
        audioSources[i].UnPause();
    }
}
