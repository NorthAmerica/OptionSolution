using System.Runtime.Remoting.Messaging;

namespace OP.Repository
{
    public class ContextFactory
    {
        private static EFDbContext _efDbContext = null;
          
        private static object lockboj = new object();

        /// <summary>
        /// 获取当前数据上下文
        /// </summary>
        /// <returns>数据上下文</returns>
        public static EFDbContext GetCurrentContext()
        {
            //_efDbContext = CallContext.GetData("EFDbContext") as EFDbContext;

            if (_efDbContext == null)
            {
                lock (lockboj)
                {
                    if (_efDbContext == null)
                    {
                        _efDbContext = new EFDbContext();
                       // CallContext.SetData("EFDbContext", _efDbContext);
                    }
                }
            }
            //_efDbContext.Database.Initialize(true); //强制初始化
            return _efDbContext;
        }
    }
}
