using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private Transform[] trackPoints;
    [SerializeField] private float moveDuration;
    [SerializeField] private float waitTime;
    [SerializeField] private Transform carTransform;

    private float elapsed;


    private void Update()
    {
        carTransform.position = Vector3.Lerp(trackPoints[0].position, trackPoints[1].position, elapsed / moveDuration);
        elapsed += Time.deltaTime;

        if (elapsed > moveDuration + waitTime)
        {
            elapsed = 0f;
        }
    }
}