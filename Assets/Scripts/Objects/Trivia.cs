using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trivia : Interactable
{
    public GameObject Interfaz;
    public GameObject QuestionPanel;
    public GameObject MainCharacter;
    public Text Pregunta;
    public string dialog;
    public Text Opcion1;
    public string dialogop1;
    public Text Opcion2;
    public string dialogop2;
    public Text Opcion3;
    public string dialogop3;
    public Text Opcion4;
    public string dialogop4;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;
    private bool isActive;
    public FloatValue currentHealth;
    public Signals playerHealthSignal;

    void Start()
    {
        isActive = true;
    }

    public virtual void Update()
    {
        if (Input.GetButtonDown("interact") && playerInRange)
        {
            if (Interfaz.activeInHierarchy)
            {
                Interfaz.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                Interfaz.SetActive(true);
                Pregunta.text = dialog;
                Opcion1.text = dialogop1;
                Opcion2.text = dialogop2;
                Opcion3.text = dialogop3;
                Opcion4.text = dialogop4;
                Time.timeScale = 0f;
            }
        }
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enner") && !other.isTrigger)
        {
            base.OnTriggerExit2D(other);
            Interfaz.SetActive(false);
        }
    }

    public void InteracButton()
    {
        if (playerInRange)
        {
            if (Interfaz.activeInHierarchy)
            {
                Interfaz.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                Interfaz.SetActive(true);
                Pregunta.text = dialog;
                Opcion1.text = dialogop1;
                Opcion2.text = dialogop2;
                Opcion3.text = dialogop3;
                Opcion4.text = dialogop4;
                Time.timeScale = 0f;
            }
        }
    }

    public virtual void InteractButton()
    {
        if (playerInRange)
        {
            if (Interfaz.activeInHierarchy)
            {
                Interfaz.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                Interfaz.SetActive(true);
                Pregunta.text = dialog;
                Opcion1.text = dialogop1;
                Opcion2.text = dialogop2;
                Opcion3.text = dialogop3;
                Opcion4.text = dialogop4;
                Time.timeScale = 0f;
            }
        }
    }
    public void Open()
    {
        // Turn off the door's sprite renderer
        doorSprite.enabled = false;
        // Turn off the door's box collider
        physicsCollider.enabled = false;
        this.gameObject.SetActive(false);
    }

    public void ChangePanel()
    {
        isActive = !isActive;
        if (isActive)
        {
            Interfaz.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            Interfaz.SetActive(false);
            Time.timeScale = 1f;
            isActive = true;
        }
    }

    public void TriviaDamage()
    {
        currentHealth.RuntimeValue -= 1;
        playerHealthSignal.Raise();
        if (currentHealth.RuntimeValue == 0)
        {
            MainCharacter.SetActive(false);
        }
    }
}