using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemEmail.DAL.DBContext;
using SystemEmail.DAL.Repository.Interfaces;
using SystemEmail.Model;


namespace SystemEmail.DAL.Repository
{
    public class EmailRepository : GenericRepository<Email>, IEmailRepository
    {


        private readonly DbemailContext _dbemailContext;

        public EmailRepository(DbemailContext dbemailContext) : base (dbemailContext)
        {
            _dbemailContext = dbemailContext;
        }

        public async Task<Email> SaveEmail(Email email)
        {
            Email emailCreated = new Email();


            using (var transaction = _dbemailContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (DetailEmail item in email.DetailEmails)
                    {

                        Client client = _dbemailContext.Clients.Where(p => p.IdClient==item.IdClient).First();

                        client.Email = email.DetailEmails + client.Email;

                        _dbemailContext.Clients.Update(client); 
                    }

                    await _dbemailContext.SaveChangesAsync();

                    SpecialId specialNumber = _dbemailContext.SpecialIds.First();

                    specialNumber.LastSpecialId += 1;
                    specialNumber.DateLog = DateTime.Now;

                   _dbemailContext.SpecialIds.Update(specialNumber);

                   await _dbemailContext.SaveChangesAsync();

                    int digits = 4;
                    string zero = string.Concat(Enumerable.Repeat("0", digits));

                    string emailNumber = zero + specialNumber.LastSpecialId.ToString();

                    emailNumber = emailNumber.Substring(emailNumber.Length - digits);

                    email.SpecialId = emailNumber;

                    await _dbemailContext.Emails.AddAsync(email);
                    await _dbemailContext.SaveChangesAsync();

                    emailCreated = email;

                    transaction.Commit();


                }
                catch (Exception)
                {
                    transaction.Rollback();

                    throw;

                }

                return emailCreated;

            }




        }
    }
}
