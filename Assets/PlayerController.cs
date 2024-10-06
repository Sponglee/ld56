using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody playerBody;

    [SerializeField] private float moveSpeed = 10f;

    [SerializeField] private InertiaController inertiaController;

    // Update is called once per frame
    void Update()
    {
        var move = new Vector2(Input.GetAxis("Horizontal"), 0f);

        if (!inertiaController.HasInertia() && move != Vector2.zero)
        {
            var moveWithSpeed = move * (moveSpeed * inertiaController.Inertia);

            playerBody.velocity = new Vector3(-moveWithSpeed.y, playerBody.velocity.y, moveWithSpeed.x);
            return;
        }

        if (inertiaController.HasInertia())
        {
            var moveWithSpeed = new Vector2(1, 0) *
                                (inertiaController.LastDirection * (moveSpeed * inertiaController.Inertia));

            playerBody.velocity = new Vector3(-moveWithSpeed.y, playerBody.velocity.y, moveWithSpeed.x);
        }
    }
}