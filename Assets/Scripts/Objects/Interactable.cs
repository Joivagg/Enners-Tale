using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Signals context;
    public bool playerInRange;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enner") && !other.isTrigger)
        {
            context.Raise();
            playerInRange = true;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enner") && !other.isTrigger)
        {
            context.Raise();
            playerInRange = false;
        }
    }
}
