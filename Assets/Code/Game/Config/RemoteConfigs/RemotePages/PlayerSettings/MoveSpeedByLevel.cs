using System;
using UnityEngine;

namespace Code.Game.Config.RemoteConfigs.RemotePages.PlayerPage
{
    [Serializable]
    public struct MoveSpeedByLevel
    {
        [field: SerializeField] public int Level { get; private set; }

        [field: SerializeField] public float MoveSpeed { get; private set; }

        public event Action PageChanged;

        private void OnValidate()
        {
            PageChanged?.Invoke();
        }
    }
}