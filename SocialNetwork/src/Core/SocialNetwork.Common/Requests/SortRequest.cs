using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.Common.Requests
{
    public class SortRequest
    {
        public string Field { get; set; }
        public bool IsAsc { get; set; }

        public static string BuildSortString(IEnumerable<SortRequest> sorts)
        {
            if (sorts == null || !sorts.Any())
            {
                return string.Empty;
            }

            var stringList = new List<string>();

            foreach (var sortItem in sorts)
            {
                stringList.Add($"{sortItem.Field} {(sortItem.IsAsc ? "ASC" : "DESC")}");
            }

            return string.Join(", ", stringList);
        }
    }
}
