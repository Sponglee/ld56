using System;
using Code.Game.Config.RemoteConfigs.RemotePages.Base;

namespace Code.Game.Config.RemoteConfigs
{
    public interface IRemoteConfigPagesContainer : IDisposable
    {
        public event Action AnyPageChanged;
        public IRemoteConfigPage[] GetRemoteConfigPages();
    }
}