using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameMusic.Entities.ShopifyAPI;
using GameMusic.Helpers;
using Newtonsoft.Json;
using RestSharp;

namespace GameMusic.Services
{
  public class ShopifyService
  {

    private IRestClient client;
    private IRestRequest request;
    private string postUrl = ConfigurationManager.AppSettings["Shopify:Shopify_Endpoint"];


    public async Task<ShopifyRoot> QueryAPI(string query)
    {
      client = new RestClient();
      client.Authenticator = new RestSharp.Authenticators.HttpBasicAuthenticator(
        ConfigurationManager.AppSettings["Shopify:Shopify_API_Key"],  
        ConfigurationManager.AppSettings["Shopify:Shopify_API_Password"]  
      );

      request = new RestRequest()
      {
        Method = Method.POST,
        Resource = postUrl
      };

      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Access-Control-Origin", "*");
      request.AddJsonBody(new { 
        query
      });

      var response = await client.ExecuteAsync(request);
      return JsonConvert.DeserializeObject<ShopifyRoot>(response.Content);
    }
  }
}
