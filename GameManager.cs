using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
   private int Score;
   public  bool gameStarted;
    public Text scoreText;
    public Text highScore;

   
   public void startGame()
    {
        gameStarted = true;
       road b= FindObjectOfType<road >();
        b.callingCreateRoad();

    }
    private void Awake()
    {
        highScore.text = "best: " + getHighScore();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            startGame();
        }
    }
    public void EndGame()
    {
        SceneManager.LoadScene(0);
    }
    public void increaseScore()
    {
        Score++;
        scoreText.text = Score.ToString();
        if (Score > getHighScore())
        {
             PlayerPrefs.SetInt("High score", Score);
            highScore.text = Score.ToString();
        }
    }
    public int getHighScore()
    {
      int i  = PlayerPrefs.GetInt("High score");
        return i;
    }

}
