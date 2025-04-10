﻿namespace DWMS.Inbound.Api.DataAccess.Common;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAll();
    Task<T?> GetById(Guid id);
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(Guid id);
}
