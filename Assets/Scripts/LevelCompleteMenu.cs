using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompleteMenu : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Hero hero;
    [SerializeField] private GameObject image1;
    [SerializeField] private GameObject image2;
    [SerializeField] private GameObject image3;
    [SerializeField] private Button nextLevelButton;
    public static bool isLevelComplete = false;


    void Update()
    {
        if (isLevelComplete)
        {
            panel.SetActive(true);
            Time.timeScale = 0f;
            hero.enabled = false;
            AudioListener.pause = true;

            if (hero.starsCount >= 1)
            {
                image1.GetComponent<Image>().color = new Color(255, 255, 255, 255);
                if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
                {
                    nextLevelButton.interactable = true;
                }
            }
            if (hero.starsCount >= 2)
            {
                image2.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            }
            if (hero.starsCount >= 3)
            {
                image3.GetComponent<Image>().color = new Color(255, 255, 255, 255);
            }

            if (hero.starsCount > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name))
            {
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, hero.starsCount);
            }
        } 
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        isLevelComplete = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        isLevelComplete = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
