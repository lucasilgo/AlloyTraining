using EPiServer.Framework.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AlloyTraining.Models.Media
{
    [ContentType(DisplayName = "Pdf File",
        Description = "Use this to upload PDF files.")]
    [MediaDescriptor(ExtensionString = "pdf")]
    public class PdfFile : MediaData
    {
        [Display(Name = "Render preview page")]
        public virtual bool RenderPreviewImage { get; set; }
    }
}
