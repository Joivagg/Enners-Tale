using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public Vector2 directionToMove;
    
    [Header("Lifetime")]
    public float lifetime;
    private float lifetimeSeconds;
    private Animator anim;
    public Rigidbody2D myRigidbody;
    private Vector2 setVector;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        lifetimeSeconds = lifetime;
        
    }

    // Update is called once per frame
    void Update()
    {
        lifetimeSeconds -= Time.deltaTime;
        if(lifetimeSeconds <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void Launch(Vector2 initialVel)
    {
        myRigidbody.velocity = initialVel * moveSpeed;
        float angle = Mathf.Atan2(myRigidbody.velocity.y, myRigidbody.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.isTrigger)
        {
            Destroy(this.gameObject);
        }
    }
}
