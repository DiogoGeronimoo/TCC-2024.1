using UnityEngine;

public class PlatformMover : MonoBehaviour
{
    public float speed = 2.0f; // Velocidade da plataforma
    public float moveRange = 5.0f; // Distância máxima que a plataforma pode se mover

    private Vector3 startPosition;
    private float moveDirection = 1.0f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float distanceTravelled = Mathf.Abs(transform.position.x - startPosition.x);

        // Verifica se a plataforma atingiu o limite do movimento
        if (distanceTravelled >= moveRange)
        {
            moveDirection *= -1; // Inverte a direção
        }

        // Move a plataforma
        transform.Translate(Vector2.right * speed * moveDirection * Time.deltaTime);
    }
}