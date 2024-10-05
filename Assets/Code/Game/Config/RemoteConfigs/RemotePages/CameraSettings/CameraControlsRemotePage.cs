using System;
using Code.Game.Config.RemoteConfigs.RemotePages.Base;
using UnityEngine;

namespace Code.Game.Config.RemoteConfigs.RemotePages.CameraPage
{
    [CreateAssetMenu(fileName = "CameraRemotePage", menuName = "ScriptableObjects/Config/CameraSettings", order = 0)]
    public class CameraControlsRemotePage : ScriptableObject, IRemoteConfigPage
    {
        [field: SerializeField] public int CameraSwitchDuration { get; private set; }

        public event Action PageChanged;

        private void OnValidate()
        {
            PageChanged?.Invoke();
        }
    }
}