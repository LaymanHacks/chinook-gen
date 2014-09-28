using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.Web
{
    public class PagedResult<T>
    {
        public ICollection<T> Results { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public string PrevPageLink { get; set; }
        public string NextPageLink { get; set; }
    }
}
