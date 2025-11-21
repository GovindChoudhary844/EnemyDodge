using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private int health;

    [SerializeField] private TextMeshProUGUI healthTest;
    [SerializeField] private GameObject gameOverPanel;

    public static Player instance;

    private float moveInput;

    private Rigidbody2D rb;
    private Animator animator;

    private AudioSource hitAudio;

    public float startDashTime;
    private float dashTime;
    public float dashSpeed;
    public bool isDashing;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        hitAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        health = Mathf.Clamp(health, 0, 100);

        healthTest.text = health.ToString();
    }

    // Update is called once per frame
    private void Update()
    {
        // for animation
        if (moveInput != 0)
        {
            animator.SetBool("isRunning" , true);
        } else
        {
            animator.SetBool("isRunning", false);
        }

        // for player direction flip
        if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        } else if ( moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) & isDashing == false)
        {
            speed += dashSpeed;
            isDashing = true;
            dashTime = startDashTime;
        }

        if (dashTime <= 0 && isDashing == true)
        {
            speed -= dashSpeed;
            isDashing = false;
        }
        else
        {
            dashTime -= Time.deltaTime;
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
        hitAudio.Play();
        health -= damageAmount;
        health = Mathf.Clamp(health, 0, 100);
        healthTest.text = health.ToString();


        if (health <= 0)
        {
            // Destroy the player
            Destroy(gameObject);
            gameOverPanel.SetActive(true);
        }
    }
}
