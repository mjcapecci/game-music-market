using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameMusic.Helpers
{
  public class PagedResults<T>
  {
    public IEnumerable<T> Items { get; set; }
    public int TotalCount { get; set; }
  }
}
