using System;
using DG.Tweening;
using UnityEngine;

public class LevelController : Singleton<LevelController>
{
    [SerializeField] private float spawnTreshold = -150;
    public Vector3 SpawnPosition;
    [SerializeField] private LevelSegment[] levelSegments;

    private GameStateManager _gameStateManager;
    private InputManager _inputManager;
    private GameSettings _gameSettings;
    private PlayerController _playerController;
    private PlayerStateController _playerStateController;
    
    private float inputTimer;
    private float _currentSpeed;
    private void Start()
    {
        _gameStateManager = GameStateManager.Instance;
        _inputManager = InputManager.Instance;
        _gameSettings = GameSettings.Instance;
        _playerController = PlayerController.Instance;
        _playerStateController = PlayerStateController.Instance;
        SpawnPosition = new Vector3(0, 0, -spawnTreshold);



        _currentSpeed = _gameSettings.levelMoveSpeed;
    }

    private void OnDestroy()
    {
        if (_inputManager != null)
        {

        }
    }

    public void BuffSpeed(bool isBuff)
    {
        var speedBoost = GameSettings.Instance.speedBoost;
        var boosDuration = GameSettings.Instance.boostDuration;
        _currentSpeed += (isBuff ? speedBoost : 1/speedBoost);

        // DOVirtual.DelayedCall(boosDuration, ResetSpeed);
    }

    private void ResetSpeed()
    {
        _currentSpeed = _gameSettings.levelMoveSpeed;
    }

    private void Update()
    {
        if(_gameStateManager.GameState != GameState.Playing) return;
        
        for (int i = levelSegments.Length - 1; i >= 0; i--)
        {
            var segment = levelSegments[i];

            segment.transform.Translate(Vector3.back * (_currentSpeed * Time.deltaTime));

            if (segment.transform.position.z <= spawnTreshold)
            {
                segment.transform.position = SpawnPosition;
            }
        }
        
        UpdatePlayerMovementOutside();
        
        if(_currentSpeed<=0)
        {
            _currentSpeed = 0;
        }
    }
    

    private void UpdatePlayerMovementOutside()
    {
        if (_playerStateController.PlayerState == PlayerState.Running)
        {
            _currentSpeed -= _gameSettings.acceleration.x * Time.deltaTime;
            _currentSpeed = Mathf.Clamp(_gameSettings.levelMoveSpeed, _gameSettings.levelMoveSpeed,Mathf.Infinity);
        }
        
        if (Vector3.Dot(_playerController.transform.up, Vector3.forward) >= 0)
        {
            Debug.Log("+ " + Vector3.Dot(_playerController.transform.forward, Vector3.up));
            _currentSpeed += _gameSettings.acceleration.y * Time.deltaTime;
        }
        else if (Vector3.Dot(_playerController.transform.up, Vector3.forward) < 0)
        {
            Debug.Log("-" + Vector3.Dot(_playerController.transform.forward, Vector3.up));
            _currentSpeed -= _gameSettings.acceleration.x * Time.deltaTime;
        }
    }
}