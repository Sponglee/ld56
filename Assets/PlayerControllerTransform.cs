using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTransform : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;


    void FixedUpdate()
    {
        var move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (move != Vector2.zero)
        {
            var moveWithSpeed = move * (moveSpeed * Time.deltaTime);

            transform.Translate(new Vector3(-moveWithSpeed.y, 0, moveWithSpeed.x));
        }
    }
}