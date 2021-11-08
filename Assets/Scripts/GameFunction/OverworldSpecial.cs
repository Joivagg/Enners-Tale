using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldSpecial : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enner") && !other.isTrigger)
        {
            player.GetComponent<Transform>().localScale = new Vector3(0.8f, 0.8f, 1);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enner") && !other.isTrigger)
        {
            player.GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        }
    }
}
