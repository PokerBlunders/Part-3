using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Apple;
using UnityEngine.EventSystems;

public class BaseCharacter : MonoBehaviour
{
    public float speed = 5f;
    public int maxHealth = 100;
    int currentHealth;
    Rigidbody2D rb;
    Vector2 destination;
    Vector2 movement;
    bool isSelected = false;
    Animator animator;
    bool selfClick;

    private void Start()
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
        if (isSelected)
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
        if (Input.GetMouseButtonDown(0) && isSelected && !selfClick)
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat("Walking", movement.magnitude);

        if (Input.GetMouseButtonDown(1) && isSelected)
        {
            Attack();
        }
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
        destination = transform.position;
    }

    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " has died.");
        Destroy(gameObject);
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
