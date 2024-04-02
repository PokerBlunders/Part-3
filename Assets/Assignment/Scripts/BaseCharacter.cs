using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum Team { Blue, Red }

public class BaseCharacter : MonoBehaviour
{
    public Team team;
    public float speed = 5f;
    public int maxHealth;
    public int currentHealth;
    Rigidbody2D rb;
    Vector2 destination;
    Vector2 movement;
    bool isSelected = false;
    Animator animator;
    bool selfClick;
    bool isDead;
    TeamManager teamManager;

    protected float attackCooldown;
    bool isOnCooldown = false;
    public Slider cooldownSlider;
    public float attackRadius;

    public Image hightlight;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        destination = transform.position;
    }

    private void OnMouseDown()
    {
        selfClick = true;
    }

    private void OnMouseUp()
    {
        selfClick = false;
    }

    private void FixedUpdate()
    {
        if (isSelected || movement.magnitude>0.1)
        {
            movement = destination - (Vector2)transform.position;
            if (movement.magnitude > 0.1f)
            {
                rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
            }
            else
            {
                movement = Vector2.zero;
            }
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isSelected && !selfClick && !isDead)
        {
            if (Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition)) == null)
            {
                destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        animator.SetFloat("Walking", movement.magnitude);

        if (Input.GetMouseButtonDown(1) && isSelected && !isOnCooldown)
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        if (!isOnCooldown)
        {
            animator.SetTrigger("Attack");
            destination = transform.position;

            StartCoroutine(AttackCooldownCoroutine());
        }
    }

    protected virtual IEnumerator AttackCooldownCoroutine()
    {
        isOnCooldown = true;
        float cooldownTimer = attackCooldown;

        while (cooldownTimer > 0f)
        {
            cooldownSlider.value = cooldownTimer / attackCooldown;

            yield return new WaitForSeconds(0.1f);
            cooldownTimer -= 0.1f;
        }

        isOnCooldown = false;
        cooldownSlider.value = 1;
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth > 0 && !isDead)
        {
            animator.SetTrigger("Hurt");
        }
        if (currentHealth <= 0 && !isDead)
        {
            Die();
        }
    }

    protected void DealDamage(int damage)
    {
        BaseCharacter[] characters = FindObjectsOfType<BaseCharacter>();

        foreach (BaseCharacter character in characters)
        {
            if (character.team != this.team && Vector2.Distance(transform.position, character.transform.position) <= attackRadius)
            {
                character.TakeDamage(damage);
            }
        }
    }


    private void Die()
    {
        animator.SetTrigger("Die");
        isDead = true;

        TeamManager.IncrementTeamKills(team);
    }

    public void Victory()
    {
        if (!isDead)
        {
            animator.SetTrigger("Victory");
        }
    }

    public void SelectCharacter()
    {
        isSelected = true;
        hightlight.color = Color.white;
    }

    public void DeselectCharacter()
    {
        isSelected = false;
        hightlight.color = Color.black;
    }
}
