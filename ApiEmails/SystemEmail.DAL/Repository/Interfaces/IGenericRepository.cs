﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SystemEmail.DAL.Repository.Interfaces
{
    public interface IGenericRepository<TModel> where TModel : class
    {

        Task<TModel> Get(Expression<Func<TModel, bool>> filter); 
        Task<TModel> Create(TModel model); 
        Task<bool> Edit(TModel model);
        Task<bool> Delete(TModel model);
        Task<IQueryable<TModel>> Query(Expression<Func<TModel, bool>> filter = null);
        


        



    }
}
