using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenTown : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject heroDialog;
    [SerializeField]
    private string firstText;
    [SerializeField]
    private string secondText;
    [SerializeField]
    private string finalText;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        if (player.GetComponent<EnnerControl>().playerAccess.checkAcademyApproval &&
            player.GetComponent<EnnerControl>().playerAccess.checkWaterSeal &&
            player.GetComponent<EnnerControl>().playerAccess.checkFireSeal &&
            player.GetComponent<EnnerControl>().playerAccess.checkPoisonSeal &&
            player.GetComponent<EnnerControl>().playerAccess.checkCastleMedal)
        {
            heroDialog.GetComponent<DialogInteract>().dialog = finalText;
        }
        else if (player.GetComponent<EnnerControl>().playerAccess.checkAcademyApproval &&
                 player.GetComponent<EnnerControl>().playerAccess.checkWaterSeal &&
                 player.GetComponent<EnnerControl>().playerAccess.checkFireSeal &&
                 player.GetComponent<EnnerControl>().playerAccess.checkPoisonSeal)
        {
            heroDialog.GetComponent<DialogInteract>().dialog = secondText;
        }
        else if (player.GetComponent<EnnerControl>().playerAccess.checkAcademyApproval)
        {
            heroDialog.GetComponent<DialogInteract>().dialog = firstText;
        }
    }

    private void Update()
    {
        Vector3 temp = player.transform.position - transform.position;
        ChangeAnim(temp);
    }

    private void ChangeAnim(Vector2 direction)
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

    private void SetAnimFLoat(Vector2 setVector)
    {
        anim.SetFloat("movX", setVector.x);
        anim.SetFloat("movY", setVector.y);
    }
}
