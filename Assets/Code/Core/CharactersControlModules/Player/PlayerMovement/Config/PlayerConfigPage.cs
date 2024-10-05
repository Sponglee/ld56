using System.Collections.Generic;
using Code.Core.Config.MainLocalConfig;
using UnityEngine;

namespace Code.Core.CharactersControlModules.Player.PlayerMovement.Config
{
    public struct PlayerConfigPage : IConfigPage
    {
        public float RotateSpeed { get; }

        public int SwitchToRunPlayerSpeed { get; }

        public Dictionary<int, float> PlayerMoveSpeedByLevel { get; }

        public PlayerConfigPage(
            float rotateSpeed,
            Dictionary<int, float> playerMoveSpeedByLevel,
            int switchToRunPlayerSpeed)
        {
            RotateSpeed = rotateSpeed;
            PlayerMoveSpeedByLevel = playerMoveSpeedByLevel;
            SwitchToRunPlayerSpeed = switchToRunPlayerSpeed;
        }
    }
}