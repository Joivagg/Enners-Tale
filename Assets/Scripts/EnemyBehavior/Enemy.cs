using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}
public class Enemy : MonoBehaviour
{
    [Header("State Machine")]
    public EnemyState currentState;

    [Header("Enemy Stats")]
    public FloatValue maxHealth;
    private float health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    protected Vector2 homePosition;

    [Header("Death Effects")]
    public GameObject deathEffect;
    private float deathEffectDelay = 1f;

    [Header("Death Signals")]
    public Signals roomSignal;

    [Header("Sound Config")]
    [SerializeField]
    protected AudioClip enemySound;
    protected AudioSource soundSource;

    private void Awake()
    {
        health = maxHealth.initialValue;
        homePosition = transform.position;
        soundSource = GetComponent<AudioSource>();
        if (soundSource == null)
        {
            Debug.LogError("The AudioSource in the player is NULL!");
        }
        else
        {
            soundSource.clip = enemySound;
        }
    }

    protected virtual void OnEnable()
    {
        transform.position = homePosition;
        health = maxHealth.initialValue;
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            DeathEffect();
            roomSignal.Raise();
            this.gameObject.SetActive(false);
        }
    }

    private void DeathEffect()
    {
        if(deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(effect, deathEffectDelay);
        }
    }

    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage)
    {
        StartCoroutine(KnockCO(myRigidbody, knockTime));
        soundSource.Play();
        TakeDamage(damage);
    }
    private IEnumerator KnockCO(Rigidbody2D myRigidbody, float knockTime)
    {
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }
}
