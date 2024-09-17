using UnityEngine;

public class CobraController : MonoBehaviour
{
    public int damage = 1;
    public int vidaIni2;
    public float speed = 2f; 
    public Transform pointA; 
    public Transform pointB; 

    private Vector3 target; 

    void Start()
    {
        target = pointA.position;
    }

    void Update()
    {
       
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        
        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            if (target == pointA.position)
            {
                target = pointB.position;
            }
            else
            {
                target = pointA.position;
            }
        }
    }

    
    public void Damage(int dmg)
    {
        vidaIni2 -= dmg;
        if (vidaIni2 <= 0)
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