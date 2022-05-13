using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprite;
    private Animator animator;

    public EnemyStates State
    {
        get
        {
            return (EnemyStates)animator.GetInteger("state");
        }
        set
        {
            animator.SetInteger("state", (int)value);
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }
}

public enum EnemyStates
{
    idle,
    death
}
