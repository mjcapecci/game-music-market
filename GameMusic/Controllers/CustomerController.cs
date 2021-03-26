using AutoMapper;
using GameMusic.DTOs;
using GameMusic.Entities;
using GameMusic.Services;
using GameMusic.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameMusic.Entities.ShopifyAPI;

namespace GameMusic.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomerController : ControllerBase
  {
    private readonly ICustomerRepository _customerRepo;
    private readonly IMapper _mapper;

    public CustomerController(ICustomerRepository customerRepo, IMapper mapper)
    {
      _customerRepo = customerRepo;
      _mapper = mapper;
    }

    [HttpGet]
    [Route("list")]
    public async Task<ActionResult<PagedResults<CustomerDTO>>> Get([FromQuery] PaginationDTO pagination)
    {
      var customers = await _customerRepo.GetAll(pagination.Page, pagination.RecordsPerPage);
      ShopifyService shopify = new ShopifyService();
      var result = (shopify.QueryAPI(ShopifyQueryStrings.GetShop));
      Console.WriteLine(result);
      return customers;
    }

    [HttpPost]
    public async Task<ActionResult<Customer>> Post([FromBody] Customer model)
    {
      return await _customerRepo.AddNew(model);
    }
  }
}
