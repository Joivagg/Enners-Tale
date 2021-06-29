using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Powerup
{
    public FloatValue playerHealth;
    public FloatValue heartContainers;
    public float amountToIncrease;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enner") && !other.isTrigger)
        {
            playerHealth.RuntimeValue += amountToIncrease;
            if(playerHealth.RuntimeValue > heartContainers.RuntimeValue * 4f)
            {
                playerHealth.RuntimeValue = playerHealth.initialValue;
                heartContainers.RuntimeValue = heartContainers.initialValue;
                // playerHealth.initialValue = heartContainers.RuntimeValue * 4f;
            }
            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}
