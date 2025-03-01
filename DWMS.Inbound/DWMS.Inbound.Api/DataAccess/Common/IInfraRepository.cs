﻿namespace DWMS.Inbound.Api.DataAccess.Common;

public interface IInfraRepository<T> where T : class, IGuidEntity
{
    Task<List<T>> GetAll();
    Task<T?> GetById(Guid id);
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(Guid id);
    IQueryable<T> AsQueryable();
}
