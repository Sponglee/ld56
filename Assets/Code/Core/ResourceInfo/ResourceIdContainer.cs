using ResourceInfo.Code.Core.ResourceInfo.ProjectResources;

namespace ResourceInfo.Code.Core.ResourceInfo
{
    public static class ResourceIdContainer
    {
        private const string ProjectResourcesGroupId = "ProjectResources";
        public static ProjectResourceContainer ProjectResourceContainer { get; }

        static ResourceIdContainer()
        {
            ProjectResourceContainer = new ProjectResourceContainer(ProjectResourcesGroupId);
        }
    }
}