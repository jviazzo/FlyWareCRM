using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using SystemEmail.BLL.Services.Interfaces;
using SystemEmail.DAL.Repository.Interfaces;
using SystemEmail.DTO;
using SystemEmail.Model;

namespace SystemEmail.BLL.Services
{
    public class EmailService : IEmailService
    {


        private readonly IGenericRepository<Email> _emailRepository;
        private readonly IGenericRepository<DetailEmail> _detailEmailRepository;
        private readonly IMapper _mapper;

        public EmailService(IGenericRepository<Email> emailRepository, IGenericRepository<DetailEmail> detailEmailRepository, IMapper mapper)
        {
            _emailRepository = emailRepository;
            _detailEmailRepository = detailEmailRepository;
            _mapper = mapper;
        }

        public async Task<EmailDTO> Save(EmailDTO model)
        {
            try
            {
                var modelEmail = _mapper.Map<Email>(model);
                var emailCreate = await _emailRepository.Create(modelEmail);

                if (emailCreate.IdEmail == 0)
                {
                    throw new TaskCanceledException("Email could not be created");
                }

                return _mapper.Map<EmailDTO>(emailCreate);

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<EmailDTO>> EmailLog(string searchBy, string SpecialIdEmail, string dateIni, string dateEnd)
        {
            IQueryable<Email> query = await _emailRepository.Query();
            var listResult = new List<Email>();

            try
            {
    
                CultureInfo culture = new CultureInfo("es-AR");

                if (searchBy == "date")
                {
                    DateTime dateStart = DateTime.ParseExact(dateIni, "dd/MM/yyyy", culture);
                    DateTime dateFinish = DateTime.ParseExact(dateEnd, "dd/MM/yyyy", culture);

                    listResult = await query.Where(x =>
                    x.DateLog >= dateStart.Date && x.DateLog <= dateFinish.Date).Include(x => x.DetailEmails)
                    .ThenInclude(p => p.IdClientNavigation).ToListAsync();

                }
                else
                {
                    listResult = await query.Where(x =>
                    x.SpecialId == SpecialIdEmail).Include(x => x.DetailEmails)
                    .ThenInclude(p => p.IdClientNavigation).ToListAsync();

                }



            }
            catch (Exception)
            {
                throw;
            }


            return _mapper.Map<List<EmailDTO>>(listResult);

        }



        public async Task<List<ReportDTO>> Report(string dateIni, string dateEnd)
        {
                IQueryable<DetailEmail> query = await _detailEmailRepository.Query();
                var listResult = new List<DetailEmail>();
                CultureInfo culture = new CultureInfo("es-AR");

            try
            {
                DateTime dateStart = DateTime.ParseExact(dateIni, "dd/MM/yyyy", culture);
                DateTime dateFinish = DateTime.ParseExact(dateEnd, "dd/MM/yyyy", culture);

                listResult = await query
                .Include(x => x.IdClientNavigation)
                .Include(x => x.IdEmailNavigation)
                .Where(x => x.IdEmailNavigation.DateLog.Value.Date >= dateStart.Date &&
                x.IdEmailNavigation.DateLog.Value.Date <= dateFinish.Date).ToListAsync();

            }
            catch (Exception)
            {
                throw;
            }

            return _mapper.Map<List<ReportDTO>>(listResult);

        }


    }
}
