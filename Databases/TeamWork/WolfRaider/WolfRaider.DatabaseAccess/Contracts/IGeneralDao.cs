namespace WolfRaider.DatabaseAccess.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IGeneralDao<T>
    {
        void Insert(T data);

        void Delete(T data);

        void Update(T data);

        IEnumerable<T> ListAll();

        IEnumerable<T> Find(Expression<Func<T, bool>> condition);
    }
}
