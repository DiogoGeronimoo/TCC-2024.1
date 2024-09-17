using UnityEngine;
using UnityEngine.SceneManagement; // Importante para gerenciar as cenas

public class LevelTransition : MonoBehaviour
{
    public string nextSceneName; // Nome da próxima cena

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifique se o objeto que entrou no trigger tem a tag "Player"
        {
            // Carregar a próxima cena
            SceneManager.LoadScene(nextSceneName);
        }
    }
}