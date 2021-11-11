using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryWindow : MonoBehaviour
{
    public GameObject retryPanel;
    public string mainMenu;
    public GameObject player;
    public GameObject container;

    public void RetryLevel()
    {
        player.GetComponent<EnnerControl>().currentHealth.RuntimeValue = player.GetComponent<EnnerControl>().currentHealth.initialValue;
        container.GetComponent<PauseMenu>().enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void QuitToMain()
    {
        player.GetComponent<EnnerControl>().currentHealth.RuntimeValue = player.GetComponent<EnnerControl>().currentHealth.initialValue;
        container.GetComponent<PauseMenu>().enabled = true;
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }
}
