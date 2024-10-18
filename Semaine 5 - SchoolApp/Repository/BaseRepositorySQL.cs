using Microsoft.EntityFrameworkCore;
using Semaine_4___SchoolApp.Models;
using System.Linq.Expressions;

namespace School.Repository
{

    public class BaseRepositorySQL<TEntity> : IRepository<TEntity> where TEntity : class
    {

        protected readonly SchoolContext _dbContext;
        public BaseRepositorySQL(SchoolContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Insert(TEntity entity)
        {

            _dbContext.Set<TEntity>().Add(entity);

            SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            SaveChanges();
        }

        public IList<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).ToList();
        }

        public IList<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public bool Save(TEntity entity, Expression<Func<TEntity, bool>> predicate)
        {
            TEntity ent = (SearchFor(predicate)).FirstOrDefault();

            if (ent == null)
            {
                Insert(entity);
                return true;
            }
            SaveChanges();

            return false;
        }

        protected void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbUpdateException(ex.InnerException.Message);
            }
        }
    }
}
