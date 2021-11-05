using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogInteract : Interactable
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    
    void Start()
    {
        
    }

    public virtual void Update()
    {
        if (Input.GetButtonDown("interact") && playerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
                Time.timeScale = 0f;
            }
        }
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enner") && !other.isTrigger)
        {
            base.OnTriggerExit2D(other);
            dialogBox.SetActive(false);
        }
    }

    public void InteracButton()
    {
        if (playerInRange)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                dialogBox.SetActive(true);
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
                Time.timeScale = 1f;
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
                Time.timeScale = 0f;
            }
        }
    }
}
