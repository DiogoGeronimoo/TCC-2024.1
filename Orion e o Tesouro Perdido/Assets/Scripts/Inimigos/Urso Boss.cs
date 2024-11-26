using UnityEngine;

public class UrsoBoss : MonoBehaviour
{
    public int VidaBoss;
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
    
        
        if (timer >= walkTime)
        {
            walkRigth = !walkRigth;
            timer = 0f;
        }

        
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        
        if (distanceToPlayer < detectionRange)
        {
            if (distanceToPlayer < attackRange)
            {
                MoveTowardsPlayer();
            }
            else
            {
                MoveTowardsPlayer();
            }
        }
        else
        {
            
            Patrol();
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
        VidaBoss -= dmg;
        if (VidaBoss <= 0)
        {
            Destroy(gameObject);
            GameControler.instance.Creditos();
            
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