using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject lover1;
    public GameObject lover2;
    public bool TrappedLover1 = false;
    public bool TrappedLover2 = false;

    public Lover1 Trap1;
    public Lover2 Trap2;
    public Points points;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Lover1")
        {

            lover1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            Debug.Log("Collision with Lover1");
            lover1.transform.position = this.transform.position;
            TrappedLover1 = true;
            Trap1.trapped1 = true;

        }
        if (col.gameObject.tag == "Lover2")
        {
            lover2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            Debug.Log("Collision with Lover2");
            lover2.transform.position = this.transform.position;
            TrappedLover2 = true;
            Trap2.trapped2 = true;
        }


        if (TrappedLover1 == true && col.gameObject.tag == "Weapon2")
        {
            Trap1.trapped1 = false;
            Trap2.trapped2 = false;
            Destroy(this.gameObject);
            lover1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            lover1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            TrappedLover1 = false;
            points.points += 25;

        }
        else if (TrappedLover2 == true && col.gameObject.tag == "Weapon1")
        {
            Trap2.trapped2 = false;
            Trap1.trapped1 = false;
            Destroy(this.gameObject);
            lover2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            lover2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            TrappedLover2 = false;
            points.points += 25;

        }
        else if ((TrappedLover1 == false && TrappedLover2 == false) && (col.gameObject.tag == "Weapon1"|| col.gameObject.tag == "Weapon2"))
        {
            Destroy(this.gameObject);
            points.points += 50;
        }




    }



   
        
    
}
