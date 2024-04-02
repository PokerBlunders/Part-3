using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest : BaseCharacter
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        DealDamage(10);
    }
}
