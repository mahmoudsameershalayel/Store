using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.APIDto.Paging
{
    public class ApiPagingDto
    {
        public ApiPagingDto()
        {

        }
        public ApiPagingDto(int page , int pageSize)
        {
            CurrentPage = page;
            PageSize = pageSize;
        }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }       
    }
}
