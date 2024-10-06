using System;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private float spawnTreshold = -150;
    public Vector3 SpawnPosition;
    [SerializeField] private LevelSegment[] levelSegments;
    [SerializeField] private float moveSpeed;

    private InputManager _inputManager;

    private float inputTimer;

    private void Awake()
    {
        _inputManager = InputManager.Instance;
        SpawnPosition = new Vector3(0, 0, -spawnTreshold);

        _inputManager.horizontalInputPressed += UpdateLevelMovement;
    }

    private void OnDestroy()
    {
        _inputManager.horizontalInputPressed -= UpdateLevelMovement;
    }


    private void UpdateLevelMovement(float axisValue)
    {
        for (int i = levelSegments.Length - 1; i >= 0; i--)
        {
            var segment = levelSegments[i];

            segment.transform.Translate(Vector3.back * (moveSpeed * Time.deltaTime));

            if (segment.transform.position.z <= spawnTreshold)
            {
                segment.transform.position = SpawnPosition;
            }
        }
    }
}