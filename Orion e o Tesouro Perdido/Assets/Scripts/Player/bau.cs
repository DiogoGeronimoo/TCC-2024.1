using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class bau : MonoBehaviour
{
        public string nomeProximaFase; // Nome da próxima cena

    
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene(nomeProximaFase);
            }
        }
        
    }