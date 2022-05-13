using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderBehaviour : MonoBehaviour
{
    private float speed = 4f;
    private bool playerIsOn = false;
    [SerializeField] private Rigidbody2D rb;

    private void Update()
    {
        if (playerIsOn)
        {
            if (Input.GetButton("Vertical"))
            {
                rb.gravityScale = 0;
                if (Input.GetKey(KeyCode.W))
                {
                    rb.velocity = new Vector2(0, speed);

                }
                else if (Input.GetKey(KeyCode.S))
                {
                    rb.velocity = new Vector2(0, -speed);
                }
            }
        } else
        {
            rb.gravityScale = 1;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerIsOn = true;
        }
    }

    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerIsOn = false;
        }
    }
}
