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
    public class BugsRepository : IBugsRepository
    {

        private readonly IConfiguration configuration;
        public BugsRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<int> AddAsync(Bugs entity)
        {
            try
            {

                using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("Requirement_id", entity.Requirement_id);
                    parameters.Add("Title", entity.Title);
                    parameters.Add("Priority", entity.Priority);
                    parameters.Add("Status", entity.Status);
                    parameters.Add("Severity", entity.Severity);
                    parameters.Add("Resolution", entity.Resolution);
                    parameters.Add("OperatingSystem", entity.OperatingSystem);
                    parameters.Add("WhereFound", entity.WhereFound);
                    parameters.Add("IdentifiedDate", entity.IdentifiedDate);
                    parameters.Add("OperatingSystem", entity.OperatingSystem);
                    parameters.Add("ReportedBy", entity.ReportedBy);
                    parameters.Add("Description", entity.Description);

                    var result = await connection.ExecuteAsync("sp_CreateBugs", parameters, commandType: System.Data.CommandType.StoredProcedure);
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

        public Task<int> UpdateAsync(Bugs entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Bugs>> IRepository<Bugs>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Bugs> IRepository<Bugs>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
