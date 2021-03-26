using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GameMusic.Entities.ShopifyAPI
{
  public class ShopifyRoot
  {
    public class Root
    {
      public Shop Shop { get; set; }
    }

    [JsonProperty("data")]
    public Root Data { get; set; }
  }
}
