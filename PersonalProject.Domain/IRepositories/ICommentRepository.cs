using PersonalProject.Domain;
using PersonalProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalProject.Domain.IRepositories
{
    public  interface ICommentRepository: IRepository<Comment>
    {
        Task<int> AddAsync(Comment data);
    }
}
