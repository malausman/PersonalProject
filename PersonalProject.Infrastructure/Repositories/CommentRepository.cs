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
    public class CommentRepository : ICommentRepository
    {

        private readonly IConfiguration configuration;
        public CommentRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(Comment entity)
        {
            try
            {
       
                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("Id", entity.Id);
                    parameters.Add("UserId", entity.UserId);
                    parameters.Add("DateTimeUtc", entity.DateTimeUtc);
                    parameters.Add("Post", entity.Post);
                   // parameters.Add("_likes", entity._likes);
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

        public Task<int> UpdateAsync(Comment entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Comment>> IRepository<Comment>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Comment> IRepository<Comment>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
