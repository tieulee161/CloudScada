using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DataAcquisition.Model.Entities;

namespace DataAcquisition.Repositories
{

    /// <summary>
    /// Repository contain all of base method to work with db, very easy to inheritance, very easy to upgrade or change method 
    /// one time for all project
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {

        /// <summary>
        /// Get IQueryable list of all entities from DbSet
        /// </summary>
        IQueryable<TEntity> Table { get; }

        /// <summary>
        ///  Get an entity by ID
        /// </summary>
        /// <param name="id">ID of entity</param>
        /// <returns></returns>
        TEntity GetById(int id);

        /// <summary>
        /// Get all entities from a DbSet
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Get ordered IQueryable list of entities from a DbSet by filter
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="orderBy"></param>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        /// <summary>
        /// Insert a new entity to DbSet
        /// </summary>
        /// <param name="entity">entity to insert</param>
        /// <returns></returns>
        void Insert(TEntity entity);

        /// <summary>
        /// Update an existing entity in DbSet
        /// </summary>
        /// <param name="entity">entity to update</param>
        /// <returns></returns>
        void Update(TEntity entity);

        /// <summary>
        /// Delete an entity in DbSet by set isActive to false or remove from DbSet
        /// </summary>
        /// <param name="entity">entity to delete</param>
        /// <param name="isRemoveFromDb"></param>
        /// <returns></returns>
        void Delete(TEntity entity, bool isRemoveFromDb = false);

        /// <summary>
        /// Delete an entity in DbSet by set isActive to false or remove from DbSet
        /// </summary>
        /// <param name="id">id of entity to delete</param>
        /// <param name="isRemoveFromDb"></param>
        /// <returns></returns>
        void Delete(int id, bool isRemoveFromDb = false);

        /// <summary>
        /// Delete an list of entities in DbSet by set isActive to false or remove from DbSet
        /// </summary>
        /// <param name="entities">list of entities to delete</param>
        /// <param name="isRemoveFromBd"></param>
        void DeleteRange(IEnumerable<TEntity> entities, bool isRemoveFromBd = false);


        /// <summary>
        /// Save all changes made in this DbContext to the underlying database
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// Get IQueryable list of entities in DbSet by raw sql query
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetWithRawSql(string query, object[] parameters);

        /// <summary>
        /// Execute the given DDL/DML command against the database
        /// </summary>
        /// <param name="query"></param>
        void ExecuteSQLCommand(string query);

        /// <summary>
        /// Reload the entity from database
        /// </summary>
        /// <param name="entityToDelete"></param>
        void ResetDeleteState(TEntity entityToDelete);

    }
}
