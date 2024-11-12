using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    public float fallDelay = 0.2f; 
    private bool isPlayerOnPlatform = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true; // 
    }

    void Update()
    {
        if (isPlayerOnPlatform)
        {
            fallDelay -= Time.deltaTime;
            if (fallDelay <= 0)
            {
                rb.isKinematic = false; 
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = true; 
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerOnPlatform = false; 
            fallDelay = 0.2f; 
        }

        if (collision.gameObject.CompareTag("GameOver"))
        {
            Destroy(gameObject);
        }
    }
}