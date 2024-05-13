using System.Text.RegularExpressions;
using Markdig;
using OutSystems.ExternalLibraries.SDK;
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
            
            return converter.Convert(html); ;
        }

        public string MarkdownToHTML(string markdown)
        {
            var pipeline = new MarkdownPipelineBuilder().Build();
            return Markdown.ToHtml(markdown, pipeline);
        }

    
        public string HTMLToJiraMarkdown(string html)
        {
            var markdown = HTMLToMarkdown(html);
            var JiraMarkdown = markdown;

            // Fix images
            JiraMarkdown = Regex.Replace(markdown, @"!\[.*?\]\(([^)]+)\)", "!$1!");

            // Fix links
            JiraMarkdown = Regex.Replace(JiraMarkdown, @"\[([^]]+)\]\(([^)]+)\)", "[$1|$2]");

            // Fix emphasis
            JiraMarkdown = Regex.Replace(JiraMarkdown, @"([^*])?\*{1}(\w+)\*{1}([^*])", "$1_$2_$3");

            // Fix bold
            JiraMarkdown = Regex.Replace(JiraMarkdown, @"([^*])?\*{2}(.*?)\*{2}([^*])", "$1*$2*$3");

            return JiraMarkdown;
        }
    }
}