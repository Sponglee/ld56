using UnityEngine;

public class TiltController : MonoBehaviour
{
    [SerializeField] private SpringJoint[] segments;

    [SerializeField] private Vector2 tiltSpeed;
    [SerializeField] private float tiltTreshold = 45;
    [SerializeField] private InertiaController inertiaController;

    private bool isBroken = false;


    void Update()
    {
        var inputDirection = Input.GetAxisRaw("Horizontal");

        if (inputDirection != default)
        {
            transform.RotateAround(Vector3.right,
                inputDirection * Time.deltaTime *
                (inertiaController.IsSameDirection(inputDirection > 0 ? 1 : -1)
                    ? tiltSpeed.x
                    : tiltSpeed.y) * inertiaController.Inertia);
            return;
        }

        if (inertiaController.HasInertia())
        {
            transform.RotateAround(inertiaController.LastDirection == 1 ? Vector3.right : Vector3.left,
                Time.deltaTime * tiltSpeed.x * inertiaController.Inertia);

            return;
        }

        transform.rotation =
            Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * tiltSpeed.y);

        CheckTilt();
    }


    private void CheckTilt()
    {
        if (isBroken) return;
        Debug.Log($"BaM! {Vector3.Dot(Vector3.up, transform.up)} < {tiltTreshold}");

        if (Vector3.Dot(Vector3.up, transform.up) < tiltTreshold)
        {
            for (int i = segments.Length - 1; i >= 0; i--)
            {
                var segment = segments[i];
                var body = segment.GetComponent<Rigidbody>();
                segment.breakForce = 0;
                body.AddForce(Vector3.up * 10f, ForceMode.Impulse);
            }

            isBroken = true;
        }
    }
}