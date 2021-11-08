using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class Warp : MonoBehaviour
{
    public GameObject target;
    public Vector2 cameraChangeMin;
    public Vector2 cameraChangeMax;
    private MainCamera cambound;
    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;
    [Header("Transition Variables")]
    public GameObject fadeInPanel;
    public GameObject fadeOutPanel;
    public float fadeWait;

    private void Start()
    {
        cambound = Camera.main.GetComponent<MainCamera>();
    }

    void Awake()
    {
        Assert.IsNotNull(target);
        GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Enner") && !other.isTrigger)
        {
            other.transform.position = target.transform.GetChild(0).transform.position;
            cambound.minPosition += cameraChangeMin;
            cambound.maxPosition += cameraChangeMax;

            if (needText)
            {
                StartCoroutine(PlaceNameCo());
            }
        }
    }

    private IEnumerator PlaceNameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        placeText.CrossFadeAlpha(0, 3f, false);
        yield return new WaitForSeconds(3.5f);
        text.SetActive(false);
    }
}
