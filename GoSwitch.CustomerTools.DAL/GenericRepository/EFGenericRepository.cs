using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Linq.Dynamic;
using System.Data.Objects;

namespace GoSwitch.CustomerTools.DAL
{
    public class EFGenericRepository : RepositoryBase
    {
        private ObjectContext _context;

        /// <summary>
        /// Create an instance of an EDM (Entity Data Model)
        /// </summary>
        /// <param name="context"></param>
        public EFGenericRepository(ObjectContext context)
        {
            _context = context;
            _context.CommandTimeout = 180;
        }

        //return objectSet for Query, Create, Update, Delete
        public ObjectSet<T> GetObjectSet<T>() where T : class
        {
            return _context.CreateObjectSet<T>();
        }

        protected string GetEntitySetName<T>()
        {
            return String.Format("{0}", typeof(T).Name);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }

        #region IGenericRepository Members
        /// <returns>returns all EDM of type T into a querable list</returns>
        public override IQueryable<T> GetAll<T>()
        {
            return GetObjectSet<T>().AsQueryable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="navigationProperties">The included Table. It will reduce the performance depends on the amount of the table</param>
        /// <returns></returns>
        public override IQueryable<T> GetAll<T>(List<string> navigationProperties)
        {
            ObjectQuery<T> query = this.GetObjectSet<T>() as ObjectQuery<T>;
            foreach (string navprop in navigationProperties)
            {
                query = query.Include(navprop);
            }
            return query.AsQueryable();            
        }

        public override IQueryable<T> GetAll<T>(string orderBy)
        {
            orderBy = "it." + orderBy;
            return GetObjectSet<T>().OrderBy(orderBy).AsQueryable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="orderBy"></param>
        /// <param name="navigationProperties">The included Table. It will reduce the performance depends on the amount of the table</param>
        /// <returns></returns>
        public override IQueryable<T> GetAll<T>(string orderBy, List<string> navigationProperties)
        {
            orderBy = "it." + orderBy;
            ObjectQuery<T> query = this.GetObjectSet<T>() as ObjectQuery<T>;
            foreach (string navprop in navigationProperties)
            {
                query = query.Include(navprop);
            }
            return query.OrderBy(orderBy).AsQueryable();            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="orderBy"></param>
        /// <param name="orderExpression">ASC for ascending or DESC for descending</param>
        /// <returns></returns>
        public override IQueryable<T> GetAll<T>(string orderBy, string orderExpression)
        {
            orderBy = "it." + orderBy + " " + orderExpression;
                return GetObjectSet<T>().OrderBy(orderBy).AsQueryable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="orderBy"></param>
        /// <param name="orderExpression"></param>
        /// <param name="navigationProperties">The included Table. It will reduce the performance depends on the amount of the table</param>
        /// <returns></returns>
        public override IQueryable<T> GetAll<T>(string orderBy, string orderExpression, List<string> navigationProperties)
        {
            orderBy = "it." + orderBy + " " + orderExpression;

            ObjectQuery<T> query = this.GetObjectSet<T>() as ObjectQuery<T>;
            foreach (string navprop in navigationProperties)
            {
                query = query.Include(navprop);
            }
            return query.OrderBy(orderBy).AsQueryable();
        }

        /// <summary>
        /// Adds a new record of type T to T and saves it.
        /// </summary>
        public override void Create<T>(T entityToCreate)
        {
            this.GetObjectSet<T>().AddObject(entityToCreate);
            this.CommitChanges();
        }

        /// <summary>
        ///  Adds a new record of type T to T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityTOCreate"></param>
        public override void CreateNotCommit<T>(T entityTOCreate)
        {
            this.GetObjectSet<T>().AddObject(entityTOCreate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityListToCreate"></param>
        public override void CreateAll<T>(List<T> entityListToCreate)
        {
            foreach (T entity in entityListToCreate)
            {
                this.GetObjectSet<T>().AddObject(entity);
                this.CommitChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityListToCreate"></param>
        public override void CreateAllNotCommit<T>(List<T> entityListToCreate)
        {
            foreach (T entity in entityListToCreate)
            {
                this.GetObjectSet<T>().AddObject(entity);
            }
        }

        /// <summary>
        /// Edits record of id in type T and save changes to Database
        /// </summary>
        public override void Modify<T>(T entityToEdit)
        {
            GetObjectSet<T>().ApplyCurrentValues(entityToEdit);
            this.CommitChanges();
        }

        /// <summary>
        ///  Edits record of id in type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityToModify"></param>
        public override void ModifyNotCommit<T>(T entityToModify)
        {
            this.GetObjectSet<T>().ApplyCurrentValues(entityToModify);
        }

        /// <summary>
        /// Delets record of id in type T and commit to database
        /// </summary>
        public override void Delete<T>(T entityToDelete)
        {
            this.GetObjectSet<T>().DeleteObject(entityToDelete);
            this.CommitChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityToDelete"></param>
        public override void DeleteNotCommit<T>(T entityToDelete)
        {
            this.GetObjectSet<T>().DeleteObject(entityToDelete);
        }

        /// <summary>
        /// Delete All Data on Type T and commit to database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public override void DeleteAll<T>()
        {
            foreach (T obj in this.GetObjectSet<T>().AsQueryable())
            {
                this.GetObjectSet<T>().DeleteObject(obj);
            }
            this.CommitChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public override void DeleteAllNotCommit<T>()
        {
            foreach (T obj in this.GetObjectSet<T>().AsQueryable())
            {
                this.GetObjectSet<T>().DeleteObject(obj);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityListToDelete"></param>
        public override void DeleteAll<T>(List<T> entityListToDelete)
        {
            foreach (T obj in entityListToDelete)
            {
                this.GetObjectSet<T>().DeleteObject(obj);
            }
            this.CommitChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entityListToDelete"></param>
        public override void DeleteAllNotCommit<T>(List<T> entityListToDelete)
        {
            foreach (T obj in entityListToDelete)
            {
                this.GetObjectSet<T>().DeleteObject(obj);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void CommitChanges()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public override IQueryable<T> Find<T>(Func<T, bool> predicate)
        {
            return this.GetObjectSet<T>().Where(predicate).AsQueryable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="navigationProperties">The included Table. It will reduce the performance depends on the amount of the table</param>
        /// <returns></returns>
        public override IQueryable<T> Find<T>(Func<T, bool> predicate, List<string> navigationProperties)
        {
            ObjectQuery<T> query = this.GetObjectSet<T>() as ObjectQuery<T>;
            foreach (string navprop in navigationProperties)
            {
                query = query.Include(navprop);
            }
            return query.Where(predicate).AsQueryable();            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public override IQueryable<T> Find<T>(Func<T, bool> predicate, string orderBy)
        {
            orderBy = "it." + orderBy;
            return this.GetObjectSet<T>().OrderBy(orderBy).Where(predicate).AsQueryable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="navigationProperties">The included Table. It will reduce the performance depends on the amount of the table</param>
        /// <returns></returns>
        public override IQueryable<T> Find<T>(Func<T, bool> predicate, string orderBy, List<string> navigationProperties)
        {
            orderBy = "it." + orderBy;
            ObjectQuery<T> query = this.GetObjectSet<T>() as ObjectQuery<T>;
            foreach (string navprop in navigationProperties)
            {
                query = query.Include(navprop);
            }
            return query.OrderBy(orderBy).Where(predicate).AsQueryable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="orderExpression">ASC for ascending or DESC for descending</param>
        /// <returns></returns>
        public override IQueryable<T> Find<T>(Func<T, bool> predicate, string orderBy, string orderExpression)
        {
            orderBy = "it." + orderBy + " " + orderExpression;
            return this.GetObjectSet<T>().OrderBy(orderBy).Where(predicate).AsQueryable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="orderExpression"></param>
        /// <param name="navigationProperties">The included Table. It will reduce the performance depends on the amount of the table</param>
        /// <returns></returns>
        public override IQueryable<T> Find<T>(Func<T, bool> predicate, string orderBy, string orderExpression, List<string> navigationProperties)
        {
            orderBy = "it." + orderBy + " " + orderExpression;
            ObjectQuery<T> query = this.GetObjectSet<T>() as ObjectQuery<T>;
            foreach (string navprop in navigationProperties)
            {
                query = query.Include(navprop);
            }
            return query.OrderBy(orderBy).Where(predicate).AsQueryable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public override T Single<T>(Func<T, bool> predicate)
        {
            return this.GetObjectSet<T>().SingleOrDefault<T>(predicate);
        }

        public override T Single<T>(Func<T, bool> predicate, List<string> navigationProperties)
        {
            ObjectQuery<T> query = this.GetObjectSet<T>() as ObjectQuery<T>;
            foreach (string navprop in navigationProperties)
            {
                query = query.Include(navprop);
            }
            return query.SingleOrDefault<T>(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public override T First<T>(Func<T, bool> predicate, bool localRepository = false)
        {
            if (!localRepository)
                return this.GetObjectSet<T>().FirstOrDefault<T>(predicate);
            else
            {
                string type = typeof(T).Name;
                IEnumerable<T> dataLocal = from stateEntry in _context.ObjectStateManager.GetObjectStateEntries(
                           EntityState.Added |
                           EntityState.Modified |
                           EntityState.Unchanged)
                       where stateEntry.Entity != null && stateEntry.Entity.GetType().Name == type
                       select stateEntry.Entity as T;
                if (dataLocal.Count() > 0)
                    return dataLocal.FirstOrDefault(predicate);
                else
                    return null;
            }
        }

        public override T First<T>(Func<T, bool> predicate, List<string> navigationProperties)
        {
            ObjectQuery<T> query = this.GetObjectSet<T>() as ObjectQuery<T>;
            foreach (string navprop in navigationProperties)
            {
                query = query.Include(navprop);
            }
            return query.FirstOrDefault<T>(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public override int Count<T>()
        {
            return this.GetObjectSet<T>().Count();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public override int Count<T>(Func<T, bool> predicate)
        {
            return this.GetObjectSet<T>().Count(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public override IQueryable<T> Find<T>(Func<T, bool> predicate, int pageSize, int pageNumber, string orderBy)
        {
            orderBy = "it." + orderBy;

            if (pageSize <= 0) pageSize = 20;

            int rowsCount = GetObjectSet<T>().Where(predicate).Count();

            if (rowsCount <= pageSize || pageNumber <= 0) pageNumber = 1;

            int excludedRows = (pageNumber - 1) * pageSize;

            return this.GetObjectSet<T>().OrderBy(orderBy)
                .Where(predicate)
                .Skip(excludedRows)
                .Take(pageSize)
                .AsQueryable();
        }

        public override IQueryable<T> Find<T>(Func<T, bool> predicate, int pageSize, int pageNumber, string orderBy, List<string> navigationProperties)
        {
            ObjectQuery<T> query = this.GetObjectSet<T>() as ObjectQuery<T>;
            foreach (string navprop in navigationProperties)
            {
                query = query.Include(navprop);
            }
            orderBy = "it." + orderBy;

            if (pageSize <= 0) pageSize = 20;

            int rowsCount = query.Where(predicate).Count();

            if (rowsCount <= pageSize || pageNumber <= 0) pageNumber = 1;

            int excludedRows = (pageNumber - 1) * pageSize;

            return query.OrderBy(orderBy)
                .Where(predicate)
                .Skip(excludedRows)
                .Take(pageSize)
                .AsQueryable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="orderBy"></param>
        /// <param name="orderExpression">ASC for ascending or DESC for descending</param>
        /// <returns></returns>
        public override IQueryable<T> Find<T>(Func<T, bool> predicate, int pageSize, int pageNumber, string orderBy, string orderExpression)
        {
            orderBy = "it." + orderBy + " " + orderExpression;

            if (pageSize <= 0) pageSize = 20;

            int rowsCount = GetObjectSet<T>().Where(predicate).Count();

            if (rowsCount <= pageSize || pageNumber <= 0) pageNumber = 1;

            int excludedRows = (pageNumber - 1) * pageSize;

            return this.GetObjectSet<T>().OrderBy(orderBy)
                .Where(predicate)
                .Skip(excludedRows)
                .Take(pageSize)
                .AsQueryable();
        }

        public override IQueryable<T> Find<T>(Func<T, bool> predicate, int pageSize, int pageNumber, string orderBy, string orderExpression, List<string> navigationProperties)
        {
            ObjectQuery<T> query = this.GetObjectSet<T>() as ObjectQuery<T>;
            foreach (string navprop in navigationProperties)
            {
                query = query.Include(navprop);
            }

            orderBy = "it." + orderBy + " " + orderExpression;

            if (pageSize <= 0) pageSize = 20;

            int rowsCount = query.Where(predicate).Count();

            if (rowsCount <= pageSize || pageNumber <= 0) pageNumber = 1;

            int excludedRows = (pageNumber - 1) * pageSize;

            return query.OrderBy(orderBy)
                .Where(predicate)
                .Skip(excludedRows)
                .Take(pageSize)
                .AsQueryable();
        }
        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public override IQueryable<T> GetAll<T>(int pageSize, int pageNumber, string orderBy)
        {
            orderBy = "it." + orderBy;

            if (pageSize <= 0) pageSize = 20;

            int rowsCount = GetObjectSet<T>().Count();

            if (rowsCount <= pageSize || pageNumber <= 0) pageNumber = 1;

            int excludedRows = (pageNumber - 1) * pageSize;

            return this.GetObjectSet<T>().OrderBy(orderBy)
                .Skip(excludedRows)
                .Take(pageSize)
                .AsQueryable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="orderBy"></param>
        /// <param name="navigationProperties"></param>
        /// <returns></returns>
        public override IQueryable<T> GetAll<T>(int pageSize, int pageNumber, string orderBy, List<string> navigationProperties)
        {
            orderBy = "it." + orderBy;

            ObjectQuery<T> query = this.GetObjectSet<T>() as ObjectQuery<T>;
            foreach (string navprop in navigationProperties)
            {
                query = query.Include(navprop);
            }            

            if (pageSize <= 0) pageSize = 20;

            int rowsCount = query.Count();

            if (rowsCount <= pageSize || pageNumber <= 0) pageNumber = 1;

            int excludedRows = (pageNumber - 1) * pageSize;

            return query.OrderBy(orderBy)
                .Skip(excludedRows)
                .Take(pageSize)
                .AsQueryable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="orderBy"></param>
        /// <param name="orderExpression">ASC for ascending or DESC for descending</param>
        /// <returns></returns>
        public override IQueryable<T> GetAll<T>(int pageSize, int pageNumber, string orderBy, string orderExpression)
        {
            orderBy = "it." + orderBy + " " + orderExpression;

            if (pageSize <= 0) pageSize = 20;

            int rowsCount = GetObjectSet<T>().Count();

            if (rowsCount <= pageSize || pageNumber <= 0) pageNumber = 1;

            int excludedRows = (pageNumber - 1) * pageSize;

            return this.GetObjectSet<T>().OrderBy(orderBy)
                .Skip(excludedRows)
                .Take(pageSize)
                .AsQueryable();
        }

        public override IQueryable<T> GetAll<T>(int pageSize, int pageNumber, string orderBy, string orderExpression, List<string> navigationProperties)
        {
            orderBy = "it." + orderBy + " " + orderExpression;

            ObjectQuery<T> query = this.GetObjectSet<T>() as ObjectQuery<T>;
            foreach (string navprop in navigationProperties)
            {
                query = query.Include(navprop);
            }

            if (pageSize <= 0) pageSize = 20;

            int rowsCount = GetObjectSet<T>().Count();

            if (rowsCount <= pageSize || pageNumber <= 0) pageNumber = 1;

            int excludedRows = (pageNumber - 1) * pageSize;

            return this.GetObjectSet<T>().OrderBy(orderBy)
                .Skip(excludedRows)
                .Take(pageSize)
                .AsQueryable();
        }
    }
}
