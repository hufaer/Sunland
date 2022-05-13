using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] Enemy enemy;
    public bool canMove = true;

    private Rigidbody2D rb;
    //private BoxCollider2D collider2D;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    void Update()
    {
        if (canMove)
        {
            if (IsFacingRight())
            {
                rb.velocity = new Vector2(speed, 0f);
            }
            else
            {
                rb.velocity = new Vector2(-speed, 0f);
            }
        } else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private bool IsFacingRight()
    {
        return enemy.transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (canMove)
        {
            if (collision.tag != "Ladder" && collision.tag != "Player" && collision.tag != "HeroBottom" && collision.tag != "House" && collision.tag != "Trampoline")
            {
                enemy.transform.localScale = new Vector3(-enemy.transform.localScale.x, enemy.transform.localScale.y, enemy.transform.localScale.z);
            }
        }
    }
}
