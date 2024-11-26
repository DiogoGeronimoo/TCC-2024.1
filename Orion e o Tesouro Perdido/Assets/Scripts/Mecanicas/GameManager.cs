using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private Vector3 inicioFase;

    void Awake()
    {
       
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
        inicioFase = posicao;
    }

    public void RenascerJogador(GameObject player)
    {
        player.transform.position = inicioFase;
        player.SetActive(true); 
    }
}