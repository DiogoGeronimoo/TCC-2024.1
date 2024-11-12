using UnityEngine;
using UnityEngine.SceneManagement; // Importante para gerenciar as cenas

public class LevelTransition : MonoBehaviour
{
    public string nextSceneName; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}