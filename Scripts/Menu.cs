using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string levelToLoad;

    public GameObject settingsWindow;

    // Start is called before the first frame update
    public void StartGame()
    {
      SceneManager.LoadScene(levelToLoad);
    }

    public void SettingsButton()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
