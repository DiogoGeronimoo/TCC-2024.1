using UnityEngine;

public class InicioDaFase : MonoBehaviour
{
    void Start()
    {
        GameManager.instance.SetInicioFase(transform.position);
    }
}