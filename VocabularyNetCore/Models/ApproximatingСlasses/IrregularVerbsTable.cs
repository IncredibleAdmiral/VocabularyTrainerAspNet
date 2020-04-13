using System;
using System.Collections.Generic;

namespace VocabularyNetCore.Models.ApproximatingСlasses
{
    public partial class IrregularVerbsTable
    {
        public int IdWord { get; set; }
        public string PastSimple { get; set; }
        public string PastParticiple { get; set; }

        public virtual WordsTable IdWordNavigation { get; set; }
    }
}
