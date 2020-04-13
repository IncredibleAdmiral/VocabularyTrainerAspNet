using System;
using System.Collections.Generic;

namespace VocabularyNetCore.Models.ApproximatingСlasses
{
    public partial class UsersTable
    {
        public UsersTable()
        {
            PriorityTable = new HashSet<PriorityTable>();
        }

        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<PriorityTable> PriorityTable { get; set; }
    }
}
