using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogo : MonoBehaviour
{
    public Sprite profile;
    public string speechTxt;
    public string actorName;
    public LayerMask playerLayerMask;

    private DialogoControl dc;

    private void Start()
    {
        dc = FindObjectOfType<DialogoControl>();
    }

    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, playerLayerMask);

    } 
}
