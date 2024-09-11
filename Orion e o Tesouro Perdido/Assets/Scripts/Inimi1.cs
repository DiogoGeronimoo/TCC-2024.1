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
    public Transform barraVida;
    public GameObject barraVidaObject;

    private Vector3 barraVidaScale;
    private float vidaPercent;
    private float timer;
    private bool walkRigth = true;
    private Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        barraVidaScale = barraVida.localScale;
        vidaPercent = barraVidaScale.x / vidaIni;
        rig = GetComponent<Rigidbody2D>();

    }

    private void UpdatebarraVida()
    {
        barraVidaScale.x = vidaPercent * vidaIni;
        barraVida.localScale = barraVidaScale;
    }

    // Update is called once per frame
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
        barraVidaObject.transform.localScale = new Vector3(barraVidaObject.transform.localScale.x * -1,barraVidaObject.transform.localScale.y,barraVidaObject.transform.localScale.z);  
                                                             


    }

    public void Damage(int dmg)
    {
        vidaIni -= dmg;
        UpdatebarraVida();
        if (vidaIni <= 0)
        {
            Destroy(gameObject);
            
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("bateu!");
            collision.gameObject.GetComponent<player>().Damage(damage);
            
        }
        
    }
}
