using AlloyTraining.Models.Media;
using System.ComponentModel.DataAnnotations;

namespace AlloyTraining.Models.Pages
{
    [ContentType(
        DisplayName = "Start",
        GUID = "EFC7FE3A-5217-4535-BC33-D630C1FE7A59",
        GroupName = SiteGroupNames.Specialized,
        Order = 10,
        Description = "Start page")]
    [SiteStartIcon]
    [AvailableContentTypes(Include = new[] { typeof(StandardPage) })]
    public class StartPage : SitePageData
    {
        [CultureSpecific]
        [Display(
            Name = "Heading",
            Description = "The heading of the page",
            GroupName = SystemTabNames.Content,
            Order = 10)]
        public virtual string Heading { get; set; }

        [CultureSpecific]
        [Display(Name = "Footer text",
            Description = "The footer text will be shown at the bottom of every page.",
            GroupName = SiteTabNames.SiteSettings, Order = 10)]
        public virtual string FooterText { get; set; }

        [CultureSpecific]
        [Display(
            Name = "MainBody",
            Description = "The main body of the page",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual XhtmlString MainBody { get; set; }

        [CultureSpecific]
        [Display(
            Name = "MainContentArea",
            Description = "The main content area of the page",
            GroupName = SystemTabNames.Content,
            Order = 30)]
        [AllowedTypes(typeof(StandardPage), typeof(BlockData), 
            typeof(ImageData), typeof(ContentFolder), typeof(PdfFile))]
        public virtual ContentArea MainContentArea { get; set; }

        [Display(
            Name = "Search page",
            Description = "If you add a Search page to the site, set this property to reference it to enable search from every page.",
            GroupName = SiteTabNames.SiteSettings,
            Order = 40)]
        [AllowedTypes(typeof(SearchPage))]
        public virtual PageReference SearchPageLink { get; set; }
    }
}
