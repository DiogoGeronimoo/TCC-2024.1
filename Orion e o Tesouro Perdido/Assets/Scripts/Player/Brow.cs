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
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Inimigo 1"))
        {
            col.gameObject.GetComponent<Inimi1>().Damage(damage);
            Destroy(gameObject);
        }

        if (col.gameObject.CompareTag("Inimigo 2"))
        {
            col.gameObject.GetComponent<Morcego>().Damage(damage);
            Destroy(gameObject);
            
        }
    }

    
    
}