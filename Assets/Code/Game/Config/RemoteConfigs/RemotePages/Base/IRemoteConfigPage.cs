using System;

namespace Code.Game.Config.RemoteConfigs.RemotePages.Base
{
    public interface IRemoteConfigPage
    {
        public event Action PageChanged;
    }
}