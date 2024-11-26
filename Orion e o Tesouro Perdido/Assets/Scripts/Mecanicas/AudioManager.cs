using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public AudioClip jumpSound; 
    public AudioClip attackSound; 
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump")) 
        {
            Jump();
        }

        if (Input.GetButtonDown("Fire1")) 
        {
            Attack();
        }
    }

    void Jump()
    {
        audioSource.PlayOneShot(jumpSound); 
    }

    void Attack()
    {
        audioSource.PlayOneShot(attackSound); 
    }
}