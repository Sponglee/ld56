using System;
using Code.Game.Config.RemoteConfigs.RemotePages.Base;
using UnityEngine;

namespace Code.Game.Config.RemoteConfigs.RemotePages.PlayerPage
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "ScriptableObjects/Config/PlayerSettings", order = 0)]
    public class PlayerRemoteConfigPage : ScriptableObject, IRemoteConfigPage
    {
        [field: SerializeField] public int PlayerRunSpeed { get; private set; }

        [field: SerializeField] public float RotationSpeed { get; private set; }

        [field: SerializeField] public MoveSpeedByLevel[] MoveSpeedByLevels { get; private set; }

        public event Action PageChanged;

        private void OnValidate()
        {
            PageChanged?.Invoke();
        }
    }
}