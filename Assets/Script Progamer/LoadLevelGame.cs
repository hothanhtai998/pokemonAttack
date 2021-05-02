using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelGame : MonoBehaviour
{
    //public int scores = FindObjectOfType<ScoreDisplay>().CurrentScores();

    public void LoadLevelOne()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level 1");
        
    }

    public void LoadLevelTwo()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level 2");

    }

    public void LoadLevelThree()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level 3");

    }

    public void LoadLevelFour()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level 4");

    }

    public void LoadLevelFive()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level 5");

    }

}
