using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Inventory playerInventory;
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject selectDifficulty;
    [SerializeField]
    private GameObject viewControls;
    [SerializeField]
    private GameObject viewCredits;

    public void NewGame()
    {
        mainMenu.SetActive(false);
        selectDifficulty.SetActive(true);
    }

    public void Level1()
    {
        playerInventory.coins = 0;
        playerInventory.numberOfKeys = 0;
        playerInventory.numberOfKeys2 = 0;
        playerInventory.achievements = 0;
        SceneManager.LoadScene("OverworldL1");
    }

    public void Level2()
    {
        playerInventory.coins = 0;
        playerInventory.numberOfKeys = 0;
        playerInventory.numberOfKeys2 = 0;
        playerInventory.achievements = 0;
        SceneManager.LoadScene("OverworldL2");
    }

    public void Level3()
    {
        playerInventory.coins = 0;
        playerInventory.numberOfKeys = 0;
        playerInventory.numberOfKeys2 = 0;
        playerInventory.achievements = 0;
        SceneManager.LoadScene("OverworldL3");
    }

    public void Level4()
    {
        playerInventory.coins = 0;
        playerInventory.numberOfKeys = 0;
        playerInventory.numberOfKeys2 = 0;
        playerInventory.achievements = 0;
        SceneManager.LoadScene("OverworldL4");
    }

    public void ShowControls()
    {
        mainMenu.SetActive(false);
        viewControls.SetActive(true);
    }

    public void ShowCredits()
    {
        mainMenu.SetActive(false);
        viewCredits.SetActive(true);
    }

    public void Return()
    {
        selectDifficulty.SetActive(false);
        viewControls.SetActive(false);
        viewCredits.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
