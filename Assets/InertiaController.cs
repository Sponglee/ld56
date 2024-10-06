using UnityEngine;

public class InertiaController : MonoBehaviour
{
    private float inertia;
    private int lastDirection = 1;
    [SerializeField] private float inertiaModifier;
    [SerializeField] private Vector2 inertiaSpeed;


    public float Inertia => inertia;
    public int LastDirection => lastDirection;

    public bool HasInertia() => inertia > 0;

    public bool IsSameDirection(int directionIndex) => lastDirection == directionIndex;

    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") != default)
        {
            var direction = Input.GetAxisRaw("Horizontal") > 0 ? 1 : -1;

            if (!HasInertia())
            {
                if (!IsSameDirection(direction))
                {
                    SetDirection(direction == 1 ? 1 : -1);
                }
            }

            if (IsSameDirection(direction))
            {
                AddInertia();
            }
            else
            {
                SubtractInertia();
            }

            if (inertia >= inertiaModifier)
            {
                inertia = inertiaModifier;
            }

            return;
        }

        SubtractInertia();

        if (inertia <= 0f)
        {
            inertia = 0f;
        }
    }

    private void SetDirection(int directionIndex)
    {
        lastDirection = directionIndex;
    }

    private void AddInertia()
    {
        inertia += Time.deltaTime * inertiaSpeed.x;
    }

    private void SubtractInertia()
    {
        inertia -= Time.deltaTime * inertiaSpeed.y;
    }
}