using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    private SpriteRenderer sprite;
    [SerializeField] public Sprite oneHealthPoint;
    [SerializeField] public Sprite twoHealthPoints;
    [SerializeField] public Sprite threeHealthPoints;
    [SerializeField] public Hero hero;

    // Start is called before the first frame update
    void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hero.lives == 3)
        {
            sprite.sprite = threeHealthPoints;
        } else if (hero.lives == 2)
        {
            sprite.sprite = twoHealthPoints;
        } else if (hero.lives == 1)
        {
            sprite.sprite = oneHealthPoint;
        }
    }
}
