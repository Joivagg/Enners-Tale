using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trivia : Interactable
{
    
    [Header("Text Content")]
    public string dialog;
    public string dialogop1;
    public string dialogop2;
    public string dialogop3;
    public string dialogop4;

    [Header("UI Elements")]
    public GameObject Interfaz;
    public GameObject QuestionPanel;
    public GameObject MainCharacter;

    [Header("Text Fields")]
    public Text Pregunta;
    public Text Opcion1;
    public Text Opcion2;
    public Text Opcion3;
    public Text Opcion4;

    [Header("Door Properties")]
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;
    private bool isActive;

    [Header("Player Health")]
    public FloatValue currentHealth;
    public Signals playerHealthSignal;

    public bool checkPlateActivation;
    public BoolValue storedValue;
    public Sprite activeSprite;
    private SpriteRenderer plateSprite;
    public Door targetDoor;

    public Button buttonOne;

    void Start()
    {
        
        plateSprite = GetComponent<SpriteRenderer>();
        checkPlateActivation = storedValue.RuntimeValue;
        if (checkPlateActivation)
        {
            ActivatePlate();
        }
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

    public void ActivatePlate()
    {
        checkPlateActivation = true;
        storedValue.RuntimeValue = checkPlateActivation;
        targetDoor.Open();
        plateSprite.sprite = activeSprite;
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        // Is it the Player?
        if (other.CompareTag("Enner") && !other.isTrigger)
        {
            Interfaz.SetActive(true);
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