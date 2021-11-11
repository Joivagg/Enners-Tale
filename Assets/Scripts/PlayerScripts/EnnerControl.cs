using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerState
{
    walk,
    attack,
    interact,
    stagger,
    idle
}
public class EnnerControl : MonoBehaviour
{
    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    public FloatValue currentHealth;
    public FloatValue initialHealth;
    public Signals playerHealthSignal;
    public VectorValue startingPosition;
    public Inventory playerInventory;
    public Achievements playerAccess;
    public SpriteRenderer receivedItemSprite;
    public Signals playerHit;
    public Joystick joystick;
    [SerializeField]
    private AudioClip swordSound;
    private AudioSource attackSound;
    public float runSpeedVertical = 0;
    public float runSpeedHorizontal = 0;
    public GameObject retryPanel;
    public GameObject uiPanel;
    public GameObject container;

    private void Start()
    {
        currentState = PlayerState.walk;
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        animator.SetFloat("movX", 0);
        animator.SetFloat("movY", -1);
        transform.position = startingPosition.initialValue;
        currentHealth = initialHealth;
        attackSound = GetComponent<AudioSource>();
        if (attackSound == null)
        {
            Debug.LogError("The AudioSource in the player is NULL!");
        }
        else
        {
            attackSound.clip = swordSound;
        }
    }

    private void Update()
    {
        // Is the player in an interaction?
        if(currentState == PlayerState.interact)
        {
            return;
        }
        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCO());
        }
    }

    private void FixedUpdate()
    {
        change = Vector3.zero;
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            change.x = joystick.Horizontal * runSpeedHorizontal;
            change.y = joystick.Vertical * runSpeedVertical;
            if (currentState == PlayerState.walk || currentState == PlayerState.idle)
            {
                UpdateAnimationAndMove();
            }
        }
        else
        {
            change.x = Input.GetAxisRaw("Horizontal");
            change.y = Input.GetAxisRaw("Vertical");
            if (currentState == PlayerState.walk || currentState == PlayerState.idle)
            {
                UpdateAnimationAndMove();
            }
        }
    }

    private IEnumerator AttackCO()
    {
        animator.SetBool("attacking", true);
        attackSound.Play();
        currentState = PlayerState.attack;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.24f);
        if(currentState != PlayerState.interact)
        {
            currentState = PlayerState.walk;
        }
    }

    public void RaiseItem()
    {
        if(playerInventory.currentItem != null)
        {
            if (currentState != PlayerState.interact)
            {
                animator.SetBool("receiving", true);
                currentState = PlayerState.interact;
                receivedItemSprite.sprite = playerInventory.currentItem.itemSprite;
            }
            else
            {
                animator.SetBool("receiving", false);
                currentState = PlayerState.idle;
                receivedItemSprite.sprite = null;
                playerInventory.currentItem = null;
            }
        }
        
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            change.x = Mathf.Round(change.x);
            change.y = Mathf.Round(change.y);
            animator.SetFloat("movX", change.x);
            animator.SetFloat("movY", change.y);
            animator.SetBool("walking", true);

        }
        else
        {
            animator.SetBool("walking", false);
        }
    }

    void MoveCharacter()
    {
        change.Normalize();
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime
        );
    }

    public void Knock(float knockTIme, float damage)
    {
        currentHealth.RuntimeValue -= damage;
        playerHealthSignal.Raise();
        if (currentHealth.RuntimeValue > 0)
        {
            StartCoroutine(KnockCO(knockTIme));
        }
        else
        {
            this.gameObject.SetActive(false);
            retryPanel.SetActive(true);
            uiPanel.SetActive(true);
            container.GetComponent<PauseMenu>().enabled = false;
            Time.timeScale = 0;
        }
    }

    private IEnumerator KnockCO(float knockTime)
    {
        playerHit.Raise();
        if (myRigidbody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidbody.velocity = Vector2.zero;
            currentState = PlayerState.idle;
            myRigidbody.velocity = Vector2.zero;
        }
    }

    public void AttackButton()
    {
        StartCoroutine(AttackCO());
    }

    public void InteractButton()
    {

    }
    /*public float speed = 4f;
    Animator anim;
    Rigidbody2D rb2d;
    Vector2 mov;    // Ahora es visible entre los métodos

    // Start is called before the first frame update
    void Start ()
    {
        currentState = PlayerState.walk;
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update ()
    {
        mov = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );
        if (currentState == PlayerState.walk)
        {
            if (mov != Vector2.zero)
            {
                FixedUpdate();
                anim.SetFloat("movX", mov.x);
                anim.SetFloat("movY", mov.y);
                anim.SetBool("walking", true);
            }
            else
            {
                anim.SetBool("walking", false);
        }
    }

    IEnumerator AttackCO()
    {
        anim.SetBool("attacking", true);
        currentState = PlayerState.attack;
        yield return null;
        anim.SetBool("attacking", false);
        yield return new WaitForSeconds(.2f);
        currentState = PlayerState.walk;
    }
    void FixedUpdate ()
    {
        rb2d.MovePosition(rb2d.position + mov * speed * Time.deltaTime);
    }*/
}
