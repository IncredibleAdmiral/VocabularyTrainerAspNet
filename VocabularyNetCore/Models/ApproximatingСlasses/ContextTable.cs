﻿using System;
using System.Collections.Generic;

namespace VocabularyNetCore.Models.ApproximatingСlasses
{
    public partial class ContextTable
    {
        public int IdWord { get; set; }
        public int IdExample { get; set; }
        public string ContextualTranslation { get; set; }

        public virtual ExamplesTable IdExampleNavigation { get; set; }
        public virtual WordsTable IdWordNavigation { get; set; }
    }
}
