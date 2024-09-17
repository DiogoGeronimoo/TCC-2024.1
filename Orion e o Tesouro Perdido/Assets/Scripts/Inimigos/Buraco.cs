using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buraco : MonoBehaviour
{
    public int damage = 10;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("bateu!");
            collision.gameObject.GetComponent<player>().Damage(damage);
            
        }
        
    }
}