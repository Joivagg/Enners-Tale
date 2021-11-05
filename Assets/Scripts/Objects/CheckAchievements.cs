using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Required
{
    academyApproval,
    waterSeal,
    fireSeal,
    poisonSeal,
    castleMedal
}

public class CheckAchievements : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private Required checkAccess;

    private void Start()
    {
        if (checkAccess == Required.academyApproval && player.GetComponent<EnnerControl>().playerAccess.checkAcademyApproval
            || checkAccess == Required.waterSeal && player.GetComponent<EnnerControl>().playerAccess.checkWaterSeal
            || checkAccess == Required.fireSeal && player.GetComponent<EnnerControl>().playerAccess.checkFireSeal
            || checkAccess == Required.poisonSeal && player.GetComponent<EnnerControl>().playerAccess.checkPoisonSeal
            || checkAccess == Required.castleMedal && player.GetComponent<EnnerControl>().playerAccess.checkCastleMedal)
        {
            this.gameObject.SetActive(false);
        }
    }
}
