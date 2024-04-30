using OutSystems.ExternalLibraries.SDK;

namespace HTMLMarkdown
{
    [OSInterface(Description = "Facilitates conversion from HTML to Markdown and vice versa.", Name = "HTML-Markdown-Converter")]
    public interface IHTMLMarkdownConverter
    {
        [OSAction(Description = "Converts HTML to Markdown.", ReturnName = "Markdown", ReturnType = OSDataType.Text)]
        public string HTMLToMarkdown(
            [OSParameter(DataType = OSDataType.Text, Description = "The HTML which needs to be converted to HTML")] string html);

        [OSAction(Description = "Converts Markdown to HTMl.", ReturnName = "HTML", ReturnType = OSDataType.Text)]
        public string MarkdownToHTML(
            [OSParameter(DataType = OSDataType.Text, Description = "The Markdown which needs to be converted to HTML")] string markdown);
    }
}