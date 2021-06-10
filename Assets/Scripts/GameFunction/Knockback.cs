using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
    public float knockTime;
    public FloatValue damageNumber;
    private float damage;

    private void Awake()
    {
        damage = damageNumber.initialValue;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("breakable") && this.gameObject.CompareTag("Enner"))
        {
            other.GetComponent<Pot>().Smash();
        }
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Enner"))
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if(hit != null)
            {
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);
                if (other.gameObject.CompareTag("Enemy") && other.isTrigger)
                {
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    other.GetComponent<Enemy>().Knock(hit, knockTime, damage);
                }
                if (other.gameObject.CompareTag("Enner"))
                {
                    if(other.GetComponent<EnnerControl>().currentState != PlayerState.stagger)
                    {
                        hit.GetComponent<EnnerControl>().currentState = PlayerState.stagger;
                        other.GetComponent<EnnerControl>().Knock(knockTime, damage);
                    }
                    
                }
            }
        }
    }
}
