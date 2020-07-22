using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Model.Entities;
using System;

namespace DataAccess.Core
{
    public interface IBaseContext: IDisposable
    {
        DbSet<Picture> Pictures { get; set; }
        DbSet<Post> Posts { get; set; }

        void CleanContext();
        //void Dispose();
        void Seed(ISeeder seeder);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
        DatabaseFacade GetDatabase();
    }
}