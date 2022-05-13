using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayerCollider : MonoBehaviour
{
    [SerializeField] private Hero hero;
    [SerializeField] private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "KillFloor")
        {
            SoundManager.Play("hit");
            hero.TakeDamageAndTp();
        }
        else if (collision.tag == "Checkpoint")
        {
            hero.ChangeRespawnPoint(collision.transform);
        }
        else if (collision.tag == "EnemyHead")
        {
            SoundManager.Play("jump");
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * 300f);
        }
        else if (collision.tag == "Enemy")
        {
            SoundManager.Play("hit");
            hero.IsHurt = true;
            rb.velocity = new Vector2(rb.velocity.x - 1f, 0f);
            rb.AddForce(Vector2.up * 400f);
            StartCoroutine(GetHurt());
        }
        else if (collision.tag == "Star")
        {
            SoundManager.Play("collect");
            Destroy(collision.gameObject);
            hero.starsCount++;
        } else if (collision.tag == "House")
        {
            LevelCompleteMenu.isLevelComplete = true;
        } else if (collision.tag == "Carrot")
        {
            if (hero.lives < 3)
            {
                hero.lives++;
                Destroy(collision.gameObject);
            }
        }
    }

    private float invulnerableTime = 2f;
    public IEnumerator GetHurt()
    {
        hero.lives--;
        hero.State = States.hurt;
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(invulnerableTime);
        GetComponent<BoxCollider2D>().enabled = true;
        hero.IsHurt = false;
    }
}
