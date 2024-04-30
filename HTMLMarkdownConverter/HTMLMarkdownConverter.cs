using Markdig;
using ReverseMarkdown;

namespace HTMLMarkdown
{
    public class HTMLMarkdownConverter : IHTMLMarkdownConverter
    {
        public string HTMLToMarkdown(string html)
        {
            var config = new ReverseMarkdown.Config
            {
                // Include the unknown tag completely in the result (default as well)
                UnknownTags = Config.UnknownTagsOption.Bypass,
                // generate GitHub flavoured markdown, supported for BR, PRE and table tags
                GithubFlavored = true,
                // will ignore all comments
                RemoveComments = true,
                // remove markdown output for links where appropriate
                SmartHrefHandling = true
            };

            var converter = new ReverseMarkdown.Converter(config);
            return converter.Convert(html);            
        }

        public string MarkdownToHTML(string markdown)
        {
            var pipeline = new MarkdownPipelineBuilder().Build();
            return Markdown.ToHtml(markdown, pipeline);
        }
    }
}