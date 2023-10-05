using AlloyTraining.Models.Pages;
using AlloyTraining.Models.ViewModels;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace AlloyTraining.Components
{
    [TemplateDescriptor(Inherited = true, Tags = new[] { SiteTags.Full }, AvailableWithoutTag = true)]
    public class AllPagesFullPartialComponent : PartialContentComponent<SitePageData>
    {
        protected override IViewComponentResult InvokeComponent(SitePageData currentPage)
        {
            return View(viewName: SiteTags.Full, model: PageViewModel.Create(currentPage));
        }
    }

    [TemplateDescriptor(Inherited = true, Tags = new[] { SiteTags.Wide }, AvailableWithoutTag = true)]
    public class AllPagesWidePartialComponent : PartialContentComponent<SitePageData>
    {
        protected override IViewComponentResult InvokeComponent(SitePageData currentPage)
        {
            return View(viewName: SiteTags.Wide, model: PageViewModel.Create(currentPage));
        }
    }

    [TemplateDescriptor(Inherited = true, Tags = new[] { SiteTags.Narrow }, AvailableWithoutTag = true)]
    public class AllPagesNarrowPartialComponent : PartialContentComponent<SitePageData>
    {
        protected override IViewComponentResult InvokeComponent(SitePageData currentPage)
        {
            return View(viewName: SiteTags.Narrow, model: PageViewModel.Create(currentPage));
        }
    }
}
