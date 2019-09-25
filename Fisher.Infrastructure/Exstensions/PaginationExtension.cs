using System.Linq;
using Fisher.Core.Utilities;

namespace Fisher.Infrastructure.Exstensions
{
    public static class PaginationExtension
    {
        public static IQueryable<T> GetPage<T>(this IQueryable<T> query, PaginationRequest page)
        {
            return query.Skip((page.NumberOfPage - 1) * page.Size).Take(page.Size);
        }
    }
}