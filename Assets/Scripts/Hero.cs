using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] public int lives = 3;
    [SerializeField] private float jumpForce = 7f;
    [SerializeField] Transform respawnPoint;
    [SerializeField] public int extraJumpsCount = 1;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private bool isGrounded = false;
    private Animator animator;
    private bool isClimbing;
    private int extraJumps;

    public int starsCount = 0;
    public bool IsHurt { get; set; }

    public States State
    {
        get
        {
            return (States)animator.GetInteger("state");
        }
        set
        {
            animator.SetInteger("state", (int)value);
        }
    }

    public int ExtraJumps
    {
        get
        {
            return extraJumps;
        }
        set
        {
            extraJumps = value;
        }
    }


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (isGrounded && !IsHurt)
        {
            State = States.idle;
        }

        if (IsHurt)
        {
            State = States.hurt;
        }

        if (Input.GetButton("Horizontal"))
        {
            Run();
        }


        if (isGrounded)
        {
            extraJumps = extraJumpsCount;
        }
        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            SoundManager.Play("jump");
            Jump();
            extraJumps--;
        } else if (Input.GetButtonDown("Jump") && extraJumps == 0 && isGrounded)
        {
            SoundManager.Play("jump");
            Jump();
        }

        if (lives <= 0)
        {
            GameOverMenu.gameIsOver = true;
        }
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Run()
    {
        if (isGrounded)
        {
            State = States.walk;
        }

        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sprite.flipX = direction.x < 0.0f;
    }

    private void Jump()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    private void CheckGround()
    {
        bool isLadder = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f);
        if (colliders.Length > 1)
        {
            int count = 0;
            foreach (Collider2D collider in colliders)
            {
                if (!collider.isTrigger)
                {
                    if (collider.tag == "Enemy")
                    {
                        lives--;
                    }
                    if (collider.tag == "Trampoline")
                    {
                        isGrounded = false;
                        return;
                    }
                    else
                    {
                        count++;
                    }
                }
                else if (collider.tag == "Ladder")
                {
                    isLadder = true;
                }
            }
            isGrounded = count > 1;
        }
        else
        {
            isGrounded = false;
        }
        if (!isGrounded)
        {
            if (isLadder)
            {
                State = States.climb;
                if (extraJumpsCount == 1)
                {
                    extraJumps = 1;
                }
            }
            else if (IsHurt)
            {
                State = States.hurt;
            } else
            {
                State = States.jump;
            }
        }
    }

    public void TakeDamageAndTp()
    {
        lives--;
        if (lives > 0)
        {
            rb.isKinematic = true;
            transform.position = respawnPoint.position;
            rb.isKinematic = false;
        }
    }

    public void ChangeRespawnPoint(Transform transform)
    {
        respawnPoint.position = transform.position;
    }
}


public enum States
{
    idle,
    walk,
    jump,
    climb,
    hurt
}