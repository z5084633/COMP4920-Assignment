using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject MainButtons;
    public GameObject OptionPanel;

    private void Start()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        MainButtons.SetActive(true);
        OptionPanel.SetActive(false);
    }

    public void Option()
    {
        MainButtons.SetActive(false);
        OptionPanel.SetActive(true);
    }
    public void OptionBack() {

        MainButtons.SetActive(true);
        OptionPanel.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
