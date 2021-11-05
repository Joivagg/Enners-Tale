using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Skeleton
{
    public GameObject projectile;
    public float fireDelay;
    private float fireDelaySeconds;
    public bool canFire = true;

    private void Update()
    {
        fireDelaySeconds -= Time.deltaTime;
        if(fireDelaySeconds <= 0)
        {
            canFire = true;
            fireDelaySeconds = fireDelay;
        }
    }

    protected override void CheckDistance()
    {
        float targetDistance = Vector3.Distance(target.position, transform.position);
        if (boundary.bounds.Contains(target.transform.position))
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                anim.SetBool("wakeUp", true);
                Vector3 temp = target.transform.position - transform.position;
                ChangeAnim(temp);
                if (canFire)
                {
                    GameObject current = Instantiate(projectile, transform.position, Quaternion.identity);
                    current.GetComponent<Projectile>().Launch(temp);
                    canFire = false;
                }
            }
        }
        else if (targetDistance > chaseRadius)
        {
            anim.SetBool("wakeUp", false);
        }
    }
}