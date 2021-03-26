using GameMusic.DTOs;
using GameMusic.Entities;
using GameMusic.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameMusic.Services
{
  public interface ICustomerRepository
  {
    Task<PagedResults<CustomerDTO>> GetAll(int page, int recordsPerPage);
    Task<int> GetCount();
    Task<Customer> GetByID(int id);
    Task<Customer> AddNew(Customer model);
  }
}
