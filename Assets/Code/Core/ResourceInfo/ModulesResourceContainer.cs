﻿using ResourceInfo.Code.Core.ResourceInfo.ModulesResources;

namespace ResourceInfo.Code.Core.ResourceInfo
{
    public class ModulesResourceContainer
    {
        public readonly CommonGameplayResourceContainer CommonGameplay;
        public readonly ModuleUIContainer ModuleUIContainer;
        public readonly string RemoteConfigPagesContainer;

        public ModulesResourceContainer(string moduleResourcesGroupId)
        {
            CommonGameplay = new CommonGameplayResourceContainer(moduleResourcesGroupId);
            ModuleUIContainer = new ModuleUIContainer(moduleResourcesGroupId);
            RemoteConfigPagesContainer = "RemoteConfigPagesContainer";
        }
    }
}