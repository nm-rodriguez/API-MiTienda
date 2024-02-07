﻿using MiTienda.Application.Contracts;
using MiTienda.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiTienda.Application.Services
{
    public class QueryService<T> : IQueryService<T>
    {
        private IRepository<T> _repository;

        public QueryService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public  IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<T> GetBy(Expression<Func<T, bool>> filter)
        {
            return _repository.GetBy(filter);
        }

    }
}