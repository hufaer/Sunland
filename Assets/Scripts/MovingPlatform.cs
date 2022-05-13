using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed;
    public int start;
    public Transform[] borders;
    private int i;
    [SerializeField] private bool canMoveWithPlayer;

    void Start()
    {
        transform.position = borders[start].position;
        i = start;
        //
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, borders[i].position) < 0.02f)
        {
            i++;
            if (i == borders.Length)
            {
                i = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, borders[i].position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canMoveWithPlayer)
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (canMoveWithPlayer)
            collision.transform.SetParent(null);
    }
}
