using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHeart : MonoBehaviour
{
    public int healthValue;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<player>().IncreaseLife(healthValue);
            Destroy(gameObject);
              
        }
    }
}