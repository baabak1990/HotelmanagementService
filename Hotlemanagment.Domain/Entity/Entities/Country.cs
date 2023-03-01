using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotlemanagment.Domain.Entity.Common;

namespace Hotlemanagment.Domain.Entity.Entities
{
    public class Country:BaseEntity
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
