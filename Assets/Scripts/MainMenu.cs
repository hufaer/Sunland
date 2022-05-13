using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void onExitButtonClick()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void onStartButtonClick()
    {
        PlayerPrefs.DeleteKey("Level1");
        PlayerPrefs.DeleteKey("Level2");
        PlayerPrefs.DeleteKey("Level3");
        PlayerPrefs.DeleteKey("Level4");
        PlayerPrefs.DeleteKey("Level5");
        SceneManager.LoadScene("LevelMenu");
    }

    public void onLevelsButtonClick()
    {
        SceneManager.LoadScene("LevelMenu");
    }
}
