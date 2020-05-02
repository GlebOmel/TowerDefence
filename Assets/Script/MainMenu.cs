using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public static int Score=0;
    public Text Scoretxt;
    public void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex==0)
        Scoretxt.text = "Your score: "+Score.ToString();
    }
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
