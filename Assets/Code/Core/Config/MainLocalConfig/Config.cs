using System;
using System.Collections.Generic;

namespace Code.Core.Config.MainLocalConfig
{
    public class LocalConfig : ILocalConfig
    {
        public event Action<ILocalConfig> ConfigChanged;

        private readonly List<IConfigPage> _configPages = new();

        public LocalConfig()
        {
        }

        public void Dispose()
        {
            ConfigChanged = null;
            _configPages.Clear();
        }

        public void UpdateConfig(IConfigPage[] configPages)
        {
            _configPages.Clear();
            _configPages.AddRange(configPages);

            ConfigChanged?.Invoke(this);
        }

        public T GetConfigPage<T>() where T : IConfigPage
        {
            foreach (var configPage in _configPages)
            {
                if (configPage is T concrete)
                {
                    return concrete;
                }
            }

            return default;
        }
    }
}