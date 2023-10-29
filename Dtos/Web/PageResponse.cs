using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg.Dtos.Web
{
    public class PageResponse<T>
    {
        public PageResponse(List<T> Content,int TotalNumber,int PageCount)
        {
            this.Content=Content;
            this.TotalNumber=TotalNumber;
            this.PageCount=PageCount;
        }
        public List<T> Content { get; set; } = new List<T>();

        public int TotalNumber { get; set; }

        public int PageCount { get; set; }
    }
}