using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Levels
{
    levelOne,
    levelTwo,
    levelThree,
    levelFour
}

public class DialogInteractQueen : DialogInteract
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Levels actualLevel;
    public override void Update()
    {
        if (Input.GetButtonDown("interact") && playerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                Time.timeScale = 1f;
                if(player.GetComponent<EnnerControl>().playerAccess.checkCastleMedal)
                {
                    if(actualLevel == Levels.levelOne)
                    {
                        player.GetComponent<EnnerControl>().playerAccess.englishLevel1 = true;
                    }
                    if (actualLevel == Levels.levelTwo)
                    {
                        player.GetComponent<EnnerControl>().playerAccess.englishLevel2 = true;
                    }
                    if (actualLevel == Levels.levelThree)
                    {
                        player.GetComponent<EnnerControl>().playerAccess.englishLevel3 = true;
                    }
                    if (actualLevel == Levels.levelFour)
                    {
                        player.GetComponent<EnnerControl>().playerAccess.englishLevel4 = true;
                    }
                    SceneManager.LoadScene("TitleScreen");
                }
                else
                {
                    dialogBox.SetActive(false);
                }
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
                Time.timeScale = 0f;
            }
        }
    }

    public override void InteractButton()
    {
        base.InteractButton();
    }
}
