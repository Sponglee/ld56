using System;
using Code.Game.Config.RemoteConfigs.RemotePages.Base;
using Code.Game.Config.RemoteConfigs.RemotePages.PlayerPage;
using UnityEngine;

namespace Code.Game.Config.RemoteConfigs
{
    [CreateAssetMenu(fileName = "Config", menuName = "ScriptableObjects/Config/RemoteConfigPagesContainer", order = 1)]
    public class RemoteConfigPagesContainer : ScriptableObject, IRemoteConfigPagesContainer
    {
        [SerializeField] private PlayerRemoteConfigPage _playerRemoteConfigPage;

        private IRemoteConfigPage[] _remoteConfigPages;

        public event Action AnyPageChanged;

        public void Initialize()
        {
            _remoteConfigPages = new IRemoteConfigPage[]
            {
            };

            foreach (var remoteConfigPage in _remoteConfigPages)
            {
                remoteConfigPage.PageChanged += OnAnyPageChanged;
            }
        }

        public IRemoteConfigPage[] GetRemoteConfigPages()
        {
            return _remoteConfigPages;
        }

        private void OnAnyPageChanged()
        {
            AnyPageChanged?.Invoke();
        }

        public void Dispose()
        {
            foreach (var remoteConfigPage in _remoteConfigPages)
            {
                remoteConfigPage.PageChanged -= OnAnyPageChanged;
            }

            AnyPageChanged = null;
        }
    }
}