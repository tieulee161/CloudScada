
using DataAcquisition.Model.Entities;
using DataAcquisition.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DataAcquisition.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {

        #region Private Properties

        private readonly DataAcquisitionDbContext _dbContext;
        private DbSet<TEntity> _entity;

        #endregion

        #region Ctor

        public Repository(DataAcquisitionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion
       
        #region Private Methods

        private DbSet<TEntity> Entity
        {
            get
            {
                return _entity ?? (_entity = _dbContext.Set<TEntity>());
            }
        }

        #endregion

        #region Methods

        public IQueryable<TEntity> Table
        {
            get
            {
                return Entity.Where(i => i.IsActive);
            }
        }

        public TEntity GetById(int id)
        {
            return Entity.Find(id);
        }

        public IQueryable<TEntity> GetAll()
        {
            return Get();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            var query = Table;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return orderBy != null ? orderBy(query) : query;
        }

        public void Insert(TEntity entity)
        {
            SetDefaultFieldsWhenCreate(entity);
            Entity.Add(entity);
        }

        public void Update(TEntity entity)
        {
            SetDefaultFieldsWhenUpdate(entity);
            Entity.Attach(entity);
            _dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public void Delete(TEntity entity, bool isRemoveFromDb = false)
        {
            if (isRemoveFromDb)
            {
                Entity.Remove(entity);
            }
            else
            {
                entity.IsActive = false;
                Update(entity);
            }
        }

        public void Delete(int id, bool isRemoveFromDb = false)
        {
            var entity = GetById(id);
            Delete(entity, isRemoveFromDb);
        }

        public void DeleteRange(IEnumerable<TEntity> entities, bool isRemoveFromBd = false)
        {
            if (isRemoveFromBd)
            {
                Entity.RemoveRange(entities);
            }
            else
            {
                foreach (var entity in entities)
                {
                    Delete(entity);
                }
            }
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public IQueryable<TEntity> GetWithRawSql(string query, object[] parameters)
        {
            return Entity.SqlQuery(query, parameters).AsQueryable();
        }

        public void ExecuteSQLCommand(string query)
        {
            _dbContext.Database.ExecuteSqlCommand(query);
        }

        public void ResetDeleteState(TEntity entityToDelete)
        {
            _dbContext.Entry<TEntity>(entityToDelete).Reload();
        }

        #endregion

        #region Helpers

        protected virtual void SetDefaultFieldsWhenCreate(TEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            entity.CreatedDate = DateTime.Now;
        }

        protected virtual void SetDefaultFieldsWhenUpdate(TEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
        }

        protected virtual void SetProperty(TEntity entityToSet, string propertyName, object value)
        {
            var targetProperty = entityToSet.GetType().GetProperty(propertyName);
            if (targetProperty != null)
                targetProperty.SetValue(entityToSet, value, null);
        }

        #endregion

    }
}
