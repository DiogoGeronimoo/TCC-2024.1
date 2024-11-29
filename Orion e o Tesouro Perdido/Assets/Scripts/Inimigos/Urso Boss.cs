using System;
using UnityEngine;

public class UrsoBoss : MonoBehaviour
{
    public int VidaBoss;
    public int damage = 1;
    public Transform player; 
    public float speed = 3f;
    public float attackRange; // Distância para o pulo de ataque
    public float detectionRange; // Distância de detecção
    private float timer;
    private bool walkRigth = true;
    public float walkTime;
    public float jumpForce = 5f; // Força do pulo

    private bool playerInRedZone = false; // Checar se o jogador está na área vermelha
    private Vector2 startPosition;
    private Animator anim;
    private Rigidbody2D rig;
    private Vector3 initialPosition;

    private float jumpCooldown = 3f; // Tempo de espera entre pulos
    private float jumpCooldownTimer = 0f; // Temporizador do cooldown
    private bool isJumping = false; // Verifica se o boss está pulando
    private bool isInAttackRange = false; // Para verificar se o boss está no range de ataque

    void Start()
    {
        initialPosition = transform.position;
        startPosition = transform.position;
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();  // Inicializando o Animator
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= walkTime)
        {
            walkRigth = !walkRigth;
            timer = 0f;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Verifica se o jogador entrou no range de ataque
        if (distanceToPlayer <= attackRange && !isJumping && jumpCooldownTimer <= 0f)
        {
            isInAttackRange = true; // Marca que o jogador está dentro do range de ataque
            JumpAttack();
            jumpCooldownTimer = jumpCooldown; // Reinicia o cooldown do pulo
            isJumping = true; // Marca que o boss está pulando
        }
        else if (distanceToPlayer <= detectionRange)
        {
            if (!isJumping)
            {
                MoveTowardsPlayer();
            }
            Debug.Log("Ele ta Correndo");
        }
        else
        {
            Patrol();
        }

        // Atualiza o temporizador de cooldown do pulo
        if (jumpCooldownTimer > 0f)
        {
            jumpCooldownTimer -= Time.deltaTime;
        }

        // Verifica se o boss terminou o pulo (ao aterrissar)
        if (rig.velocity.y == 0 && isJumping)
        {
            // O boss aterrissou, finaliza o pulo e chama o evento de animação
            isJumping = false;
            OnJumpEnd(); // Chama o método para finalizar o pulo
        }
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    void Patrol()
    {
        if (walkRigth)
        {
            transform.eulerAngles = new Vector2(0, 180); 
            rig.velocity = Vector2.left * speed; 
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 0); 
            rig.velocity = Vector2.right * speed;  
        }
    }

    void JumpAttack()
    {
        // Ativa a animação de pulo
        anim.SetTrigger("Jump");
        Debug.Log("JumpAttack foi chamado");
        
        // Calcular direção para pular em direção ao jogador
        Vector2 direction = (player.position - transform.position).normalized;
        
        // Aplica uma força de pulo mais forte no eixo Y para garantir que o boss suba
        Vector2 jumpDirection = new Vector2(direction.x, 1).normalized;
        rig.AddForce(jumpDirection * jumpForce, ForceMode2D.Impulse);
        Debug.Log("Ele ta pulando");
    }

    // Este método será chamado ao final da animação de pulo
    public void OnJumpEnd()
    {
        Debug.Log("Pulo finalizado.");
        anim.SetTrigger("pulou"); // Dispara o trigger "pulou" após o final da animação
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }

    public void Damage(int dmg)
    {
        VidaBoss -= dmg;
        if (VidaBoss <= 0)
        {
            Destroy(gameObject);
            GameControler.instance.Creditos();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<player>().Damage(damage);
            Debug.Log("O Boss atingiu o jogador!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RedZone"))
        {
            playerInRedZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("RedZone"))
        {
            playerInRedZone = false;
        }
    }
}
