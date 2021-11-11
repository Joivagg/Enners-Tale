using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogInteract : Interactable
{
    public GameObject dialogBox;
    public GameObject uiPanel;
    public Text dialogText;
    public string dialog;
    public GameObject container;

    public virtual void Update()
    {
        if (Input.GetButtonDown("interact") && playerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                uiPanel.SetActive(true);
                container.GetComponent<PauseMenu>().enabled = true;
                Time.timeScale = 1f;
            }
            else
            {
                dialogBox.SetActive(true);
                uiPanel.SetActive(false);
                dialogText.text = dialog;
                container.GetComponent<PauseMenu>().enabled = false;
                Time.timeScale = 0f;
            }
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enner") && !other.isTrigger)
        {
            base.OnTriggerExit2D(other);
        }
    }

    public void InteracButton()
    {
        if (playerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                uiPanel.SetActive(true);
                container.GetComponent<PauseMenu>().enabled = true;
                Time.timeScale = 1f;
            }
            else
            {
                dialogBox.SetActive(true);
                uiPanel.SetActive(false);
                container.GetComponent<PauseMenu>().enabled = false;
                dialogText.text = dialog;
                Time.timeScale = 0f;
            }
        }
    }

    public virtual void InteractButton()
    {
        if (playerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                uiPanel.SetActive(true);
                container.GetComponent<PauseMenu>().enabled = true;
                Time.timeScale = 1f;
            }
            else
            {
                dialogBox.SetActive(true);
                uiPanel.SetActive(false);
                container.GetComponent<PauseMenu>().enabled = false;
                dialogText.text = dialog;
                Time.timeScale = 0f;
            }
        }
    }
}
