using AlloyTraining.Models.Pages;
using AlloyTraining.Models.ViewModels;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Web.Mvc;
using EPiServer.Web;
using Microsoft.AspNetCore.Mvc;

namespace AlloyTraining.Controllers
{
    [TemplateDescriptor(Inherited = true,
        TemplateTypeCategory = TemplateTypeCategories.MvcController,
        Tags = new[] { RenderingTags.Preview, RenderingTags.Edit },
        AvailableWithoutTag = false)]
    public class PreviewPageController : ActionControllerBase, IRenderTemplate<BlockData>
    {
        protected readonly IContentLoader loader;
        
        public PreviewPageController(IContentLoader loader)
        {
            this.loader = loader;
        }

        public IActionResult Index(IContent currentContent)
        {
            SitePageData startPage = loader.Get<SitePageData>(ContentReference.StartPage);
            PreviewPageViewModel viewmodel = new(startPage, currentContent);
            return View(viewmodel);
        }
    }
}
