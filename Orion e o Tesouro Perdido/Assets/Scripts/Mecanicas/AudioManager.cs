using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public AudioClip jumpSound;    // Áudio do pulo
    public AudioClip attackSound;  // Áudio do ataque
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump")) // Verifica se o botão de pulo foi pressionado
        {
            Jump();
        }

        if (Input.GetButtonDown("Fire1")) // Verifica se o botão de ataque foi pressionado
        {
            Attack();
        }
    }

    void Jump()
    {
        // Coloque aqui a lógica de pulo do personagem
        audioSource.PlayOneShot(jumpSound); // Toca o som do pulo
    }

    void Attack()
    {
        // Coloque aqui a lógica de ataque do personagem
        audioSource.PlayOneShot(attackSound); // Toca o som do ataque
    }
}