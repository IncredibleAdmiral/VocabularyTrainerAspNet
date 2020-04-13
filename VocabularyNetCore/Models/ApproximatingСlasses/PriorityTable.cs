using System;
using System.Collections.Generic;

namespace VocabularyNetCore.Models.ApproximatingСlasses
{
    public partial class PriorityTable
    {
        public int IdUser { get; set; }
        public int IdWord { get; set; }
        public int Correctly { get; set; }
        public int Uncorrectly { get; set; }

        public virtual UsersTable IdUserNavigation { get; set; }
        public virtual WordsTable IdWordNavigation { get; set; }
    }
}
