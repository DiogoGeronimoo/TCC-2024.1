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
    public float movement;
    

    private Vector2 startPosition;   
          

    

    private Vector3 initialPosition; 

    void Start()
    {
        initialPosition = transform.position;
        startPosition = transform.position;
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        
        if (distanceToPlayer < detectionRange)
        {
            
            if (distanceToPlayer < attackRange)
            {
                MoveTowardsPlayer();
            }
        }
        else
        {
            
            ReturnToInitialPosition();
        }
       
        float movement = Mathf.PingPong(Time.time * speed, distance) - (distance / 2);
        transform.position = new Vector2(startPosition.x + movement, transform.position.y);
        
        
        
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