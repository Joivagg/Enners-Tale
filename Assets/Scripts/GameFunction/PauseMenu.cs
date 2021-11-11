using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused;
    public GameObject pausePanel;
    public GameObject uiPanel;
    public string mainMenu;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("pause"))
        {
            ChangePause();
        }
    }

    public void ChangePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pausePanel.SetActive(true);
            uiPanel.SetActive(false);
            Time.timeScale = 0f;
        }
        else
        {
            pausePanel.SetActive(false);
            uiPanel.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    public void RetryLevel()
    {
        player.GetComponent<EnnerControl>().currentHealth.RuntimeValue = player.GetComponent<EnnerControl>().currentHealth.initialValue;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void QuitToMain()
    {
        player.GetComponent<EnnerControl>().currentHealth.RuntimeValue = player.GetComponent<EnnerControl>().currentHealth.initialValue;
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }
}
