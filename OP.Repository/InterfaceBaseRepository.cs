using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OP.Repository
{
    /// <summary>
    /// 接口基类
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface InterfaceBaseRepository<T>
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>添加后的数据实体</returns>
        T Add(T entity, bool isSave = true);
        /// <summary>
        /// 批量添加【立即执行】
        /// </summary>
        /// <param name="entities">数据列表</param>
        /// <returns>添加的记录数</returns>
        int AddRange(IEnumerable<T> entities, bool isSave = true);
        /// <summary>
        /// 查询记录数
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns>记录数</returns>
        int Count(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <param name="isSave">是否立即保存</param>
        /// <returns></returns>
        bool Update(T entity, bool isSave = true);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity">数据实体</param>
        /// <returns>是否成功</returns>
        bool Delete(T entity, bool isSave = true);
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="entities">数据列表</param>
        /// <param name="isSave">是否立即保存</param>
        /// <returns>删除的记录数</returns>
        int DeleteRange(IEnumerable<T> entities, bool isSave = true);
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="anyLambda">查询表达式</param>
        /// <returns>布尔值</returns>
        bool Exist(Expression<Func<T, bool>> anyLambda);
        /// <summary>
        /// 是否存在(异步)
        /// </summary>
        /// <param name="anyLambda">查询表达式</param>
        /// <returns>布尔值</returns>
        Task<bool> ExistAsync(Expression<Func<T, bool>> anyLambda);
        /// <summary>
        /// 不进行缓存查询
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        T FindNoTracking(Expression<Func<T, bool>> whereLambda);
        /// <summary>
        /// 按条件查询数据
        /// </summary>
        /// <param name="whereLambda">查询表达式</param>
        /// <returns>实体</returns>
        T Find(Expression<Func<T, bool>> whereLambda);
        /// <summary>
        /// 按条件异步查询<不一定是最新数据>
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        Task<T> FindAsync(Expression<Func<T, bool>> whereLambda);
        /// <summary>
        /// 异步查询第一条数据
        /// </summary>
        /// <returns></returns>
        Task<T> FindFirstAsync();
        /// <summary>
        /// 查找数据列表
        /// </summary>
        /// <typeparam name="S">排序</typeparam>
        /// <param name="whereLamdba">查询表达式</param>
        /// <param name="orderName">排序名称</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        IEnumerable<T> FindList(Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc);
        /// <summary>
        /// 异步查询数据列表
        /// </summary>
        /// <param name="whereLamdba">查询表达式</param>
        /// <param name="orderName">排序名称</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        Task<List<T>> FindListAsync(Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc);
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> FindAll();
        /// <summary>
        /// 异步查询所有数据
        /// </summary>
        /// <returns></returns>
        Task<List<T>> FindAllAsync();
        /// <summary>
        /// 查找分页数据列表
        /// </summary>
        /// <typeparam name="S">排序</typeparam>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="totalRecord">总记录数</param>
        /// <param name="whereLamdba">查询表达式</param>
        /// <param name="orderName">排序名称</param>
        /// <param name="isAsc">是否升序</param>
        /// <returns></returns>
        IEnumerable<T> FindPageList(int pageIndex, int pageSize, out int totalRecord, Expression<Func<T, bool>> whereLamdba, string orderName, bool isAsc);

    }
}
