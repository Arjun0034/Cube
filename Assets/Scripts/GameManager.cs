using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{

    private Coin Coin;

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quitted");
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Level");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }

    public void NextLevel()
    {
        if(Coin.coins == 14)
        {
            Debug.Log("Reached next level");
        }
    }

    
}
