﻿using EPiServer.Web;
using System.ComponentModel.DataAnnotations;

namespace AlloyTraining.Models.Blocks
{
    [ContentType(DisplayName = "Teaser",
        GroupName = SiteGroupNames.Common,
        Description = " Use this for rich text with heading, image and page link that will be reused in multiple places.")]
    [SiteBlockIcon]
    public class TeaserBlock : BlockData
    {
        [CultureSpecific]
        [Display(Name = "Heading", Order = 10,
            GroupName = SystemTabNames.PageHeader)]
        public virtual string TeaserHeading { get; set; }

        [CultureSpecific]
        [Display(Name = "Rich text", Order = 20,
            GroupName = SystemTabNames.PageHeader)]
        public virtual XhtmlString TeaserText { get; set; }

        [Display(Name = "Image", Order = 30,
            GroupName = SystemTabNames.PageHeader)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference TeaserImage { get; set; }

        [Display(Name = "Link", Order = 40,
            GroupName = SystemTabNames.PageHeader)]
        public virtual PageReference TeaserLink { get; set; }
    }

}
