using HospitalAppointmentSystem.WebApi.Contexts;
using HospitalAppointmentSystem.WebApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Generic;

namespace HospitalAppointmentSystem.WebApi.Repository.Abstracts;

public abstract class BaseRepository<TEntity, TId> : IRepository<TEntity, TId>
where TEntity : Entity<TId>, new()
{
    protected readonly MsSqlContext _context;

    public BaseRepository(MsSqlContext context)
    {
        _context = context;
    }
    public TEntity? Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
        return entity;
    }

    public List<TEntity> GetAll()
    {
        List<TEntity> entities = _context.Set<TEntity>().ToList();
        return entities;
    }

    public TEntity? GetById(TId id)
    {
        TEntity? entity = _context.Set<TEntity>().Find(id);
        return entity;
    }

    public TEntity? Remove(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        _context.SaveChanges();
        return entity;
    }

    public TEntity? Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        _context.SaveChanges();
        return entity;
    }
}
