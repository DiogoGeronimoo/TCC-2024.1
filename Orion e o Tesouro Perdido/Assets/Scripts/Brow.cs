using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brow : MonoBehaviour
{
    private Rigidbody2D rig;

    public float speed;
    public int damage;
    public bool isRigth;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 1f);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isRigth!)
        {
            rig.velocity = Vector2.right * speed;
            
        }
        else
        {
            rig.velocity = Vector2.left * speed;
        }
        
        
    }
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Inimigo")
        {
            collision.GetComponent<Inimi1>().Damage(damage);
            Destroy(gameObject);
        }
    }
}