using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GameMusic.Entities.ShopifyAPI
{
  public class Shop
  {

    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("id")]
    public string Id { get; set; }
  }
}
