using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillingBee : MonoBehaviour
{
    [SerializeField] private BoxCollider2D trigger;
    [SerializeField] private Bee bee;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            trigger.enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            bee.State = EnemyStates.death;
            Destroy(transform.parent.gameObject, 1f);
        }
    }
}
