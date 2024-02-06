using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class PaginatedListEntity<TEntity> where TEntity : class
    {
        public List<TEntity> Data { get; set; }
        public int Total { get; set; }
    }
}
