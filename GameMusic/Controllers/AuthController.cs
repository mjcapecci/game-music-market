using GameMusic.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameMusic.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    string clientId = ConfigurationManager.AppSettings["GitHub:Client_Id"];

    string clientSecret = ConfigurationManager.AppSettings["GitHub:Client_Secret"];
    readonly GitHubClient client =
        new GitHubClient(new ProductHeaderValue("Game_Music_API"), new Uri("https://github.com/"));
  }
}
