using UnityEngine;

public class Morcego : MonoBehaviour
{
    public int VidaMorcego;
    public int damage = 1;
    public Transform player; // Referência ao jogador
    public float speed = 3f; // Velocidade de movimento do inimigo
    public float attackRange = 5f; // Distância para começar o ataque
    public float detectionRange = 10f; // Distância para detectar o jogador

    private Vector3 initialPosition; // Posição inicial do inimigo

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Detectar jogador
        if (distanceToPlayer < detectionRange)
        {
            // Se estiver no alcance de ataque, mover em direção ao jogador
            if (distanceToPlayer < attackRange)
            {
                MoveTowardsPlayer();
            }
        }
        else
        {
            // Voltar para a posição inicial se o jogador sair do alcance
            ReturnToInitialPosition();
        }
    }

    void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    void ReturnToInitialPosition()
    {
        Vector3 direction = (initialPosition - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnDrawGizmosSelected()
    {
        // Desenhar o alcance de ataque e detecção no editor para visualização
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