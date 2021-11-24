using System;
using System.Collections.Generic;

namespace SocialNetwork.Common.Responses
{
    public class PagingResponse<TData>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((decimal)TotalItems / PageSize);
            }
        }
        public int TotalItems { get; set; }
        public IEnumerable<TData> Data { get; set; }
    }
}
