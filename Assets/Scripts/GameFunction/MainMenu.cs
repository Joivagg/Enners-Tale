using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Inventory playerInventory;
    [SerializeField]
    private Achievements playerAchievements;
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject finalMessage;
    [SerializeField]
    private GameObject selectDifficulty;
    [SerializeField]
    private GameObject levelOne;
    [SerializeField]
    private GameObject levelTwo;
    [SerializeField]
    private GameObject levelThree;
    [SerializeField]
    private GameObject levelFour;
    [SerializeField]
    private GameObject viewControls;
    [SerializeField]
    private GameObject viewCredits;

    public void NewGame()
    {
        mainMenu.SetActive(false);
        if(playerAchievements.englishLevel1 &&
           playerAchievements.englishLevel2 &&
           playerAchievements.englishLevel3 &&
           playerAchievements.englishLevel4)
        {
            finalMessage.SetActive(true);
        }
        else
        {
            selectDifficulty.SetActive(true);
            if(playerAchievements.englishLevel1)
            {
                levelOne.GetComponent<Button>().interactable = false;
            }
            else
            {
                levelOne.GetComponent<Button>().interactable = true;
            }
            if (playerAchievements.englishLevel2)
            {
                levelTwo.GetComponent<Button>().interactable = false;
            }
            else
            {
                levelTwo.GetComponent<Button>().interactable = true;
            }
            if (playerAchievements.englishLevel3)
            {
                levelThree.GetComponent<Button>().interactable = false;
            }
            else
            {
                levelThree.GetComponent<Button>().interactable = true;
            }
            if (playerAchievements.englishLevel4)
            {
                levelFour.GetComponent<Button>().interactable = false;
            }
            else
            {
                levelFour.GetComponent<Button>().interactable = true;
            }
        }
    }

    public void Level1()
    {
        playerInventory.coins = 0;
        playerInventory.numberOfKeys = 0;
        playerInventory.numberOfKeys2 = 0;
        playerInventory.achievements = 0;
        playerAchievements.checkAcademyApproval = false;
        playerAchievements.checkWaterSeal = false;
        playerAchievements.checkFireSeal = false;
        playerAchievements.checkPoisonSeal = false;
        playerAchievements.checkCastleMedal = false;
        SceneManager.LoadScene("OverworldL1");
    }

    public void Level2()
    {
        playerInventory.coins = 0;
        playerInventory.numberOfKeys = 0;
        playerInventory.numberOfKeys2 = 0;
        playerInventory.achievements = 0;
        playerAchievements.checkAcademyApproval = false;
        playerAchievements.checkWaterSeal = false;
        playerAchievements.checkFireSeal = false;
        playerAchievements.checkPoisonSeal = false;
        playerAchievements.checkCastleMedal = false;
        SceneManager.LoadScene("OverworldL2");
    }

    public void Level3()
    {
        playerInventory.coins = 0;
        playerInventory.numberOfKeys = 0;
        playerInventory.numberOfKeys2 = 0;
        playerInventory.achievements = 0;
        playerAchievements.checkAcademyApproval = false;
        playerAchievements.checkWaterSeal = false;
        playerAchievements.checkFireSeal = false;
        playerAchievements.checkPoisonSeal = false;
        playerAchievements.checkCastleMedal = false;
        SceneManager.LoadScene("OverworldL3");
    }

    public void Level4()
    {
        playerInventory.coins = 0;
        playerInventory.numberOfKeys = 0;
        playerInventory.numberOfKeys2 = 0;
        playerInventory.achievements = 0;
        playerAchievements.checkAcademyApproval = false;
        playerAchievements.checkWaterSeal = false;
        playerAchievements.checkFireSeal = false;
        playerAchievements.checkPoisonSeal = false;
        playerAchievements.checkCastleMedal = false;
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
