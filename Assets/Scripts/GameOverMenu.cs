using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private Hero player;
    [SerializeField] private GameObject panel;
    public static bool gameIsOver = false;

    void Update()
    {
        if (gameIsOver)
        {
            panel.SetActive(true);

            Time.timeScale = 0f;
            player.enabled = false;
            AudioListener.pause = true;
        }
    }

    public void MainMenuButton()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene("MainMenu");
        gameIsOver = false;
    }

    public void RestartButton()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameIsOver = false;
    }
}
