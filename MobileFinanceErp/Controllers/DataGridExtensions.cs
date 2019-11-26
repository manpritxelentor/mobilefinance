using MobileFinanceErp.ViewModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;

namespace MobileFinanceErp.Controllers
{
    public static class DataGridExtensions
    {
        public static DataSourceResult ToDataSourceResult<TSource>(this IQueryable<TSource> sources, DataSourceRequest request)
        {
            DataSourceResult result = ProcessQuery(ref sources, request);
            result.data = sources.ToList();
            return result;
        }

        public static async Task<DataSourceResult> ToDataSourceResultAsync<TSource>(this IQueryable<TSource> sources, DataSourceRequest request)
        {
            DataSourceResult result = ProcessQuery(ref sources, request);
            result.data = await sources.ToListAsync();
            return result;
        }



        private static DataSourceResult ProcessQuery<TSource>(ref IQueryable<TSource> sources, DataSourceRequest request)
        {
            DataSourceResult result = new DataSourceResult
            {
                draw = request.Draw
            };

            // Count after filter and pagination is applied
            result.recordsFiltered = sources.Count();

            // Filter logic goes here
            foreach (var column in request.Columns.Where(w => !string.IsNullOrEmpty(w.Search.Value)))
            {
                if (!string.IsNullOrEmpty(request.Operator) && request.Operator == "cn")
                {
                    sources = sources.Where($"{column.Data}.Contains(@0)", column.Search.Value);
                }
                else
                {
                    sources = sources.Where($"{column.Data} == @0", column.Search.Value);
                }
            }

            // Global Filter Logic
            if (request.Search != null && !string.IsNullOrEmpty(request.Search.Value))
            {
                string whereClause = string.Empty;
                bool isFirstClause = true;
                foreach (var column in request.Columns.Where(w => w.Searchable))
                {
                    if (isFirstClause)
                    {
                        whereClause += $"{column.Data}.Contains(@0)";
                        isFirstClause = false;
                    }
                    else
                    {
                        whereClause += $" or {column.Data}.Contains(@0)";
                    }
                }
                if (!string.IsNullOrEmpty(whereClause))
                {
                    sources = sources.Where(whereClause, request.Search.Value);
                }
            }

            // Count before pagination is applied
            result.recordsTotal = sources.Count();

            // Sorting logic goes here
            if (request.Columns.Count > 0)
            {
                string orderColumnName = request.Columns[request.Order[0].Column].Data;
                string orderDirection = request.Order[0].Dir;

                if (orderDirection == "asc")
                {
                    sources = sources.OrderBy(orderColumnName);
                }
                else
                {
                    sources = sources.OrderBy(orderColumnName + " descending");
                }
            }

            // Apply pagination
            if (request.Length > 0)
            {
                sources = sources.Skip(request.Start).Take(request.Length);
            }

            return result;
        }
    }
}
