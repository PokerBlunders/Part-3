using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : BaseCharacter
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        DealDamage(20);
    }
}
