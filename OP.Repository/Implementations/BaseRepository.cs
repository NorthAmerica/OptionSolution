using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OP.Repository.Implementations
{
    /// <summary>
    /// 仓储基类
    /// <remarks>
    /// 创建：2016.02.17
    /// </remarks>
    /// </summary>
    public class BaseRepository<T> : InterfaceBaseRepository<T> where T : class
    {
        //protected EFDbContext FContext = ContextFactory.GetCurrentContext();
        public T Add(T entity, bool isSave = true)
        {
            using (EFDbContext nContext = new EFDbContext())
            {
                nContext.Set<T>().Add(entity);
                if (isSave) nContext.SaveChanges();
                return entity;
            }
        }

        public int AddRange(IEnumerable<T> entities, bool isSave = true)
        {
            using (EFDbContext nContext = new EFDbContext())
            {
                nContext.Set<T>().AddRange(entities);
                return isSave ? nContext.SaveChanges() : 0;
            }
        }

        public bool Update(T entity, bool isSave = true)
        {
            using (EFDbContext nContext = new EFDbContext())
            {
                nContext.Set<T>().Attach(entity);
                nContext.Entry<T>(entity).State = EntityState.Modified;
                return isSave ? nContext.SaveChanges() > 0 : true;
            }
        }

        public bool Delete(T entity, bool isSave = true)
        {
            using (EFDbContext nContext = new EFDbContext())
            {
                nContext.Set<T>().Attach(entity);
                nContext.Entry<T>(entity).State = EntityState.Deleted;
                return isSave ? nContext.SaveChanges() > 0 : true;
            }
        }

        public int DeleteRange(IEnumerable<T> entities, bool isSave = true)
        {
            using (EFDbContext nContext = new EFDbContext())
            {
                //先得到实体才能删除
                foreach (var entitie in entities)
                {
                    nContext.Set<T>().Attach(entitie);
                }
                
                nContext.Set<T>().RemoveRange(entities);
                return isSave ? nContext.SaveChanges() : 0;
            }
        }
        /// <summary>
        /// 查询满足条件的实体个数
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public int Count(Expression<Func<T, bool>> predicate)
        {
            using (EFDbContext nContext = new EFDbContext())
            {
                return nContext.Set<T>().Count(predicate);
            }
        }
        /// <summary>
        /// 是否存在满足条件的实体
        /// </summary>
        /// <param name="anyLambda"></param>
        /// <returns></returns>
        public bool Exist(Expression<Func<T, bool>> anyLambda)
        {
            using (EFDbContext nContext = new EFDbContext())
            {
                return nContext.Set<T>().Any(anyLambda);
            }
        }
        /// <summary>
        /// 不进行缓存查询
        /// 性能提高
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public T FindNoTracking(Expression<Func<T, bool>> whereLambda)
        {
            using (EFDbContext nContext = new EFDbContext())
            {
                T _entity = nContext.Set<T>().AsNoTracking().FirstOrDefault<T>(whereLambda);
                return _entity;
            }
        }
        /// <summary>
        /// 缓存查询<不一定是最新数据>
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public T Find(Expression<Func<T, bool>> whereLambda)
        {
            using (EFDbContext nContext = new EFDbContext())
            {
                T _entity = nContext.Set<T>().FirstOrDefault<T>(whereLambda);
                return _entity;
            }
        }
        /// <summary>
        /// 异步查询<不一定是最新数据>
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public async Task<T> FindAsync(Expression<Func<T, bool>> whereLambda)
        {
            using (EFDbContext nContext = new EFDbContext())
            {
                T _entity = await nContext.Set<T>().FirstOrDefaultAsync(whereLambda);
                return _entity;
            }
        }

        public IQueryable<T> FindAllIQueryable()
        {
            using (EFDbContext nContext = new EFDbContext())
            {
                var _list = nContext.Set<T>().AsQueryable();
                return _list;
            }
        }
        public IEnumerable<T> FindAll()
        {
            using (EFDbContext nContext = new EFDbContext())
            {
                var _list = nContext.Set<T>().AsEnumerable();
                return _list.ToList<T>();
            }
        }

        public IEnumerable<T> FindList(Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc)
        {
            using (EFDbContext nContext = new EFDbContext())
            {
                var _list = nContext.Set<T>().Where(whereLamdba);
                _list = OrderBy(_list, orderName, isAsc);
                return _list.ToList<T>();
            }
        }


        public IEnumerable<T> FindPageList(int pageIndex, int pageSize, out int totalRecord, Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc)
        {
            using (EFDbContext nContext = new EFDbContext())
            {
                var _list = nContext.Set<T>().Where<T>(whereLamdba);
                totalRecord = _list.Count();
                _list = OrderBy(_list, orderName, isAsc).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
                return _list.ToList<T>();
            }
        }

        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="source">原IQueryable</param>
        /// <param name="propertyName">排序属性名</param>
        /// <param name="isAsc">是否正序</param>
        /// <returns>排序后的IQueryable<T></returns>
        private IQueryable<T> OrderBy(IQueryable<T> source, string propertyName, bool isAsc)
        {
            if (source == null) throw new ArgumentNullException("source", "不能为空");
            if (string.IsNullOrEmpty(propertyName)) return source;
            var _parameter = Expression.Parameter(source.ElementType);
            var _property = Expression.Property(_parameter, propertyName);
            if (_property == null) throw new ArgumentNullException("propertyName", "属性不存在");
            var _lambda = Expression.Lambda(_property, _parameter);
            var _methodName = isAsc ? "OrderBy" : "OrderByDescending";
            var _resultExpression = Expression.Call(typeof(Queryable), _methodName, new Type[] { source.ElementType, _property.Type }, source.Expression, Expression.Quote(_lambda));
            return source.Provider.CreateQuery<T>(_resultExpression);
        }


    }
}
