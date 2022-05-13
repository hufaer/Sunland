using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip jumpSound, collectSound, hitSound;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        jumpSound = Resources.Load<AudioClip>("jump");
        collectSound = Resources.Load<AudioClip>("collect");
        hitSound = Resources.Load<AudioClip>("hit");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void Play(string clipName)
    {
        switch (clipName)
        {
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "collect":
                audioSrc.PlayOneShot(collectSound);
                break;
            case "hit":
                audioSrc.PlayOneShot(hitSound);
                break;
        }
    }
}
