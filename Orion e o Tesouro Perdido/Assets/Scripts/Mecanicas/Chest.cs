using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest : MonoBehaviour
{
    public string nextSceneName; 
    // Referência ao contador de chaves do jogador
    public KeyCounter keyCounter;

    // Flag para verificar se o baú já foi tocado
    private bool isOpened = false;

    // Método chamado quando o jogador interage com o baú
    private void OnTriggerEnter(Collider other)
    {
        // Verifica se o objeto que colidiu é o jogador
        if (other.CompareTag("Player") && !isOpened)
        {
            // Verifica se o jogador tem 3 ou mais chaves
            if (keyCounter.GetKeyCount() >= 3)
            {
                // O baú pode mudar de fase
                OpenChest();
            }
            else
            {
                // Caso o jogador tenha menos de 3 chaves
                Debug.Log("Você precisa de 3 chaves para abrir o baú.");
            }
        }
    }

    // Método que é chamado para abrir o baú e mudar de fase
    private void OpenChest()
    {
        isOpened = true;
        // Mudar a fase (exemplo simples, você pode colocar a lógica que preferir aqui)
        Debug.Log("Baú aberto! Mudando de fase...");

        // Aqui você pode adicionar a lógica de mudança de fase, por exemplo:
        SceneManager.LoadScene(nextSceneName);

        // Caso queira fazer o baú desaparecer ou algo visível, também pode ser feito aqui
        gameObject.SetActive(false); // Desativa o baú após abrir
    }
}