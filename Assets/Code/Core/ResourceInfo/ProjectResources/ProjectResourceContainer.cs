using ResourceInfo.Code.Core.ResourceInfo.ModulesResources;
using ResourceInfo.Code.Core.ResourceInfo.ProjectResources.UI;

namespace ResourceInfo.Code.Core.ResourceInfo.ProjectResources
{
    public struct ProjectResourceContainer
    {
        public string GroupId { get; }
        public CommonUIResources CommonUIResources { get; }
        public readonly CommonGameplayResourceContainer CommonGameplay;
        public readonly string RemoteConfigPagesContainer;

        public ProjectResourceContainer(string groupId)
        {
            GroupId = groupId;
            RemoteConfigPagesContainer = "RemoteConfigPagesContainer";
            CommonUIResources = new CommonUIResources(groupId);
            CommonGameplay = new CommonGameplayResourceContainer(groupId);
        }
    }
}