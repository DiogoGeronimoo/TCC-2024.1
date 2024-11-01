using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogoControl : MonoBehaviour
{
    [Header("Componentes")] 
    public GameObject dialogoObj;

    public Image profile;
    public Text speechText;
    public Text actorNameText;

    [Header("Settings")] 
    public float typingSpeed;

    public void speech(Sprite p, string txt, string actorName)
    {
        dialogoObj.SetActive(true);
        profile.sprite = p;
        speechText.text = txt;
        actorNameText.text = actorName;
    }
}
