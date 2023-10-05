using AlloyTraining.Models.Blocks;
using AlloyTraining.Models.ViewModels;
using EPiServer.Filters;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace AlloyTraining.Components
{
    public class ListingBlockComponent : BlockComponent<ListingBlock>
    {
        protected readonly IContentLoader loader;

        public ListingBlockComponent(IContentLoader loader)
        {
            this.loader = loader;
        }

        protected override IViewComponentResult InvokeComponent(ListingBlock currentBlock)
        {
            ListingBlockViewModel viewmodel = new()
            {
                Heading = currentBlock.Heading
            };

            if (currentBlock.ShowChildrenOfThisPage != null)
            {
                IEnumerable<PageData> children = loader.GetChildren<PageData>(currentBlock.ShowChildrenOfThisPage);

                IEnumerable<IContent> filteredChildren = FilterForVisitor.Filter(children);

                viewmodel.Pages = filteredChildren.Cast<PageData>().Where(page => page.VisibleInMenu);
            }

            return View(viewmodel);
        }
    }
}
