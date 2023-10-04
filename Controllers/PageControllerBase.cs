using AlloyTraining.Business.ExtensionMethods; // GetSection extension method
using AlloyTraining.Models.Pages; // SitePageData, StartPage
using AlloyTraining.Models.ViewModels; // IPageViewModel, PageViewModel
using EPiServer; // IContentLoader
using EPiServer.Core; // ContentReference
using EPiServer.Filters; // FilterForVisitor
using EPiServer.ServiceLocation; // Injected
using EPiServer.Shell.Security; // UISignInManager
using EPiServer.Web.Mvc; // PageController
using Microsoft.AspNetCore.Mvc; // IActionResult
using System.Linq; // Cast<T> extension method
using System.Threading.Tasks; // Task<T>

namespace AlloyTraining.Controllers
{
    public abstract class PageControllerBase<T>
        : PageController<T> where T : SitePageData
    {
        protected readonly Injected<UISignInManager> UISignInManager;
        protected readonly IContentLoader loader;

        public PageControllerBase(IContentLoader loader)
        {
            this.loader = loader;
        }

        public async Task<IActionResult> Logout()
        {
            await UISignInManager.Service.SignOutAsync();
            return RedirectToAction("Index");
        }

        protected IPageViewModel<TPage> CreatePageViewModel<TPage>(
            TPage currentPage) where TPage : SitePageData
        {
            var viewmodel = PageViewModel.Create(currentPage);

            viewmodel.StartPage = loader.Get<StartPage>(ContentReference.StartPage);

            viewmodel.MenuPages = FilterForVisitor.Filter(
                loader.GetChildren<SitePageData>(ContentReference.StartPage))
                .Cast<SitePageData>().Where(page => page.VisibleInMenu);

            viewmodel.Section = currentPage.ContentLink.GetSection();

            return viewmodel;
        }
    }
}
