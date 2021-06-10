using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyTextManager : Powerup
{
    public Inventory playerInventory;
    public TextMeshProUGUI keyDisplay;

    public void UpdateKeyCount()
    {
        powerUpSignal.Raise();
        keyDisplay.text = "" + playerInventory.numberOfKeys;
    }
}
