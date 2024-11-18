using UnityEngine;

public class KeyCounter : MonoBehaviour
{
    // Variável que mantém o número de chaves coletadas
    private int keyCount = 0;

    // Método para adicionar uma chave ao contador
    public void AddKey()
    {
        keyCount++;
        Debug.Log("Chave coletada! Total de chaves: " + keyCount);
    }

    // Método para retornar o número total de chaves
    public int GetKeyCount()
    {
        return keyCount;
    }
}