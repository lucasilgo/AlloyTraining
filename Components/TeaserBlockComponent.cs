using AlloyTraining.Models.Blocks;
using AlloyTraining.Models.ViewModels;
using EPiServer.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using EPiServer.Framework.DataAnnotations;

namespace AlloyTraining.Components
{
    [TemplateDescriptor(Tags = new[] { SiteTags.Full }, AvailableWithoutTag = true)]
    public class TeaserBlockComponent : BlockComponent<TeaserBlock>
    {
        protected override IViewComponentResult InvokeComponent(TeaserBlock currentBlock)
        {
            TeaserBlockViewModel viewmodel = new()
            {
                CurrentBlock = currentBlock,
                TodaysVisitorCount = new Random().Next(300, 900)
            };
            return View(viewmodel);
        }
    }

    [TemplateDescriptor(Tags = new[] { SiteTags.Wide })]
    public class TeaserBlockWideComponent : BlockComponent<TeaserBlock>
    {
        protected override IViewComponentResult InvokeComponent(
        TeaserBlock currentBlock)
        {
            TeaserBlockViewModel viewmodel = new()
            {
                CurrentBlock = currentBlock,
                TodaysVisitorCount = new Random().Next(300, 900)
            };
            return View(viewName: "wide", model: viewmodel);
        }
    }

    [TemplateDescriptor(Tags = new[] { SiteTags.Narrow })]
    public class TeaserBlockNarrowComponent : BlockComponent<TeaserBlock>
    {
        protected override IViewComponentResult InvokeComponent(
        TeaserBlock currentBlock)
        {
            TeaserBlockViewModel viewmodel = new()
            {
                CurrentBlock = currentBlock,
                TodaysVisitorCount = new Random().Next(300, 900)
            };
            return View(viewName: "narrow", model: viewmodel);
        }
    }


}
