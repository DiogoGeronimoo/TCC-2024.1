using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Chavecolete : MonoBehaviour
{
    public int scoreValue1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameControler.instance.UpdateScore1(scoreValue1);
            Destroy(gameObject);
          
        }
    }


  
}
