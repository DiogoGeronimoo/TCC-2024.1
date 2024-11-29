using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioSource sound;


    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    

    public void LoadGame()
    {
        Destroy(sound);
        SceneManager.LoadScene(1);
    }
}
