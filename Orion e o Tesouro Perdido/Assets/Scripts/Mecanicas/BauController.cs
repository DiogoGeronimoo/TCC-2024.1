using UnityEngine;
using UnityEngine.SceneManagement; // Para trocar de fase

public class BauController : MonoBehaviour
{
    public string nomeProximaFase; // Nome da próxima cena
    private Animator animator;
    private bool faseMudando = false; // Evitar múltiplas chamadas

    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Nenhum Animator encontrado no objeto do baú!");
        }
    }

    // Detecta colisão com o jogador
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !faseMudando) // Certifique-se de que o jogador tenha a tag "Player"
        {
            faseMudando = true; // Impede múltiplas ativações
            AbrirBau();
        }
    }

    private void AbrirBau()
    {
        if (animator != null)
        {
            animator.SetTrigger("Abrir"); // Dispara a animação
            StartCoroutine(TrocarFaseAposAnimacao());
        }
    }

    private System.Collections.IEnumerator TrocarFaseAposAnimacao()
    {
        // Aguarda a duração da animação antes de mudar de fase
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        SceneManager.LoadScene(nomeProximaFase); // Troca para a próxima fase
    }
}