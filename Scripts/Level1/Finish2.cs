using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish2 : MonoBehaviour
{
    public bool stay2 = false;
    public GameObject lover2;

    private void Start()
    {
        stay2 = false;
    }
    void Update()
    {
        
       
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Lover2")
        {
            stay2 = true;
        }
     
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lover2")
        {
            stay2 = false;
        }
    }

    


}
