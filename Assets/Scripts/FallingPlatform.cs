using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private float fallDelay = 1;
    [SerializeField] private float respawnDelay = 3;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //respawnPoint = transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Fall());
            StartCoroutine(Respawn());
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.isKinematic = false;
        GetComponent<BoxCollider2D>().isTrigger = true;
        yield return 0;
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnDelay);
        rb.bodyType = RigidbodyType2D.Static;
        GetComponent<BoxCollider2D>().isTrigger = false;
        transform.position = respawnPoint.position;
        yield return 0;
    }
}
