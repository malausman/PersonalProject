using Dapper;
using Microsoft.Extensions.Configuration;
using PersonalProject.Domain.Entities;
using PersonalProject.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly IConfiguration configuration;
        public UserRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(userInfo entity)
        {
            try
            {
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("name", entity.name);
                    parameters.Add("password", entity.password);
                    parameters.Add("email", entity.email); 
                    var result = await connection.ExecuteAsync("sp_CreateUser", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Task<int> DeleteAsync(string id, int RefreshTokenID = 0)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<userInfo>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<userInfo> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<userInfo> RegisterUser(userInfo userInfo)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(userInfo entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
