using OutSystems.ExternalLibraries.SDK;

namespace HTMLMarkdown
{
    [OSInterface(Description = "Facilitates conversion from HTML to Markdown and vice versa.", Name = "HTMLMarkdownConverter")]
    public interface IHTMLMarkdownConverter
    {
        [OSAction(Description = "Converts HTML to Markdown.", ReturnName = "Markdown", ReturnType = OSDataType.Text)]
        public string HTMLToMarkdown(
            [OSParameter(DataType = OSDataType.Text, Description = "The HTML which needs to be converted to Markdown")] string HTML);

        [OSAction(Description = "Converts Markdown to HTMl.", ReturnName = "HTML", ReturnType = OSDataType.Text)]
        public string MarkdownToHTML(
            [OSParameter(DataType = OSDataType.Text, Description = "The Markdown which needs to be converted to HTML")] string Markdown);

        [OSAction(Description = "Converts HTML to JiraMarkdown.", ReturnName = "JiraMarkdown", ReturnType = OSDataType.Text)]
        public string HTMLToJiraMarkdown(
            [OSParameter(DataType = OSDataType.Text, Description = "The HTML which needs to be converted to HTML")] string HTML);
    }
}