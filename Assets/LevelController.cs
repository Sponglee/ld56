using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelSegment[] levelSegments;
    [SerializeField] private float moveSpeed;

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != default)
        {
            for (int i = levelSegments.Length - 1; i >= 0; i--)
            {
                var segment = levelSegments[i];

                segment.transform.Translate(Vector3.back * (moveSpeed * Time.deltaTime));
            }
        }
    }
}