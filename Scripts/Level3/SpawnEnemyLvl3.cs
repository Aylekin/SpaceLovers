using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyLvl3 : MonoBehaviour
{
    //SpawnPoint
    [SerializeField]
    public GameObject[] Enemies;

    //Enemies

    public int speed = 3;
    public float maxValue = 7.7f;
    public float minValue = 1f;
    public float currentValue;

    //DangerZone
    GameObject instant;

    public void SpawnRandom()
    {
        instant = Instantiate(Enemies[UnityEngine.Random.Range(0, Enemies.Length)]);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Lover1" && instant.gameObject.tag == "Enemy1")
        {

            speed = 10;

        }
        else if (other.gameObject.tag == "Lover2" && instant.gameObject.tag == "Enemy2")
        {
            speed = 10;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lover1" && instant.gameObject.tag == "Enemy1")
        {

            Invoke("SlowDown", 2f);

        }
        else if (collision.gameObject.tag == "Lover2" && instant.gameObject.tag == "Enemy2")
        {
            Invoke("SlowDown", 2f);
        }

    }
    private void SlowDown()
    {
        speed = 3;
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnRandom();
        if (this.gameObject.tag == "Spawn2")
        {

            maxValue = -1.16f;
            minValue = -7.74f;
            currentValue = -5;
        }
        else if (this.gameObject.tag == "Spawn1")
        {

            maxValue = 2.25f;
            minValue = -4.45f;
            currentValue = -1;
        }
        else if(this.gameObject.tag=="Spawn3")
        {
            maxValue = 7.7f;
            minValue = -7.74f;
            currentValue = -5;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (this.gameObject.tag == "Spawn2" || this.gameObject.tag=="Spawn3")
        {
            currentValue += Time.deltaTime * speed;
            if (currentValue >= maxValue)
            {
                speed *= -1;
                currentValue = maxValue;
            }
            else if (currentValue <= minValue)
            {
                speed *= -1;
                currentValue = minValue;
            }
            instant.transform.position = new Vector2(currentValue, transform.position.y);


        }
        else if (this.gameObject.tag == "Spawn1")
        {

            currentValue += Time.deltaTime * speed;
            if (currentValue >= maxValue)
            {
                speed *= -1;
                currentValue = maxValue;
            }
            else if (currentValue <= minValue)
            {
                speed *= -1;
                currentValue = minValue;
            }
            instant.transform.position = new Vector2(transform.position.x, currentValue);
        }
    }

}



