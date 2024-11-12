using UnityEngine;

public class EnemyBear : MonoBehaviour
{
    public float moveSpeed = 2f;           // Velocidade do movimento do urso
    public float detectionRange = 10f;      // Distância de detecção do personagem
    public float attackRange = 5f;         // Distância para atacar o personagem
    public Transform player;               // Referência para o personagem
    public float attackCooldown = 1f;      // Tempo de cooldown entre ataques
    private float lastAttackTime = 0f;     // Tempo do último ataque

    private enum State
    {
        Patrol,
        Chase,
        Attack
    }

    private State currentState = State.Patrol;

    void Update()
    {
        switch (currentState)
        {
            case State.Patrol:
                Patrol();
                break;
            case State.Chase:
                ChasePlayer();
                break;
            case State.Attack:
                AttackPlayer();
                break;
        }

        // Verificar a detecção do jogador
        if (Vector2.Distance(transform.position, player.position) <= detectionRange)
        {
            currentState = State.Chase;
        }
        else if (Vector2.Distance(transform.position, player.position) <= attackRange && Time.time - lastAttackTime >= attackCooldown)
        {
            currentState = State.Attack;
        }
        else if (Vector2.Distance(transform.position, player.position) > detectionRange)
        {
            currentState = State.Patrol;
        }
    }

    void Patrol()
    {
        // O urso patrulha (Aqui você pode definir um caminho simples ou movimento aleatório)
        // Exemplo de movimentação simples (aqui você pode ajustar para um sistema mais avançado, como waypoints)

        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        // Se o urso ver o jogador, começa a perseguição
        if (Vector2.Distance(transform.position, player.position) <= detectionRange)
        {
            currentState = State.Chase;
        }
    }

    void ChasePlayer()
    {
        // Move em direção ao jogador
        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);

        // Verificar se está perto o suficiente para atacar
        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            currentState = State.Attack;
        }
    }

    void AttackPlayer()
    {
        // Atacar o jogador (pode ser um simples dano, animação, etc)
        Debug.Log("Urso atacou o jogador!");

        // Registrar o tempo do último ataque
        lastAttackTime = Time.time;

        // Voltar para o estado de perseguição após o ataque
        currentState = State.Chase;
    }
}