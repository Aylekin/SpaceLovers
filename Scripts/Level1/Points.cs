using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
    public Text txtTime;
    public Text txtPoints;
    public Text txtLives;
    public Text txtBestScore;
    public int lives;
    public int points;
    public int currentScore = 0;
    public int sumPoints;
    public int time;
    float nextTimeDec = 0f;
    public bool win = false;
    public Finish1 finish1;
    bool addedpoints;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = PlayerPrefs.GetInt("CurrentScore");
        addedpoints = false;
        points = 0;
        time = 60;
        Time.timeScale = 1f;
        //PlayerPrefs.DeleteKey("Lives");
        //PlayerPrefs.DeleteKey("SumPoints");
        //PlayerPrefs.DeleteKey("CurrentScore");
        sumPoints = PlayerPrefs.GetInt("SumPoints");
      
        if (PlayerPrefs.HasKey("Lives"))
        {
            lives = PlayerPrefs.GetInt("Lives");

        }
        else { lives = 3; }

    }

    
    void Update()
    {
        AddPoints();
        DecreaseTime(); 
        txtTime = txtTime.gameObject.GetComponent<Text>();
        txtTime.text = "Time : " + time.ToString();
        txtPoints = txtPoints.gameObject.GetComponent<Text>();
        txtPoints.text = "Points : " + points.ToString();
        txtBestScore.text = "Best Score : " + sumPoints.ToString();
        txtLives.text = "X " + lives.ToString();

    }
    public void AddPoints()
    {
        if (finish1.win == true)
        {
            if (!addedpoints)
            {
                currentScore += points + time;
                PlayerPrefs.SetInt("CurrentScore", currentScore);
                if (currentScore > sumPoints)
                {
                    sumPoints = currentScore;
                    PlayerPrefs.SetInt("SumPoints", sumPoints);
                    PlayerPrefs.Save();
                    addedpoints = true;
                }
            }
        }
    }
    void DecreaseTime()
    {
        if (win == false)
        {
            if ((Time.unscaledTime > nextTimeDec) && time != 0)
            {

                time -= 1;
                nextTimeDec = Time.unscaledTime + 1;

            }
        }
      
        
    }
   
}
