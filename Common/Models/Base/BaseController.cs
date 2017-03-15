using Common.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models.Base
{
    public abstract class BaseController<T> : IBaseController<T>, IDisposable
    {
        public abstract string Alter(T obj);
        public abstract string Create(T obj);
        public abstract string Delete(long Id);
        public abstract T Get(long Id);
        public abstract List<T> GetAll();
        protected abstract void Dispose(bool v);
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
