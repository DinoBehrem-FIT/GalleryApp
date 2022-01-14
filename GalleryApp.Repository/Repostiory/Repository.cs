using GalleryApp.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryApp.Repository.Repostiory
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly GalleryContext GalleryContext;
        private readonly DbSet<TEntity> Entities;

        public Repository(GalleryContext galleryContext)
        {
            GalleryContext = galleryContext;
            Entities = galleryContext.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            Entities.Add(obj);
            GalleryContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Entities.AsEnumerable();
        }

        public void Remove(TEntity obj)
        {
            Entities.Remove(obj);
            GalleryContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            GalleryContext.Entry(obj).State = EntityState.Modified;
            GalleryContext.SaveChanges();
        }
    }
}
