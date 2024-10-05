﻿using System;
using UnityEngine;

namespace Code.Core.CameraControl.Provider
{
public interface ICameraProvider : IDisposable
{
    public event Action CinematicStarted;
    public event Action CinematicStepCompleted;
    public event Action CinematicReturnCompleted;
    // public Camera Camera { get; }
    public bool CinematicInProcess { get; }

    public void Initialize();
    public void CinematicZoom(float targetZoom, Action onZoomCompleted = null);
    public void PlayCinematicMoveTo(Vector3 endPosition, Action onMoveCompleted = null, Action onDelayCompleted = null);
    public void PlayCinematicMoveTo(Vector3 endPosition, float targetDelay, Action onMoveCompleted = null, Action onDelayCompleted = null);
    public void FollowToTarget(Transform target);
    public void ReturnCinematicCamera(Action onReturnCameraCompleted = null);
    public void DisableCamera(Camera targetCamera);
    public void EnableCamera(Camera targetCamera);
    public Camera GetMainCamera();
    public Vector3 GetCameraTargetOffset();
}
}