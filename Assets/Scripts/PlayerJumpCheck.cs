using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpCheck : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private BoxCollider2D trigger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HeroBottom")
        {
            enemy.GetComponentInChildren<EnemyMoving>().canMove = false;
            GetComponent<BoxCollider2D>().enabled = false;
            trigger.enabled = false;
            enemy.State = EnemyStates.death;
            Destroy(transform.parent.gameObject, 1f);
        }
    }
}
