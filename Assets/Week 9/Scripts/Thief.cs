using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : Villager
{
    public GameObject knifePrefab;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    protected override void Attack()
    {
        //dash towards mouse
        destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        speed = 7;
        base.Attack();
        Instantiate(knifePrefab, spawnPoint1.position, spawnPoint1.rotation);
        Instantiate(knifePrefab, spawnPoint2.position, spawnPoint2.rotation);
    }
    public override ChestType CanOpen()
    {
        return ChestType.Thief;
    }

    public override string ToString()
    {
        return "Thief";
    }
}
