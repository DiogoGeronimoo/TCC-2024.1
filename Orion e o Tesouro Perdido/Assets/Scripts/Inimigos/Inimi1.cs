using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimi1 : MonoBehaviour
{
    public float speed;
    public float walkTime;
    public int vidaIni;
    public int damage = 1;
    
    
    private float timer;
    private bool walkRigth = true;
    private Rigidbody2D rig;

    private Animator anim;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
    
    
    void FixedUpdate()
    {
        
        timer += Time.deltaTime;
        if (timer >= walkTime)
        {
            walkRigth = !walkRigth;
            timer = 0f;

        }

        if (walkRigth)
        {
            transform.eulerAngles = new Vector2(0, 180);
            rig.velocity = Vector2.right * speed;
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 0);
            rig.velocity = Vector2.left * speed;
        }
        
    }

    public void Damage(int dmg)
    {
        vidaIni -= dmg;
        if (vidaIni <= 0)
        {
            anim.SetTrigger("morte");
            Destroy(gameObject, 0.5f);
            
            
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<player>().Damage(damage);
            
        }
        
    }
}
