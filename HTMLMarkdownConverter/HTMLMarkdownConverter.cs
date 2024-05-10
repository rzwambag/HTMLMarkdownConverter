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
                UnknownTags = Config.UnknownTagsOption.PassThrough,
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

            // Fix images
            var JiraMarkdown = Regex.Replace(markdown, @"!\[.*?\]\(([^)]+)\)", "!$1!");

            // Fix links
            JiraMarkdown = Regex.Replace(JiraMarkdown, @"\[([^]]+)\]\(([^)]+)\)", "[$1|$2]");

            // Fix underline
            JiraMarkdown = Regex.Replace(JiraMarkdown, @"<u>(.*?)<\/u>", "+$1+");

            // Fix emphasis
            JiraMarkdown = Regex.Replace(JiraMarkdown, @"\s\*{1}(\w+)\*{1}\s", " _$1_ ");

            // Fix bold
            JiraMarkdown = Regex.Replace(JiraMarkdown, @"\s\*{2}(.*?)\*{2}\s", " *$1* ");

            


            return JiraMarkdown;
        }
    }
}