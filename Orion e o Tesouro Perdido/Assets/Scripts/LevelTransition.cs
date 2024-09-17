using UnityEngine;
using UnityEngine.SceneManagement; // Importante para gerenciar as cenas

public class LevelTransition : MonoBehaviour
{
     // Nome da próxima cena
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Fase2");
        }
    }
    
}