using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces.Base
{
    public interface IBaseController<T>
    {
        string Create(T obj);

        string Alter(T obj);

        string Delete(long Id);

        T Get(long Id);

        List<T> GetAll();
    }
}
