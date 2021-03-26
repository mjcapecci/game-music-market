using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace GameMusic.Helpers
{
  static class ConfigurationManager
  {
    public static IConfiguration AppSettings { get; }
    static ConfigurationManager()
    {
      AppSettings = new ConfigurationBuilder()
        .SetBasePath(Directory
        .GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
    }
  }
}
