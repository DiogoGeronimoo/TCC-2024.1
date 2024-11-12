using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Vector3 inicioFase; // Posição inicial do personagem na fase

    void Awake()
    {
        // Garante que o GameManager é único (Singleton)
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetInicioFase(Vector3 posicao)
    {
        // Define a posição inicial da fase
        inicioFase = posicao;
    }

    public void RenascerJogador(GameObject player)
    {
        // Reposiciona o jogador na posição inicial da fase
        player.transform.position = inicioFase;
        player.SetActive(true); // Certifique-se de que o jogador está ativo
    }
}