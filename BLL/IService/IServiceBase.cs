﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IService
{
    public interface IServiceBase<TContext, TEntity>
        where TContext : AppDbContext, new()
        where TEntity : class, new()
    {
        List<TEntity> GetAll(TContext context, Expression<Func<TEntity, bool>> filter = null);
        TEntity GetByFilter(TContext context, Expression<Func<TEntity, bool>> filter);
        void AddOrUpdate(TContext context, TEntity entity);
        void Delete(TContext context, Expression<Func<TEntity, bool>> filter);
        void Save(TContext context);
    }
}
