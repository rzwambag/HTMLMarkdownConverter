using Microsoft.VisualStudio.TestTools.UnitTesting;
using HTMLMarkdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLMarkdown.Tests
{
    [TestClass()]
    public class HTMLMarkdownConverterTests
    {
        [TestMethod()]
        public void HTMLToMarkdownTest()
        {
            var converter = new HTMLMarkdownConverter();
            var html = "<div style=\"font-family: -apple-system,BlinkMacSystemFont,Segoe UI,Roboto,Helvetica Neue,Arial,sans-serif; font-size: 14px; \">\r\n" +
                "<div dir=\"ltr\">Test layout</div>\r\n" +
                "<ul>\r\n" +
                "<li dir=\"ltr\"><u>123</u></li>\r\n" +
                "<li dir=\"ltr\" style=\"font-style: italic;\"><em>123</em></li>\r\n" +
                "<li dir=\"ltr\" style=\"font-weight: bold;\"><strong>123</strong></li>\r\n" +
                "</ul>\r\n<div dir=\"ltr\"><br>" +
                "</div>\r\n" +
                "<div dir=\"ltr\"><strong><u>test layout 123</u></strong></div>\r\n" +
                "<img alt=\"Plaatje\" src=\"https://platinumlist.net/guide/wp-content/uploads/2023/03/IMG-worlds-of-adventure.webp\">\r\n" +
                "<a href=\"https://www.transfer-solutions.com\">Transfer Solutions</a>\r\n" +
                "<img src=\"https://platinumlist.net/guide/wp-content/uploads/2023/03/IMG-worlds-of-adventure.webp\">\r\n" +
                "</div>";

            var markdown = converter.HTMLToMarkdown(html);
            Console.WriteLine("HTML input:");
            Console.WriteLine(html);
            Console.WriteLine("----------");
            Console.WriteLine("Markdown output:");
            Console.WriteLine(markdown);
        }

        [TestMethod()]
        public void MarkdownToHTMLTest()
        {
            var converter = new HTMLMarkdownConverter();
            var markdown = "Test layout\r\n\r\n- 123\r\n- *123*\r\n- **123**\r\n\r\n**test layout 123**\r\n\r\n![Plaatje](https://platinumlist.net/guide/wp-content/uploads/2023/03/IMG-worlds-of-adventure.webp)\r\n[Transfer Solutions](https://www.transfer-solutions.com)\r\n";
            var html = converter.MarkdownToHTML(markdown);

            Console.WriteLine("Markdown input:");
            Console.WriteLine(markdown);
            Console.WriteLine("----------");
            Console.WriteLine("HTML output:");
            Console.WriteLine(html);
        }

        [TestMethod()]
        public void HTMLToJiraMarkdownTest()
        {
            var converter = new HTMLMarkdownConverter();
            var html = "<div style=\"font-family: -apple-system,BlinkMacSystemFont,Segoe UI,Roboto,Helvetica Neue,Arial,sans-serif; font-size: 14px; \">\r\n" +
                "<div dir=\"ltr\">Test layout</div>\r\n" +
                "<ul>\r\n" +
                "<li dir=\"ltr\"><u>Onderstreept</u></li>\r\n" +
                "<li dir=\"ltr\" style=\"font-style: italic;\"><em>Cursief</em></li>\r\n" +
                "<li dir=\"ltr\" style=\"font-weight: bold;\"><strong>Vet</strong></li>\r\n" +
                "</ul>\r\n<div dir=\"ltr\"><br>" +
                "</div>\r\n" +
                "<div dir=\"ltr\"><strong><u>test layout 123</u></strong></div>\r\n" +
                "<img alt=\"Plaatje\" src=\"https://platinumlist.net/guide/wp-content/uploads/2023/03/IMG-worlds-of-adventure.webp\">\r\n" +
                "<a href=\"https://www.transfer-solutions.com\">Transfer Solutions</a>\r\n" +
                "<img src=\"https://platinumlist.net/guide/wp-content/uploads/2023/03/IMG-worlds-of-adventure.webp\">\r\n" +
                "</div>";

            html = "<div><strong>Vet</strong></div>\r\n<div><em>Cursief</em></div>\r\n<div><u>Onderstreept</u></div>";

            var JiraMarkdown = converter.HTMLToJiraMarkdown(html);
            Console.WriteLine("HTML input:");
            Console.WriteLine(html);
            Console.WriteLine("----------");
            Console.WriteLine("JiraMarkdown output:");
            Console.WriteLine(JiraMarkdown);
        }
    }
}