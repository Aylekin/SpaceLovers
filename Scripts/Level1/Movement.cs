using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{

    [SerializeField]
    public Rigidbody2D lover1;
    [SerializeField]
    public Rigidbody2D lover2;

    [SerializeField]
    public float forceX1 = 0, forceY1 = 0, forceX2 = 0, forceY2 = 0;
    [SerializeField]
    public float speed;


    [SerializeField]
    public Sprite Lover1Normal;
    [SerializeField]
    public Sprite Lover1Left;
    [SerializeField]
    public Sprite Lover1Right;
    [SerializeField]
    public Sprite Lover1Up;
    public Sprite Lover2Normal;
    public Sprite Lover2Left;
    public Sprite Lover2Right;
    public Sprite Lover2Up;
    public Sprite Lover1Win;
    public Sprite Lover2Win;
    public SpriteRenderer spriteRenderer1;
    public SpriteRenderer spriteRenderer2;

    public GameObject weapon;
    public GameObject weapon2;
    public GameObject pivot1;
    public GameObject pivot2;
    public GameObject pausedText;
    public GameObject end;

    public Lover1 TrappedLover1;
    public Lover2 TrappedLover2;
    public Points points;
    [SerializeField]
    public AudioSource zrodloDzwieku;
    public Finish1 finish1;


    public Enemy Enemy;
    bool soundplayed = false;
    private bool GameOver = false;
    int paused = 1;


    public void LoadLvl()
    {
        points.lives = 3;
        PlayerPrefs.SetInt("Lives", points.lives);
        SceneManager.LoadScene("Level1");
    }

    public void LoadMenu()
    {
        points.lives = 3;
        PlayerPrefs.SetInt("Lives", points.lives);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Menu");

    }

    void PlaySound()
    {
        if (zrodloDzwieku != null)              // dodanie dźwięku 
            finish1.zrodloDzwieku.Stop();
            zrodloDzwieku.Play();
        soundplayed = true;
    }
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            PlayerPrefs.GetInt("Lives");
        }

        if (spriteRenderer1.sprite == null)
            spriteRenderer1.sprite = Lover1Normal;
        if (spriteRenderer2.sprite == null)
            spriteRenderer2.sprite = Lover2Normal;

    }

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.Escape))
        {
            paused++;
            if (paused % 2 == 0)
            {

                lover1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                lover1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                lover2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                lover2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                points.win = false;
                pausedText.SetActive(false);
            }
            else
            {
                lover1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
                lover2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
                points.win = true;
                pausedText.SetActive(true);
            }



        }
       

        if ((TrappedLover1.trapped1 && TrappedLover2.trapped2 && GameOver == false) || (points.time == 0 && GameOver == false))
        {
            points.lives -= 1;
            PlayerPrefs.SetInt("Lives", points.lives);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (points.lives == 0)
        {
            GameOver = true;
        }
        if (GameOver == true)
        {
            if (soundplayed == false)
                PlaySound();
            lover1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            lover2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            end.SetActive(true);
            points.win = true;
            PlayerPrefs.DeleteKey("CurrentScore");

        }

        if (Input.GetKey(KeyCode.X))
        {
            weapon.SetActive(true);
            
        }
        else
        {
            weapon.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            weapon2.SetActive(true);
        }
        else
        {
            weapon2.SetActive(false);
        }

        if (Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("right") || Input.GetKey("left"))
        {

            if (Input.GetKey("up"))
            {
                forceX1 = 0; forceY1 = speed;
                spriteRenderer1.sprite = Lover1Up;

                forceX2 = 0; forceY2 = speed;
                spriteRenderer2.sprite = Lover2Up;

                pivot1.transform.rotation = Quaternion.Euler(Vector3.forward * 180);
                pivot2.transform.rotation = Quaternion.Euler(Vector3.forward * 180);

            }
            if (Input.GetKey("down"))
            {
                forceX1 = 0; forceY1 = -speed;
                spriteRenderer1.sprite = Lover1Normal;
                forceX2 = 0; forceY2 = -speed;
                spriteRenderer2.sprite = Lover2Normal;
                pivot1.transform.rotation = Quaternion.Euler(Vector3.forward * 0);
                pivot2.transform.rotation = Quaternion.Euler(Vector3.forward * 0);

            }
            if (Input.GetKey("left"))
            {
                forceX1 = -speed; forceY1 = 0;
                spriteRenderer1.sprite = Lover1Left;


                forceX2 = speed; forceY2 = 0;
                spriteRenderer2.sprite = Lover2Right;
                pivot1.transform.rotation = Quaternion.Euler(Vector3.forward * -90);
                pivot2.transform.rotation = Quaternion.Euler(Vector3.forward * 90);
            }
            if (Input.GetKey("right"))
            {
                forceX1 = speed; forceY1 = 0;
                spriteRenderer1.sprite = Lover1Right;


                forceX2 = -speed; forceY2 = 0;
                spriteRenderer2.sprite = Lover2Left;

                pivot1.transform.rotation = Quaternion.Euler(Vector3.forward * 90);
                pivot2.transform.rotation = Quaternion.Euler(Vector3.forward * -90);
            }

            float playerX1 = lover1.position.x;
            float playerY1 = lover1.position.y;
            float playerX2 = lover2.position.x;
            float playerY2 = lover2.position.y;

            lover1.MovePosition(new Vector2(playerX1 + forceX1, playerY1 + forceY1));
            lover2.MovePosition(new Vector2(playerX2 + forceX2, playerY2 + forceY2));
        }


    }
    void OnApplicationQuit()
    {
        PlayerPrefs.DeleteKey("Lives");
        PlayerPrefs.DeleteKey("Hit");
    }
} 
