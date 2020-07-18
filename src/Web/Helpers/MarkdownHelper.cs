using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;

using Microsoft.AspNetCore.Components;

namespace NoteDotNet.Web.Helpers
{
    public static class MarkdownHelper
    {
        public static MarkupString ToHtml(string markdown)
        {
            if (markdown == null)
            {
                return default;
            }

            using var sr = new StringReader(markdown);
            var lines = new List<string>();

            string currentLine;

            while ((currentLine = sr.ReadLine()) != null)
            {
                var ln = currentLine.Split(" ", 2);
                var tag = ln[0];
                var value = ln.Length == 2 ? ln[1] : null;

                switch (tag)
                {
                    case "######":
                    case "#####":
                    case "####":
                    case "###":
                    case "##":
                    case "#":
                        currentLine = WrapString("h" + tag.Length, value);
                        break;
                    case "---":
                        currentLine = "<hr />";
                        break;
                    default:
                        currentLine = WrapString("p", currentLine);
                        break;
                }

                lines.Add(currentLine);
            }

            return (MarkupString)string.Join("\n", lines);
        }

        private static string WrapString(string tag, string value)
        {
            return $"<{tag}>{HtmlEncoder.Default.Encode(value ?? string.Empty)}</{tag}>";
        }
    }
}
