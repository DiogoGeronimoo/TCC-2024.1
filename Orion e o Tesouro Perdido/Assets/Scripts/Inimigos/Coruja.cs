using UnityEngine;

public class Coruja : MonoBehaviour
{
    // Velocidade de movimento da coruja
    public float flySpeed = 3f;

    // Ponto inicial e final do patrulhamento (pode ser transform positions)
    public Transform pointA;
    public Transform pointB;

    // Referências
    private Rigidbody2D rb;
    private Animator anim;

    // Direção da coruja
    private bool movingToPointB = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // Definir a velocidade inicial
        rb.velocity = new Vector2(flySpeed, 0f);
    }

    void Update()
    {
        Patrol();
    }

    void Patrol()
    {
        // Verifica a direção e altera o movimento da coruja entre os pontos A e B
        if (movingToPointB)
        {
            rb.velocity = new Vector2(flySpeed, rb.velocity.y);
            if (Vector2.Distance(transform.position, pointB.position) < 0.1f)
            {
                movingToPointB = false;
                Flip();
            }
        }
        else
        {
            rb.velocity = new Vector2(-flySpeed, rb.velocity.y);
            if (Vector2.Distance(transform.position, pointA.position) < 0.1f)
            {
                movingToPointB = true;
                Flip();
            }
        }

        // Atualiza a animação de voo
        //anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
    }

    // Método para virar a coruja quando muda de direção
    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Inverte a direção
        transform.localScale = scale;
    }

    
    
}