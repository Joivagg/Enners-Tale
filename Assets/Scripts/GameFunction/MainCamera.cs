using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperTiled2Unity;

public class MainCamera : MonoBehaviour
{
    [Header("Position Variables")]
    public Transform target;
    public float smoothing;
    public Vector2 maxPosition;
    public Vector2 minPosition;

    [Header("Animator")]
    public Animator anim;

    [Header("Position Reset")]
    public VectorValue camMin;
    public VectorValue camMax;

    void Start()
    {
        maxPosition = camMax.initialValue;
        minPosition = camMin.initialValue;
        anim = GetComponent<Animator>();
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
    void LateUpdate()
    {
        if (transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x,
                                                 target.position.y,
                                                 transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x,
                                           minPosition.x,
                                           maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y,
                                           minPosition.y,
                                           maxPosition.y);
            transform.position = Vector3.Lerp(
                transform.position,
                targetPosition,
                smoothing
            );
        }
    }
    /*private void LateUpdate()
    {
        if(transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x,
                                                 target.position.y,
                                                 transform.position.z);
            transform.position = Vector3.Lerp(transform.position,
                                              targetPosition,
                                              smoothing);
        }
    }*/

    public void BeginKick()
    {
        anim.SetBool("kickActive", true);
        StartCoroutine(KickCO());
    }

    public IEnumerator KickCO()
    {
        yield return null;
        anim.SetBool("kickActive", false);
    }
}
