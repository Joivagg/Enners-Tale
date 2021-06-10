using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    [Header("Contents")]
    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public BoolValue storedOpen;

    [Header("Signals and Dialog")]
    public Signals raiseItem;
    public GameObject dialogBox;
    public Text dialogText;

    [Header("Animation")]
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        isOpen = storedOpen.RuntimeValue;
        if (isOpen)
        {
            anim.SetBool("opened", true);
        }
    }
    
    public void Update()
    {
        if (Input.GetButtonDown("interact") && playerInRange)
        {
            if (!isOpen)
            {
                // Open the chest
                OpenChest();
            }
            else
            {
                // Chest already open
                ChestAlreadyOpen();
            }
        }
    }

    public void OpenChest()
    {
        // Dialog window on
        dialogBox.SetActive(true);
        // dialog text = contents text
        dialogText.text = contents.itemDescription;
        // Add contents to the inventory
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        // Set the chest to opened
        isOpen = true;
        // Raise the signal to the player to animate
        raiseItem.Raise();
        // Raise the context clue
        context.Raise();
        anim.SetBool("opened", true);
        storedOpen.RuntimeValue = isOpen;
    }

    public void ChestAlreadyOpen()
    {
        // Dialog off
        dialogBox.SetActive(false);
        // Raise the signal to the player to stop animating
        raiseItem.Raise();
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enner") && !other.isTrigger && !isOpen)
        {
            base.OnTriggerEnter2D(other);
        }
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enner") && !other.isTrigger && !isOpen)
        {
            base.OnTriggerExit2D(other);
        }
    }

    public void InteractButton()
    {
        if (playerInRange)
        {
            if (!isOpen)
            {
                // Open the chest
                OpenChest();
            }
            else
            {
                // Chest already open
                ChestAlreadyOpen();
            }
        }
    }
}
