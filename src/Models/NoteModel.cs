﻿using System;
using System.Collections.Generic;

namespace KwokKan.NoteDotNet.Models
{
    public class NoteModel
    {
        public int Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public string Content { get; set; }

        public ICollection<int> TagIds { get; set; }
    }
}
