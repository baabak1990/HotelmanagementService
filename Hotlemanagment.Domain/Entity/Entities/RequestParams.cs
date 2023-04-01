using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotlemanagment.Domain.Entity.Entities
{
    public class RequestParams
    {
        //We Create This Class Az Model for Paging usage
        //Important : We use This Properties for XPAGEDLIST Libraries 
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;

        //We encapsulate To prevent Any mistake !!!
        public int pageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
            }
        }

    }
}
