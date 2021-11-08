using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Achievements : ScriptableObject
{
    public bool checkAcademyApproval;
    public bool checkWaterSeal;
    public bool checkFireSeal;
    public bool checkPoisonSeal;
    public bool checkCastleMedal;
    public bool englishLevel1;
    public bool englishLevel2;
    public bool englishLevel3;
    public bool englishLevel4;

    private void OnEnable()
    {
        checkAcademyApproval = false;
        checkWaterSeal = false;
        checkFireSeal = false;
        checkPoisonSeal = false;
        checkCastleMedal = false;
        englishLevel1 = false;
        englishLevel2 = false;
        englishLevel3 = false;
        englishLevel4 = false;
    }
}