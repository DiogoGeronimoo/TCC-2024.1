using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Chave : MonoBehaviour
{
    public int scoreValue;
    private AudioSource sound;

    private void Awake()
    {
        sound = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D other)
       {
           if (other.CompareTag("Player"))
           {
               sound.Play();
               GameControler.instance.UpdateScore(scoreValue);
               Destroy(gameObject, 0.2f);
              
           }
       }
}
