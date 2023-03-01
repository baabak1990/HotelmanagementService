using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotlemanagment.Domain.Entity.Common;

namespace Hotlemanagment.Domain.Entity.Entities
{
    public class Hotel:BaseEntity
    {
        public string Name { get; set; }
        public string Rate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }


        #region Relation
       
        public Country Country { get; set; }

        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }

        #endregion
    }
}
