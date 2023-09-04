using System.Linq.Expressions;
using SystemEmail.DAL.DBContext;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SystemEmail.DAL.Repository.Interfaces
{


    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {

        private readonly DbemailContext _dbcontext;

        public GenericRepository(DbemailContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<TModel> Get(Expression<Func<TModel, bool>> filter)
        {
            try
            {
                TModel model = await _dbcontext.Set<TModel>().FirstOrDefaultAsync(filter);
                return model;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<TModel> Create(TModel model)
        {
            try
            {
                _dbcontext.Set<TModel>().Add(model);
                await _dbcontext.SaveChangesAsync();
                return model;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<bool> Edit(TModel model)
        {
            try
            {
                _dbcontext.Set<TModel>().Update(model);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<bool> Delete(TModel model)
        {
            try
            {
                _dbcontext.Set<TModel>().Remove(model);
                await _dbcontext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IQueryable<TModel>> Query(Expression<Func<TModel, bool>> filter = null)
        {
            IQueryable<TModel> queryModel = filter == null? _dbcontext.Set<TModel>() : _dbcontext.Set<TModel>().Where(filter);
            return queryModel;
        }
    }



}
