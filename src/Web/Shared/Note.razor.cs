using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;

using Microsoft.AspNetCore.Components;

using NoteDotNet.Abstractions;

namespace NoteDotNet.Web.Shared
{
    public class NoteComponentBase : ComponentBase
    {
        [Parameter]
        public NoteModel Note { get; set; }

        [Parameter]
        public EventCallback<NoteModel> OnEditClicked { get; set; }

        [Parameter]
        public EventCallback<NoteModel> OnDeleteClicked { get; set; }

        protected MarkupString HtmlContent
        {
            get
            {
                var content = Note?.Content;
                if (content == null)
                {
                    return default;
                }

                using var sr = new StringReader(content);
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
        }

        protected void EditClicked()
        {
            OnEditClicked.InvokeAsync(Note);
        }

        protected void DeleteClicked()
        {
            OnDeleteClicked.InvokeAsync(Note);
        }

        private static string WrapString(string tag, string value)
        {
            return $"<{tag}>{HtmlEncoder.Default.Encode(value ?? string.Empty)}</{tag}>";
        }
    }
}
