﻿using Graphql.WebApi.Entities;
using Graphql.WebApi.Interfaces.Repositories;

namespace Graphql.WebApi.Types
{
    public class Query
    {
        public async Task<IQueryable<Book>> GetBook([Service] IBookRepository _repository)
        {
            var result = await _repository.GetAll();
            return result.AsQueryable();
        }
    }
}