using AutoMapper;
using GameMusic.DTOs;
using GameMusic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameMusic.Helpers
{
  public class AutoMapperProfiles: Profile
  {
    public AutoMapperProfiles()
    {
      CreateMap<PagedResults<Customer>, CustomerDTO>();
      CreateMap<Customer, CustomerDTO>();
    }
  }
}
