using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lover1 : MonoBehaviour
{

    public bool trapped1 = false;
    private Animator anim;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("right") || Input.GetKey("left"))
        {
            anim.enabled = true;
        }
        else
        {
            anim.enabled = false;
        }
    }
     
}
