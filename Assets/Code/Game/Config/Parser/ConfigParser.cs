using System.Collections.Generic;
using System.Threading;
using Code.Core.CameraControl.CameraMovement.Config;
using Code.Core.CharactersControlModules.Player.PlayerMovement.Config;
using Code.Core.Config;
using Code.Core.Config.MainLocalConfig;
using Code.Game.Config.RemoteConfigs;
using Code.Game.Config.RemoteConfigs.RemotePages.Base;
using Code.Game.Config.RemoteConfigs.RemotePages.CameraPage;
using Code.Game.Config.RemoteConfigs.RemotePages.PlayerPage;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Code.Game.Config.Parser
{
    public class ConfigParser : IConfigParser
    {
        private readonly IRemoteConfigPagesContainer _remoteConfigPagesContainer;
        private readonly ILocalConfig _localConfig;

        public ConfigParser(IRemoteConfigPagesContainer remoteConfigPagesContainer, ILocalConfig localConfig)
        {
            _remoteConfigPagesContainer = remoteConfigPagesContainer;
            _localConfig = localConfig;

            _remoteConfigPagesContainer.AnyPageChanged += OnAnyPageChanged;
        }

        public void Dispose()
        {
        }

        public void ParseConfig()
        {
            var configPages = ParseConfigPages();
            _localConfig.UpdateConfig(configPages);
        }

        public UniTask ParseConfigAsync(CancellationToken token)
        {
            UpdateConfigPages();

            return UniTask.CompletedTask;
        }

        private void OnAnyPageChanged()
        {
            UpdateConfigPages();
        }

        private void UpdateConfigPages()
        {
            var configPages = ParseConfigPages();
            _localConfig.UpdateConfig(configPages);
        }

        private IConfigPage[] ParseConfigPages()
        {
            var remoteConfigPages = _remoteConfigPagesContainer.GetRemoteConfigPages();
            var configPages = new IConfigPage[remoteConfigPages.Length];

            for (var i = 0; i < remoteConfigPages.Length; i++)
            {
                var remoteConfigPage = remoteConfigPages[i];

                var configPage = ParseConfigPage(remoteConfigPage);
                configPages[i] = configPage;
            }

            return configPages;
        }

        private IConfigPage ParseConfigPage(IRemoteConfigPage remoteConfigPage)
        {
            switch (remoteConfigPage)
            {
                case PlayerRemoteConfigPage playerRemoteConfigPage:
                    return ParsePlayerPage(playerRemoteConfigPage);
                case CameraControlsRemotePage cameraRemoteConfigPage:
                    return ParseCameraPage(cameraRemoteConfigPage);
                default:
                    Debug.LogError($"Need add logic for parse {remoteConfigPage.GetType()}");
                    return null;
            }
        }

        private IConfigPage ParseCameraPage(CameraControlsRemotePage remoteConfigPage)
        {
            return null;
            // new GameplayCameraConfigPage(rotationSpeed, moveSpeedByLevel, switchToRunSpeed);
        }

        private IConfigPage ParsePlayerPage(PlayerRemoteConfigPage remoteConfigPage)
        {
            var moveSpeedByLevel = ParseMoveSpeed(remoteConfigPage.MoveSpeedByLevels);
            var rotationSpeed = remoteConfigPage.RotationSpeed;
            var switchToRunSpeed = remoteConfigPage.PlayerRunSpeed;
            return new PlayerConfigPage(rotationSpeed, moveSpeedByLevel, switchToRunSpeed);
        }

        private Dictionary<int, float> ParseMoveSpeed(IReadOnlyCollection<MoveSpeedByLevel> moveSpeedByLevels)
        {
            var parsedMoveSpeedByLevel = new Dictionary<int, float>(moveSpeedByLevels.Count);
            foreach (var moveSpeedByLevel in moveSpeedByLevels)
            {
                parsedMoveSpeedByLevel[moveSpeedByLevel.Level] = moveSpeedByLevel.MoveSpeed;
            }

            return parsedMoveSpeedByLevel;
        }
    }
}