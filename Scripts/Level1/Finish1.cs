using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Finish1 : MonoBehaviour
{
    public bool stay1 = false;
    public GameObject lover1;
    public GameObject lover2;
    public Finish2 s2;
    public GameObject canvas;
    public Points points;
    public Movement movement;
    public AudioSource zrodloDzwieku;
    public AudioSource zrodloDzwieku1;
    //public AudioClip winSound;
    public bool win;
    bool soundplayed = false;
    private void Start()
    {
        stay1 = false;
        zrodloDzwieku.Play();
        
    }
    private void Update()
    {

        if (s2.stay2 && stay1)
        {
            if (soundplayed == false)
            {
                PlaySound();
            }
            win = true;
            lover1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            lover2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            canvas.SetActive(true);
            points.win = true;
            movement.spriteRenderer2.sprite = movement.Lover2Win;
            movement.spriteRenderer1.sprite = movement.Lover1Win;
            
        }  
     
    }
    void PlaySound()
    {
        if (zrodloDzwieku != null)              // dodanie dźwięku 
            zrodloDzwieku.Stop();
            zrodloDzwieku1.Play();
        
        soundplayed = true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Lover1")
        {
            stay1 = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lover1")
        {
            stay1 = false;
        }
    }
   



}


