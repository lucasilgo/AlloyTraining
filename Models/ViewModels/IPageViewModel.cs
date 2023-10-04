using AlloyTraining.Models.Pages; // SitePageData, StartPage
using EPiServer.Core; // IContent
using System.Collections.Generic; // IEnumerable

namespace AlloyTraining.Models.ViewModels
{
    public interface IPageViewModel<out T> where T : SitePageData
    {
        T CurrentPage { get; }
        StartPage StartPage { get; }
        IEnumerable<SitePageData> MenuPages { get; }
        IContent Section { get; }
    }
}
