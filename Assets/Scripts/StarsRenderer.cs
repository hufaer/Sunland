using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsRenderer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Hero hero;
    [SerializeField] private Sprite zeroStars;
    [SerializeField] private Sprite oneStar;
    [SerializeField] private Sprite twoStars;
    [SerializeField] private Sprite threeStars;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        int stars = hero.starsCount;
        if (stars == 0)
        {
            // asdadad
            spriteRenderer.sprite = zeroStars;
        }
        else if (stars == 1)
        {
            spriteRenderer.sprite = oneStar;
        }
        else if (stars == 2)
        {
            spriteRenderer.sprite = twoStars;
        } else if (stars == 3)
        {
            spriteRenderer.sprite = threeStars;
        }
    }
}
