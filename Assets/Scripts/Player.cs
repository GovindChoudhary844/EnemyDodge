using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private int health;

    public static Player instance;

    private float moveInput;

    private Rigidbody2D rb;
    private Animator animator;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(moveInput != 0)
        {
            animator.SetBool("isRunning" , true);
        } else
        {
            animator.SetBool("isRunning", false);
        }

        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        } else if ( moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    // FixedUpdate is called at a fixed interval and used for physics calculations
    void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        if(health <= 0)
        {
            // Destroy the player
            Destroy(gameObject);
        }
    }
}
