using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Priest : BaseCharacter
{
    protected override void Start()
    {
        attackRadius = 5f;
        attackCooldown = 3f;
        maxHealth = 50;
        base.Start();
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

    protected void Heal()
    {
        if (!isOnCooldown)
        {
            int healAmount = 10;
            currentHealth += healAmount;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            StartCoroutine(AttackCooldownCoroutine());
        }
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Heal();
        }
    }
}
