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
    private string newText;

    private void Start()
    {
        if (player.GetComponent<EnnerControl>().playerAccess.checkAcademyApproval &&
            player.GetComponent<EnnerControl>().playerAccess.checkWaterSeal &&
            player.GetComponent<EnnerControl>().playerAccess.checkFireSeal &&
            player.GetComponent<EnnerControl>().playerAccess.checkPoisonSeal &&
            player.GetComponent<EnnerControl>().playerAccess.checkCastleMedal)
        {
            heroDialog.GetComponent<DialogInteract>().dialog = newText;
        }
    }
}
