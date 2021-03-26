using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameMusic.Entities
{
  public class Customer
  {
    public int id { get; set; }
    public string shopify_customer_id { get; set; }
    public string github_account { get; set; }
    public DateTime created_at { get; set; }
    public DateTime last_login { get; set; }
  }
}
