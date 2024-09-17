using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource musicSource, sfxSource;
    public AudioClip clipPulo;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        AudioObsever.PlayMusicEvent += TocarMusica;
        AudioObsever.PlayMusicEvent += PararMusica;
        AudioObsever.PlaySfxEvent += TocarEfeitoSonoro;

    }
    

    private void OnDisable()
    {
        AudioObsever.PlayMusicEvent -= TocarMusica;
        AudioObsever.PlayMusicEvent -= PararMusica;
        AudioObsever.PlaySfxEvent -= TocarEfeitoSonoro;
    }

    void TocarEfeitoSonoro(string nomeDoClip)
    {
        switch (nomeDoClip)
        {
            case "pulo":
                sfxSource.PlayOneShot(clipPulo);
                break;
            case "Coletavel":
                sfxSource.PlayOneShot(clipPulo);
                break;
            default:
                Debug.LogError($"efeito sonoro {nomeDoClip} nao encontrado");
                break;
            
        }
        
    }

    void TocarMusica()
    {
        musicSource.Play();
    }
    
    void PararMusica()
    {
        musicSource.Stop();
    }
}

