using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    private Vector3 startScale;

    private Transform _transform;


    private void Awake()
    {
        _transform = transform;

        startScale = _transform.lossyScale;
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            Jump();
        }
    }


    private void Jump()
    {
    }
}