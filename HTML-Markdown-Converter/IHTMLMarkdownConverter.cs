using OutSystems.ExternalLibraries.SDK;

namespace HTMLMarkdown
{
    [OSInterface]
    public interface IHTMLMarkdownConverter
    {
        public string HTMLToMarkdown(string html);
        public string MarkdownToHTML(string markdown);
    }
}