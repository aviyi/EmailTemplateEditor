using EmailTemplateSite.Controllers;
using EmailTemplateteService;

namespace EmailTemplateSite.ViewModels
{
    internal static class Converter
    {
        public static BranchViewModel ToDescriptor(this BranchInfo branchInfo)
        {
            return new BranchViewModel
            {
                Id = branchInfo.Id,
                Name = branchInfo.Name
            };
        }
    }
}
