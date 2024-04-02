using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum Team { Blue, Red }

public class BaseCharacter : MonoBehaviour
{
    public Team team;
    public float speed = 5f;
    public int maxHealth = 100;
    public int currentHealth;
    Rigidbody2D rb;
    Vector2 destination;
    Vector2 movement;
    bool isSelected = false;
    Animator animator;
    bool selfClick;
    bool isDead;

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

        if (Input.GetMouseButtonDown(1) && isSelected)
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        animator.SetTrigger("Attack");
        destination = transform.position;
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
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
            if (character.team != this.team)
            {
                character.TakeDamage(damage);
            }
        }
    }


    private void Die()
    {
        Debug.Log(gameObject.name + " has died.");
        animator.SetTrigger("Die");
        isDead = true;
    }

    public void SelectCharacter()
    {
        isSelected = true;
    }

    public void DeselectCharacter()
    {
        isSelected = false;
    }
}
