using System;
using System.Collections.Generic;

namespace VocabularyNetCore.Models.ApproximatingСlasses
{
    public partial class ExamplesTable
    {
        public ExamplesTable()
        {
            ContextTable = new HashSet<ContextTable>();
        }

        public int IdExample { get; set; }
        public string Example { get; set; }
        public string ExampleTranslation { get; set; }

        public virtual ICollection<ContextTable> ContextTable { get; set; }
    }
}
