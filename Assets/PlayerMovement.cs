using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody playerBody;

    [SerializeField] private float moveSpeed = 10f;


    // Update is called once per frame
    void Update()
    {
        var move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (move != Vector2.zero)
        {
            var moveWithSpeed = move * moveSpeed;

            playerBody.velocity = new Vector3(-moveWithSpeed.y, playerBody.velocity.y, moveWithSpeed.x);
        }
    }
}