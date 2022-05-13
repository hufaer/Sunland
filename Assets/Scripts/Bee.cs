using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    [SerializeField] private float speed;
    public int start;
    public Transform[] borders;
    private int i;
    private Animator animator;

    public EnemyStates State
    {
        get
        {
            return (EnemyStates)animator.GetInteger("State");
        }

        set
        {
            animator.SetInteger("State", (int)value);
        }

    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        transform.position = borders[start].position;
        i = start;
    }

    private void Update()
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
}
