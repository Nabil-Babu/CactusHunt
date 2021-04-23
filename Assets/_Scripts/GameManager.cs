using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    public bool GamePaused = false; 
    
    
    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame || Keyboard.current.pKey.wasPressedThisFrame)
        {
            if (Time.timeScale > 0)
            {
                Time.timeScale = 0;
                GamePaused = true;
            }
            else
            {
                Time.timeScale = 1;
                GamePaused = false;
            }
            HUDHandler.instance.PauseMenu.SetActive(!HUDHandler.instance.PauseMenu.activeInHierarchy);
        }
    }


    public void GameWon()
    {
        HUDHandler.instance.Victory.gameObject.SetActive(true);
        MainMenu();
    }
    
    public void GameLost()
    {
        HUDHandler.instance.GameOver.gameObject.SetActive(true);
        MainMenu();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        StartCoroutine(GoToMenu());
    }

    public void MainMenuInstant()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator GoToMenu()
    {
        yield return new WaitForSeconds(5.0f);
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
