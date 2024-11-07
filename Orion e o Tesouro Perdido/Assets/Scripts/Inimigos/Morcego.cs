using UnityEngine;

public class Morcego : MonoBehaviour
{
    public int VidaMorcego;
    public int damage = 1;
    public Transform player; 
    public float speed = 3f; 
    public float attackRange = 5f; 
    public float detectionRange = 10f;
    public float distance = 10f;
    private float timer;
    private bool walkRigth = true;
    public float walkTime;
    

    private Vector2 startPosition;
    private Animator anim;
    private Rigidbody2D rig;  
    private Vector3 initialPosition; 

    void Start()
    {
        initialPosition = transform.position;
        startPosition = transform.position;
        rig = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;
    
        // Se o tempo de patrulha passar, inverter o movimento (direita/esquerda)
        if (timer >= walkTime)
        {
            walkRigth = !walkRigth;
            timer = 0f;
        }

        // Calculando a distância do morcego para o jogador
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Se o jogador está dentro do raio de detecção
        if (distanceToPlayer < detectionRange)
        {
            // Se estiver dentro do raio de ataque, o morcego segue o jogador
            if (distanceToPlayer < attackRange)
            {
                MoveTowardsPlayer();
            }
            else
            {
                // Se o jogador está dentro do raio de detecção mas fora do raio de ataque, o morcego ainda segue
                MoveTowardsPlayer();
            }
        }
        else
        {
            // Se o jogador não está mais no raio de detecção, patrulha da esquerda para a direita
            Patrol();
        }
    }

// Função para mover o morcego em direção ao jogador
    void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

// Função de patrulha (anda da direita para a esquerda)
    void Patrol()
    {
        if (walkRigth)
        {
            transform.eulerAngles = new Vector2(0, 180);  // Vira para a direita
            rig.velocity = Vector2.right * speed;  // Move para a direita
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 0);  // Vira para a esquerda
            rig.velocity = Vector2.left * speed;  // Move para a esquerda
        }
    }
    void ReturnToInitialPosition()
    {
        Vector3 direction = (initialPosition - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
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
        VidaMorcego -= dmg;
        if (VidaMorcego <= 0)
        {
            Destroy(gameObject);
            
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