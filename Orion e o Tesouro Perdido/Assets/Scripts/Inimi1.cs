using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimi1 : MonoBehaviour
{
    public float speed;
    public float walkTime;
    private float timer;
    private bool walkRigth = true;
    private Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= walkTime)
        {
            walkRigth = !walkRigth;
            timer = 0f;

        }

        if (walkRigth)
        {
            transform.eulerAngles = new Vector2(0, 180);
            rig.velocity = Vector2.right * speed;
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 0);
            rig.velocity = Vector2.left * speed;
        }
        
        
        
    }
}
