using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField, Range(0f, 1f)] float strength = 0.1f;
    [SerializeField] bool disableVertical = false;
    Vector3 previousPos;


    void Start()
    {
        if (!target)
        {
            target = Camera.main.transform;
        }

        previousPos = target.position;
    }

    void Update()
    {
        Vector3 delta = target.position - previousPos;
        if (disableVertical)
        {
            delta.y = 0;
        }
        previousPos = target.position;
        transform.position += delta * strength;
    }
}
