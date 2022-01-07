using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lover2 : MonoBehaviour
{
    public bool trapped2 = false;
    public GameObject Lover1;
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
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Lover1")
        {
            Physics2D.IgnoreCollision(Lover1.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
    }
