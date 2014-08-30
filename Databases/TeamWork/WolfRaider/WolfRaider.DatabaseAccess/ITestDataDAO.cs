using System.Collections.Generic;
using WolfRaider.Common.Models;

namespace WolfRaider.DatabaseAccess
{
    public interface ITestDataDao<T>
    {
        void Insert(T entity);

        List<T> List()
    }
}
