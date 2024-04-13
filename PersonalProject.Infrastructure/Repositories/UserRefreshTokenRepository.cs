using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PersonalProject.Domain.Entities;
using PersonalProject.Domain.Repositories;

namespace PersonalProject.Infrastructure.Repositories
{
    public class UserRefreshTokenRepository:IUserRefreshTokenRepository
    {
        private readonly IConfiguration configuration;
        public UserRefreshTokenRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(UserRefreshToken entity)
        {
            var sql = "Insert into UserRefreshToken (UserId,Token,RefreshTokenExpiry) VALUES (@UserId,@Token,@RefreshTokenExpiry)";
            var sql1 = "Select id from UserRefreshToken where UserId=@UserId and Token=@Token and RefreshTokenExpiry=@RefreshTokenExpiry";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                var result1 = await connection.QuerySingleAsync<int>(sql1, entity);
                return result1;
            }

        }
        public async Task<int> DeleteAsync(string userid,int RefreshTokenID)
        {
            var sql = "DELETE FROM UserRefreshToken WHERE UserId ='"+userid +"' and Id="+RefreshTokenID;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql);
                return result;
            }
        }

        public async Task<IEnumerable<UserRefreshToken>> GetAllAsync()
        {
            var sql = "SELECT * FROM UserRefreshToken";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<UserRefreshToken>(sql);
                return result;
            }
        }

        public async Task<UserRefreshToken> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM UserRefreshToken WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<UserRefreshToken>(sql, new { Id = id });
                return result;
            }
        }
        public async Task<UserRefreshToken> GetUserRefreshToken(string UserId,int RefreshTokenID)
        {
            var sql = "SELECT * FROM UserRefreshToken WHERE UserId ='" + UserId + "' and Id=" + RefreshTokenID;
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<UserRefreshToken>(sql);
                return result;
            }
        }
        public async Task<bool> IsUserRefreshTokenExist(string UserId)
        {
            var sql = "SELECT top 1 * FROM UserRefreshToken WHERE UserId = @UserId order by RefreshTokenExpiry desc";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<UserRefreshToken>(sql, new { UserId = UserId });
                return result == null ? false : true;
            }
        }

        public async Task<int> UpdateAsync(UserRefreshToken entity)
        {
            var sql = "UPDATE UserRefreshToken SET Token = @Token  WHERE UserId = @UserId and Id=@Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}
