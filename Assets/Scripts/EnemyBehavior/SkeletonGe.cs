using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonGe : Enemy
{
    public Rigidbody2D myRigidbody;
    public Collider2D boundary;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Enner").transform;
        //anim.SetBool("wakeUp", true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
    }

    protected virtual void CheckDistance()
    {
        float targetDistance = Vector3.Distance(target.position, transform.position);
        if (targetDistance <= chaseRadius && targetDistance > attackRadius && boundary.bounds.Contains(target.transform.position))
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                ChangeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
                //ChangeState(EnemyState.walk);
                //anim.SetBool("wakeUp", true);
            }
        }
        /*else if (targetDistance > chaseRadius)
        {
            anim.SetBool("wakeUp", false);
        }*/
    }

    private void SetAnimFLoat(Vector2 setVector)
    {
        anim.SetFloat("movX", setVector.x);
        anim.SetFloat("movY", setVector.y);
    }

    public void ChangeAnim(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                SetAnimFLoat(Vector2.right);
            }
            else if (direction.x < 0)
            {
                SetAnimFLoat(Vector2.left);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimFLoat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimFLoat(Vector2.down);
            }
        }
    }

    private void ChangeState(EnemyState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
    }
}
