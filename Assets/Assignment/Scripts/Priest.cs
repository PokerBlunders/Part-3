using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest : BaseCharacter
{
    protected override void Start()
    {
        base.Start();
        attackRadius = 5f;
        attackCooldown = 3f;
    }

    protected override IEnumerator AttackCooldownCoroutine()
    {
        return base.AttackCooldownCoroutine();
    }

    protected override void Attack()
    {
        base.Attack();
        DealDamage(10);
    }
}
