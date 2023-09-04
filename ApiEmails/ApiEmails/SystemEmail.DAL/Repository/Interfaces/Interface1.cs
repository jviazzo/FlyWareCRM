using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemEmail.Model;

namespace SystemEmail.DAL.Repository.Interfaces
{
    public interface IEmailRepository : IGenericRepository<Email>
    {

        Task<Email> SaveEmail(Email email);







    }
}
