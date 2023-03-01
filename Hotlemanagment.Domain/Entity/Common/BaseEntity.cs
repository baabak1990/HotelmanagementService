using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotlemanagment.Domain.Entity.Common
{
    public partial class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }= DateTime.Now;
        public string? CreationNote { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string? ModificationNote { get; set; }

    }
}
