using EPiServer.DataAnnotations; // [GroupDefinitions], [RequiredAccess]
using EPiServer.Security; // AccessLevel
using System.ComponentModel.DataAnnotations; // [Display]

namespace AlloyTraining
{
    [GroupDefinitions]
    public static class SiteTabNames
    {
        [Display(Order = 10)] // to sort horizontal tabs
        [RequiredAccess(AccessLevel.Edit)]
        public const string SEO = "SEO";

        [Display(Order = 20)]
        [RequiredAccess(AccessLevel.Administer)]
        public const string SiteSettings = "Site Settings";
    }
}
