using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePlaca : MonoBehaviour
{
    public string[] dialoguePlaca;
    public int dialogueIndex;
    public GameObject dialoguePanel;
    public Text dialogueText;

    public Text nomePlayer;
    public Image imagePlayer;
    public Sprite spritePlaca;
    public bool readyToSpeak;
    public bool startDialogue;
    
    void Start()
    {
        dialoguePanel.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && readyToSpeak)
        {
            if (!startDialogue)
            {
                FindObjectOfType<player>().speed = 0f;
                StartDialogue();

            }
            else if (dialogueText.text == dialoguePlaca[dialogueIndex])
            {
                NextDialogue();
                
            }
            
            
        }
        
    }

    void NextDialogue()
    {
        dialogueIndex++;
        if (dialogueIndex < dialoguePlaca.Length)
        {
            StartCoroutine(ShowDialogue());
        }
        else
        {
            dialoguePanel.SetActive(false);
            startDialogue = false;
            dialogueIndex = 0;
            FindObjectOfType<player>().speed = 5f;
        }
    }

    void StartDialogue()
    {
        nomePlayer.text = "Orion";
        imagePlayer.sprite = spritePlaca;
        startDialogue = true;
        dialogueIndex = 0;
        dialoguePanel.SetActive(true);
        StartCoroutine(ShowDialogue());
    }

    IEnumerator ShowDialogue()
    {
        dialogueText.text = "";
        foreach (char letteer in dialoguePlaca[dialogueIndex] )
        {
            dialogueText.text += letteer;
            yield return new WaitForSeconds(0.1F);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            readyToSpeak = true;

        }
        if (other.CompareTag("Player"))
        {
            readyToSpeak = false;

        }
       
        
        
    }
    
}
