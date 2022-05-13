using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 vector;
    [Range(0, 10)] public float smoothness = 2;

    private void Awake()
    {
        if (!player)
        {
            player = FindObjectOfType<Hero>().transform;
        }
    }

    private void Update()
    {
        vector = player.position;
        vector.z = -5f;
        

        transform.position = Vector3.Lerp(transform.position, vector, smoothness * Time.deltaTime);
    }
}
