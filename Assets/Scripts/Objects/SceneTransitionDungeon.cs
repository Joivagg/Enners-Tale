using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Dungeon
{
    academy,
    water,
    fire,
    poison,
    castle
}

public class SceneTransitionDungeon : SceneTransition
{
    [Header("Check Clear Dungeon")]
    [SerializeField]
    private Dungeon styleDungeon;
    [SerializeField]
    private GameObject player;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if(other.CompareTag("Enner") && !other.isTrigger)
        {
            if (styleDungeon == Dungeon.academy)
            {
                player.GetComponent<EnnerControl>().playerAccess.checkAcademyApproval = true;
            }
            if (styleDungeon == Dungeon.water)
            {
                player.GetComponent<EnnerControl>().playerAccess.checkWaterSeal = true;
            }
            if (styleDungeon == Dungeon.fire)
            {
                player.GetComponent<EnnerControl>().playerAccess.checkFireSeal = true;
            }
            if (styleDungeon == Dungeon.poison)
            {
                player.GetComponent<EnnerControl>().playerAccess.checkPoisonSeal = true;
            }
            if (styleDungeon == Dungeon.castle)
            {
                player.GetComponent<EnnerControl>().playerAccess.checkCastleMedal = true;
            }
            player.GetComponent<EnnerControl>().currentHealth.RuntimeValue = player.GetComponent<EnnerControl>().currentHealth.initialValue;
        }
    }
}
