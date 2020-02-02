using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class AudioController : MonoBehaviour
{

    public static AudioController audioController;

    // Music
    public AudioClip menu, idle, chase;
    // Cat sounds
    public AudioClip pottery, eating;
    public List<AudioClip> shatterSounds;
    // Granny sounds
    public AudioClip gasp, footsteps;
    // Game sounds
    public AudioClip gameOverSound, clickSound, winSound;

    private AudioSource chasingAudioSource, idleAudioSource, effectSource, footstepSource;
    public bool IsChasing { get; set; } = false;

    // Har inga effekter att spela nu
    public bool IsGameOver { get; set; }

    private bool Mute { get; set; }

    private Random random = new Random();

    void Awake()
    {
        if (audioController == null)
            audioController = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(this);

        footstepSource = GameObject.Find("FootstepSource").GetComponent<AudioSource>();
        chasingAudioSource = GameObject.Find("ChaseSource").GetComponent<AudioSource>();
        idleAudioSource = GameObject.Find("IdleSource").GetComponent<AudioSource>();
        effectSource = GameObject.Find("EffectSource").GetComponent<AudioSource>();
    }

    void Start()
    {
        if (Mute)
            return;
        idleAudioSource.clip = menu;
        idleAudioSource.Play();
        idleAudioSource.ignoreListenerPause = true;
    }

    public void GameOver()
    {

        IsGameOver = true;
        if (gameOverSound == null)
            return;
        effectSource.clip = gameOverSound;
        effectSource.Play();
    }

    string GetName(string name)
    {
        if (name.StartsWith("Destroyable"))
            name = name.Substring(11, name.Length - 11);

        name = name.Split('0')[0];

        return name;
    }

    public void StopWalking()
    {
        footstepSource.Stop();
    }

    public void PlayEffect(string effect)
    {
        var effectName = GetName(effect);
        if (IsGameOver || Mute)
            return;

        switch (effectName)
        {
            case "Click":
                effectSource.clip = clickSound;
                effectSource.Play();
                break;
            case "Gasp":
                effectSource.clip = gasp;
                effectSource.Play();
                break;
            case "Win":
                effectSource.clip = winSound;
                effectSource.Play();
                break;
            case "GameOver":
                effectSource.clip = gameOverSound;
                effectSource.Play();
                break;
            case "Shatter":
                var randomSound = random.Next(0, shatterSounds.Count);
                effectSource.clip = shatterSounds[randomSound];
                effectSource.Play();
                break;
            case "Pottery":
                effectSource.clip = pottery;
                effectSource.Play();
                break;
            case "Eating":
                effectSource.clip = eating;
                effectSource.Play();
                break;
            case "Footsteps":
                footstepSource.clip = footsteps;
                footstepSource.Play();
                break;
            default:
                break;
        }
    }

    public void SetMusic(string state)
    {
        if (Mute)
            return;
        switch (state)
        {
            case "Menu":
                if (menu == null)
                    return;
                ChangeSound(menu);
                break;
            case "Idle":
                if (idle == null)
                    return;
                PlayEffect("ChaseEnd");
                footstepSource.Stop();
                ChangeSound(idle);
                break;
            case "Chase":
                if (chase == null)
                    return;
                PlayEffect("Gasp");
                PlayEffect("Footsteps");
                ChangeSound(chase);
                break;
            default:
                break;
        }
    }

    void ChangeSound(AudioClip playMe)
    {
        AudioSource currentActiveSource, newActiveSource;

        if (IsChasing)
        {
            newActiveSource = idleAudioSource;
            currentActiveSource = chasingAudioSource;
        }
        else
        {
            newActiveSource = chasingAudioSource;
            currentActiveSource = idleAudioSource;
        }
        currentActiveSource.Stop();
        newActiveSource.clip = playMe;
        newActiveSource.Play();
    }
}
