using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg.Dtos.Web
{
    public class Paging
    {
        public Paging(int Page,int Size,string SortField,string SortOrder)
        {

            this.Page=Page;
            this.Size=Size;
            this.SortField=SortField;
            this.SortOrder=SortOrder;
        }
        public int Page { get; set; } = 0;
        public int Size { get; set; }= 10;
        public string SortField { get; set; } = string.Empty;
        public string SortOrder { get; set; } = Enum.GetName(Direction.ASC);
    }
}