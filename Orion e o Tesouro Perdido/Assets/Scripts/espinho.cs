using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class espinho : MonoBehaviour
{
    public int damage = 1;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("bateu!");
            collision.gameObject.GetComponent<player>().Damage(damage);
            
        }
        
    }
}
