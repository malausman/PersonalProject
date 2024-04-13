using Dapper;
using Microsoft.Extensions.Configuration;
using PersonalProject.Domain;
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
    public class PostRepository : IPostRepository
    {

        private readonly IConfiguration configuration;
        public PostRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(Posts entity)
        {
            try
            {
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("Id", entity.Id);
                    parameters.Add("UserId", entity.UserId);
                    parameters.Add("Message", entity.Message);
                    parameters.Add("DateTimeUtc", entity.DateTimeUtc);
                    var result = await connection.ExecuteAsync("sp_CreatePost", parameters, commandType: System.Data.CommandType.StoredProcedure);
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

        

        Task<int> IRepository<Posts>.AddAsync(Posts entity)
        {
            throw new NotImplementedException();
        }

        Task<int> IRepository<Posts>.DeleteAsync(string id, int RefreshTokenID)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Posts>> IRepository<Posts>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Posts> IRepository<Posts>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<int> IRepository<Posts>.UpdateAsync(Posts entity)
        {
            throw new NotImplementedException();
        }
    }
}
