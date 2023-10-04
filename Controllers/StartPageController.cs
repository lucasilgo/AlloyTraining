using AlloyTraining.Models.Pages; // StartPage
using EPiServer; // IContentLoader
using EPiServer.Framework.DataAnnotations; // [TemplateDescriptor]
using Microsoft.AspNetCore.Mvc; // IActionResult

namespace AlloyTraining.Controllers
{
    [TemplateDescriptor(Inherited = true)]
    public class StartPageController : PageControllerBase<StartPage>
    {
        public StartPageController(IContentLoader loader) : base(loader)
        {
        }

        public IActionResult Index(StartPage currentPage)
        {
            // Implementation of action. You can create your own view model class that you pass to the view or
            // you can pass the page type model directly for simpler templates

            return View(CreatePageViewModel(currentPage));
        }
    }
}
