using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Chave : MonoBehaviour
{
    public int scoreChave;
    

       private void OnTriggerEnter2D(Collider2D other)
       {
           if (other.CompareTag("Player"))
           {
               GameControler.instance.UpdateScore(scoreChave);
               Destroy(gameObject);
              
           }
       }
}
