using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    private Transform player;
    public float smooth;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }
    void Update()
    {
        if(player.position.x >= -1.45 && player.position.x <= 369.32 )
        {
            Vector3 following = new Vector3(player.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, following, smooth * Time.deltaTime);
        }
        

    }
}