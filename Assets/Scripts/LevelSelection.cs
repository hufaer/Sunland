using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private bool isUnlocked;
    [SerializeField] private GameObject[] stars;
    [SerializeField] private Button button;

    private void Update()
    {
        UpdateLevelButton();
        UpdateLevelStats();
        if (isUnlocked)
        {
            UpdateStars();
        }
    }

    private void UpdateLevelButton()
    {
        var buttonColors = button.colors;
        if (!isUnlocked)
        {
            button.interactable = false;
            foreach (GameObject star in stars)
            {
                star.gameObject.SetActive(false);
            }
        } else
        {
            button.interactable = true;
            foreach (GameObject star in stars)
            {
                star.gameObject.SetActive(true);
            }
        }
        button.colors = buttonColors;
    }

    public void LoadSelectedScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    private void UpdateLevelStats()
    {
        int previousLevelIndex = int.Parse(gameObject.name.Replace("Level", "")) - 1;
        if (PlayerPrefs.GetInt("Level" + previousLevelIndex) > 0)
        {
            isUnlocked = true;
        }
    }

    private void UpdateStars()
    {
        int previousLevelIndex = int.Parse(gameObject.name.Replace("Level", ""));
        int starsCount = PlayerPrefs.GetInt("Level" + previousLevelIndex);
        if (starsCount >= 1)
        {
            stars[0].GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
        if (starsCount >= 2)
        {
            stars[1].GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
        if (starsCount >= 3)
        {
            stars[2].GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
