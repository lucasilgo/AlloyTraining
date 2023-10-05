using AlloyTraining.Models.Pages;
using AlloyTraining.Models.ViewModels;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace AlloyTraining.Components
{
    public class ProductPagePartialComponent : PartialContentComponent<ProductPage>
    {
        protected override IViewComponentResult InvokeComponent(ProductPage currentPage)
        {
            return View(PageViewModel.Create(currentPage));
        }
    }
}
