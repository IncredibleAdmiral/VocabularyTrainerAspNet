using System;
using System.Collections.Generic;

namespace VocabularyNetCore.Models.ApproximatingСlasses
{
    public partial class WordsTable
    {
        public WordsTable()
        {
            ContextTable = new HashSet<ContextTable>();
            PriorityTable = new HashSet<PriorityTable>();
        }

        public int IdWord { get; set; }
        public string Word { get; set; }
        public string WordTranslation { get; set; }
        public string PartOfSpeech { get; set; }

        public virtual IrregularVerbsTable IrregularVerbsTable { get; set; }
        public virtual ICollection<ContextTable> ContextTable { get; set; }
        public virtual ICollection<PriorityTable> PriorityTable { get; set; }
    }
}
