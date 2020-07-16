using System;
using System.Collections.Generic;

namespace NoteDotNet.Abstractions
{
    public class NoteModel
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public string Content { get; set; }

        public ISet<string> Tags { get; set; } = new HashSet<string>();
    }
}
