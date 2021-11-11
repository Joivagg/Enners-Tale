using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    private Animator anim;
    [SerializeField]
    private AudioClip breakSound;
    private AudioSource potSound;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        potSound = GetComponent<AudioSource>();
        if (potSound == null)
        {
            Debug.LogError("The AudioSource in the player is NULL!");
        }
        else
        {
            potSound.clip = breakSound;
        }
    }

    public void Smash()
    {
        anim.SetBool("smash", true);
        potSound.Play();
        StartCoroutine(BreakCo());
        
    }

    IEnumerator BreakCo()
    {
        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);
    }
}
