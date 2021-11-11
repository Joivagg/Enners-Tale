using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Warp : MonoBehaviour
{
    public GameObject target;

    void Awake()
    {
        Assert.IsNotNull(target);
        GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Enner") && !other.isTrigger)
        {
            other.transform.position = target.transform.GetChild(0).transform.position;
        }
    }
}