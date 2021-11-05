using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColdSpecial : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float newSpeed;
    private float initialSpeed;

    private void Start()
    {
        initialSpeed = player.GetComponent<EnnerControl>().speed;
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enner") && !other.isTrigger)
        {
            player.GetComponent<EnnerControl>().speed = newSpeed;
        }
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enner") && !other.isTrigger)
        {
            player.GetComponent<EnnerControl>().speed = initialSpeed;
        }
    }
}
