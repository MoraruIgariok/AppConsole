using System;
using System.Collections.Generic;

namespace DepozitApp
{
    public partial class Command
    {
        public int Id { get; set; }
        public bool? Import { get; set; }
        public bool? Export { get; set; }
        public int? CommandId { get; set; }
        public int? CountProdus { get; set; }
        public DateTime? DataChange { get; set; }

        public virtual Produ? CommandNavigation { get; set; }
    }
}
