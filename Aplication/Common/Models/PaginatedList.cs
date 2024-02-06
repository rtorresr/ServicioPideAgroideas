using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class PaginatedList<T>
    {
        public List<T> Data { get; }
        public int Page { get; }
        public int Size { get; }
        public int Total { get; }
        public int TotalPages { get; }

        public PaginatedList(List<T> _data, int _page, int _size, int _total)
        {
            Data = _data;
            Page = _page;
            Size = _size;
            Total = _total;
            TotalPages = (int)Math.Ceiling(_total / (double)_size);            
        }

        public bool HasPreviousPage => Page > 0;

        public bool HasNextPage => Page < TotalPages - 1;
    }
}
