using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player : MonoBehaviour
{
    public int health = 3;
    public float speed;
    public float jumpForce;
    public GameObject Brow;
    public Transform firePoint;
    public bool isJumping;
    public bool doubleJump;
    public GameObject dialogueObj;
    private bool withParticle = false;
    
    

    private bool isFire;
    private Rigidbody2D rig;
    private Animator anim;
    private float moviment;
    private Vector3 respawnPoint; 

    public GameObject atkCollider;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GameControler.instance.UpdateLives(health);
        respawnPoint = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        BrowFire();

        if (withParticle == true)
        {
            dialogueObj.SetActive(true);
        }
        
        else if (withParticle == false)
        {
            dialogueObj.SetActive(false);
        }
        
    }

     void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        
        float moviment = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(moviment * speed, rig.velocity.y);
        
        
        if (moviment > 0)
        {
            if(!isJumping && !isFire)
            {
                anim.SetInteger("transition", 0);
            }
            
            transform.eulerAngles = new Vector3(0, 0, 0);
            
        }
        
        else if (moviment < 0)
        {
            if(!isJumping && !isFire)
            {
                anim.SetInteger("transition", 0);
            } 
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        else if (moviment == 0 && !isJumping && !isFire)
        {
            anim.SetInteger("transition", 1);
        }

    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                anim.SetInteger("transition", 2);
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                isJumping = true;
                ParticleObserver.onParticleSpawnEvent(transform.position);
                AudioObsever.OnPlaySfxEvent("pulo");
            }
            else
            {
                if (doubleJump)
                {
                    anim.SetInteger("transition", 2);
                    rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                    ParticleObserver.onParticleSpawnEvent(transform.position);
                    AudioObsever.OnPlaySfxEvent("pulo");
                }
            }
        }
    }

    void BrowFire()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine("Fire");
        }
    }

    IEnumerator Fire()
    {
        isFire = true;
        anim.SetInteger("transition", 3);
        GameObject Brow = Instantiate(this.Brow, firePoint.position, firePoint.rotation);
        if (transform.rotation.y == 0)
        {
            Brow.GetComponent<Brow>().isRigth = true;

        }
        if (transform.rotation.y == 180)
        {
            Brow.GetComponent<Brow>().isRigth = false;
                
        }
        yield return new WaitForSeconds(.3f);
        isFire = false;
        anim.SetInteger("transition", 0);
        
        
    }

    public void Damage(int dmg)
    {
        health -= dmg;
        GameControler.instance.UpdateLives(health);
        anim.SetTrigger("hit");
        
        if (transform.rotation.y == 0)
        {
            transform.position += new Vector3(-5,0, 0);
        }
        if (transform.rotation.y == 180)
        {
            transform.position += new Vector3(5,0, 0);
        }
        
        
        if (health <= 0)
        {
            Die();
            GameControler.instance.GameOver();
            AudioObsever.OnStopMusicEvent();
        }
    }

    public void IncreaseLife(int value)
    {
        health += value;
        GameControler.instance.UpdateLives(health);
 
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == 8)
        {
            isJumping = false;

        }
        if (coll.gameObject.layer == 9)
        {
            GameControler.instance.GameOver();

        }
        
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    IEnumerator PegarPowerUp()
    {
        speed += 4;

        yield return new WaitForSeconds(10f);

        speed -= 4;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Raio"))
        {
            StartCoroutine(PegarPowerUp());
        }
        
  
    }
    
    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.CompareTag("Particula"))
        {
            Debug.Log("TA AQ");
            withParticle = true;
            dialogueObj.SetActive(true);
        }
    }
    
    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.CompareTag("Particula"))
        {
            Debug.Log("saiu");
            withParticle = false;
            dialogueObj.SetActive(false);
        }
    }
    
    

}