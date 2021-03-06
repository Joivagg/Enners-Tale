using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DoorType2
{
    key,
    enemy,
    button
}

public class CaveDoor : Interactable
{
    [Header("Door Variables")]
    public DoorType2 thisDoorType;
    public bool open = false;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;
    public GameObject KeySprite;
    public GameObject Cloud;

    public void Update()
    {
        if (Input.GetButtonDown("interact"))
        {
            if (playerInRange && thisDoorType == DoorType2.key)
            {
                // Does the player have a key?
                if (playerInventory.numberOfKeys2 > 0)
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
        KeySprite.SetActive(false);
        Cloud.SetActive(false);
    }

    public void Close()
    {

    }

    public void OpenDoor()
    {
        if (playerInRange && thisDoorType == DoorType2.key)
        {
            // Does the player have a key?
            if (playerInventory.numberOfKeys2 > 0)
            {
                // Remove a player key
                // playerInventory.numberOfKeys--;
                // If so, then call the open method
                Open();
            }
        }
    }
}

