using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Chave : MonoBehaviour
{
    public int scoreValue;
   


       private void OnTriggerEnter2D(Collider2D other)
       {
           if (other.CompareTag("Player"))
           {
               GameControler.instance.UpdateScore(scoreValue);
               Destroy(gameObject);
              
           }
       }
}
