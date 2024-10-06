using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelSegment[] levelSegments;
    [SerializeField] private float moveSpeed;

    private InputController inputController;

    private void Awake()
    {
        inputController = InputController.Instance;

        inputController.horizontalInputPressed += UpdateLevelMovement;
    }

    private void OnDestroy()
    {
        inputController.horizontalInputPressed -= UpdateLevelMovement;
    }


    private void UpdateLevelMovement(float axisValue)
    {
        for (int i = levelSegments.Length - 1; i >= 0; i--)
        {
            var segment = levelSegments[i];

            segment.transform.Translate(Vector3.back * (moveSpeed * Time.deltaTime));
        }
    }
}