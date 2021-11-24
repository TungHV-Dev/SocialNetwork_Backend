using System.Collections.Generic;

namespace SocialNetwork.Common.Requests
{
    public class BasePagingRequest
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }

    public class PagingRequest : BasePagingRequest
    {
        public string Search { get; set; }
        public IEnumerable<SortRequest> Sorts { get; set; } = new List<SortRequest>();
        public IEnumerable<FilterRequest> Filters { get; set; } = new List<FilterRequest>();

        public static string CleanSearchString(string search)
        {
            if (string.IsNullOrEmpty(search))
                return string.Empty;

            //Escape character in search %LIKE%
            return search.Replace(@"'", @"['''']").Replace(@"%", @"[%]").Trim();
        }
    }
}
