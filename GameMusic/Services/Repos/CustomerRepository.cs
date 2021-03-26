using AutoMapper;
using Dapper;
using Dapper.Contrib.Extensions;
using GameMusic.DTOs;
using GameMusic.Entities;
using GameMusic.Helpers;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GameMusic.Services.Repos
{
  public class CustomerRepository : ICustomerRepository
  {
    private readonly IConfiguration _config;
    private readonly IMapper _mapper;

    public CustomerRepository(IConfiguration config, IMapper mapper)
    {
      _config = config;
      _mapper = mapper;
    }

    public IDbConnection Connection
    {
      get
      {
        return new NpgsqlConnection(_config.GetConnectionString("Default"));
      }
    }
    
    public async Task<PagedResults<CustomerDTO>> GetAll(int page, int recordsPerPage)
    {

      var results = new PagedResults<CustomerDTO>();

      using (IDbConnection conn = Connection)
      {
        string query = "SELECT * FROM Customers OFFSET @Offset ROWS FETCH FIRST @PageSize ROW ONLY; SELECT COUNT(*) FROM Customers";
        conn.Open();
        using (var multi = await Connection.QueryMultipleAsync(query, new { Offset = (page - 1) * recordsPerPage, PageSize = recordsPerPage }))
        {
          var customers = multi.Read<Customer>().ToList();

          results.Items = _mapper.Map<IEnumerable<CustomerDTO>>(customers);

          results.TotalCount = multi.ReadFirst<int>();
        }
        return results;
      }
    }

    public async Task<int> GetCount()
    {
      using (IDbConnection conn = Connection)
      {
        string query = "SELECT COUNT(*) FROM Customers";
        conn.Open();
        var result = await conn.QueryAsync<int>(query);
        return result.Single();
      }
    }

    public async Task<Customer> GetByID(int id)
    {
      using (IDbConnection conn = Connection)
      {
        string query = "SELECT * FROM Customers WHERE id = @ID";
        conn.Open();
        var result = await conn.QueryAsync<Customer>(query, new { ID = id });
        return result.FirstOrDefault();
      }
    }

    public async Task<Customer> AddNew(Customer model)
    {
      using (IDbConnection conn = Connection)
      {
        string query = "SELECT * FROM Customers WHERE github_account = @GithubAccount";
        conn.Open();

        var newCustomer = new Customer
        {
          github_account = model.github_account,
          shopify_customer_id = model.shopify_customer_id,
          created_at = DateTime.Now.ToUniversalTime(),
          last_login = DateTime.Now.ToUniversalTime()
        };

        await Connection.InsertAsync(newCustomer);

        var queryResult = await conn.QueryAsync<Customer>(query, new { GithubAccount = model.github_account });
        return queryResult.FirstOrDefault();
      }
    }
  }
}
