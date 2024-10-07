using System;
using DG.Tweening;
using UnityEngine;

public class LevelController : Singleton<LevelController>
{
    [SerializeField] private float spawnTreshold = -150;
    public Vector3 SpawnPosition;
    [SerializeField] private LevelSegment[] levelSegments;

    private InputManager _inputManager;

    private float inputTimer;
    private float _moveSpeed;
    private float _fastSpeed;
    private float _slowSpeed;
    private float _currentSpeed;

    private void Awake()
    {
        _inputManager = InputManager.Instance;
        SpawnPosition = new Vector3(0, 0, -spawnTreshold);

        _inputManager.horizontalInputPressed += UpdateLevelMovement;

        _moveSpeed = GameSettings.Instance.levelMoveSpeed;
        _fastSpeed = _moveSpeed * GameSettings.Instance.speedBoost;
        _slowSpeed = _moveSpeed / GameSettings.Instance.speedBoost;

        _currentSpeed = _moveSpeed;
    }

    private void OnDestroy()
    {
        _inputManager.horizontalInputPressed -= UpdateLevelMovement;
    }

    public void BuffSpeed(bool isBuff)
    {
        var speedBoost = GameSettings.Instance.speedBoost;
        var boosDuration = GameSettings.Instance.boostDuration;
        _currentSpeed  = isBuff ? _fastSpeed : _slowSpeed;

        DOVirtual.DelayedCall(boosDuration, ResetSpeed);
    }

    private void ResetSpeed()
    {
        _currentSpeed = _moveSpeed;
    }

    private void UpdateLevelMovement(float axisValue)
    {
        for (int i = levelSegments.Length - 1; i >= 0; i--)
        {
            var segment = levelSegments[i];

            segment.transform.Translate(Vector3.back * (_currentSpeed * Time.deltaTime));

            if (segment.transform.position.z <= spawnTreshold)
            {
                segment.transform.position = SpawnPosition;
            }
        }
    }
}