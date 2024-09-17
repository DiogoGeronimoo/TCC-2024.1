using System;
using System.Collections;
using System.Collections.Generic;
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
       // atkCollider.SetActive(false);
        GameControler.instance.UpdateLives(health);
        respawnPoint = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        BrowFire();
    }

     void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        // se nao precionar nada o valor e 0.se precionar Direita, valor e 1. Esquerda valor minimo -1.
        float moviment = Input.GetAxis("Horizontal");
        
        // adiciona velocidade ao corpo do personagem no eixo x e y
        rig.velocity = new Vector2(moviment * speed, rig.velocity.y);
        
        //andando pra direita
        if (moviment > 0)
        {
            if(!isJumping)
            {
                anim.SetInteger("transition", 0);
            }
            
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        
        //andando pra esquerda
        else if (moviment < 0)
        {
            if(!isJumping)
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
        StartCoroutine("Fire");
    }

    IEnumerator Fire()
    {
        if (Input.GetKeyDown(KeyCode.E))
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
            yield return new WaitForSeconds(0.2f);
            isFire = false;
            anim.SetInteger("transition", 0);
        }
        
    }

    public void Damage(int dmg)
    {
        health -= dmg;
        GameControler.instance.UpdateLives(health);
        //anim.SetTrigger("hit");
        
        if (health <= 0)
        {
            
            
            Die();
            //chamar game over
            GameControler.instance.GameOver();
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
        // Aqui você pode adicionar a lógica para destruir o personagem
        // Exemplo: Destruir o GameObject do jogador
        Destroy(gameObject);

        // Ou você pode adicionar lógica para reiniciar o jogo ou exibir uma tela de game over
        // Exemplo: Recarregar o nível atual (isto é opcional)
        // UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}