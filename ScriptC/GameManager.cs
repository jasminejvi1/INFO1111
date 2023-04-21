using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//control text in this part
using UnityEngine.SceneManagement;
//use this so player can replay the game

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public Text time_score;
    public GameObject GameOverUI;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }
   
    void Update()
    {
        time_score.text = Time.timeSinceLevelLoad.ToString("00");
        //show time as two digit number
        //count time from start each time restart the game
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //load the current scene name, reload scene
        Time.timeScale = 1;
    }
    public void Quit()
    {
        Application.Quit();
    }

    public static void GameOver(bool die)
    {
        if (die)
        {
            instance.GameOverUI.SetActive(true);
            Time.timeScale = 0f;
            //game stop
        }
    }
}
