using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Villager
{
    public GameObject daggerPrefab;
    public Transform spawnPoint1;
    public Transform spawnPoint2;

    protected override void Attack()
    {
        base.Attack();

        Instantiate(daggerPrefab, spawnPoint1.position, spawnPoint1.rotation);
        Instantiate(daggerPrefab, spawnPoint2.position, spawnPoint2.rotation);
    }

    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }
}
