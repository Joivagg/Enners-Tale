using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType
{
    key,
    enemy,
    button
}

public class Door : Interactable
{
    [Header("Door Variables")]
    public DoorType thisDoorType;
    public bool open = false;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;

    public void Update()
    {
        if (Input.GetButtonDown("interact"))
        {
            if (playerInRange && thisDoorType == DoorType.key)
            {
                // Does the player have a key?
                if(playerInventory.numberOfKeys > 0)
                {
                    // Remove a player key
                    // playerInventory.numberOfKeys--;
                    // If so, then call the open method
                    Open();
                }
            }
        }
    }

    public void Open()
    {
        // Turn off the door's sprite renderer
        doorSprite.enabled = false;
        // Set open to true
        open = true;
        // Turn off the door's box collider
        physicsCollider.enabled = false;
        this.gameObject.SetActive(false);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enner") && !other.isTrigger && thisDoorType == DoorType.key)
        {
            context.Raise();
            playerInRange = true;
        }
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enner") && !other.isTrigger && thisDoorType == DoorType.key)
        {
            context.Raise();
            playerInRange = false;
        }
    }

    public void Close()
    {
        // Turn off the door's sprite renderer
        doorSprite.enabled = true;
        // Set open to true
        open = false;
        // Turn off the door's box collider
        physicsCollider.enabled = true;
        this.gameObject.SetActive(true);
    }

    public void OpenDoor()
    {
        if (playerInRange && thisDoorType == DoorType.key)
        {
            // Does the player have a key?
            if (playerInventory.numberOfKeys > 0)
            {
                // Remove a player key
                // playerInventory.numberOfKeys--;
                // If so, then call the open method
                Open();
            }
        }
    }
}
