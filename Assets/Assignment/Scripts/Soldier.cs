using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : BaseCharacter
{
    protected override void Start()
    {
        attackCooldown = 1.5f;
        attackRadius = 1.5f;
        maxHealth = 100;
        base.Start();
    }

    protected override IEnumerator AttackCooldownCoroutine()
    {
        return base.AttackCooldownCoroutine();
    }

    protected override void Attack()
    {
        base.Attack();
        DealDamage(20);
    }
}
