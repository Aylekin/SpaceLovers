using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour
{

    public Points points;
    public SpawnEnemy spawnEnemy;
    int hit = 0;

    // Use this for initialization
    void Start()
    {

        if (PlayerPrefs.HasKey("Hit"))
        {
            hit = PlayerPrefs.GetInt("Hit");

        }
        else { hit = 0; }
       

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Weapon1" || col.gameObject.tag == "Weapon2")
        {
            points.points += 50;

            Destroy(this.gameObject);


        }
        if (col.gameObject.tag == "Lover1" || col.gameObject.tag == "Lover2")
        {

            Hit();

        }
    }
    void Hit()
    {
        hit++;
        if (hit == 1)
        {
            points.lives =2;
            PlayerPrefs.SetInt("Lives", points.lives);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            PlayerPrefs.SetInt("Hit", hit);
        }
        if (hit == 2)
        {
            points.lives = 1;
            PlayerPrefs.SetInt("Lives", points.lives);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            PlayerPrefs.SetInt("Hit", hit);
        }
        if (hit == 3)
        {
            points.lives = 0;
            PlayerPrefs.SetInt("Lives", points.lives);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
           
            hit = 0;
            PlayerPrefs.SetInt("Hit", hit);
        }
    }
    // Update is called once per frame
    void Update()
    {
       
            
        }
        
    }

