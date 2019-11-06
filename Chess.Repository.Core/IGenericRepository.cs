using System.Collections.Generic;

namespace Repository.Core
{
    public interface IGenericRepository  : IBaseRepository
    {
        /*
         * Classes that implement this class should also inherit from a class implementing IBaseRepository
         *
         * Remember to always call Save after Adding, Updateing and Deleteing.
         * 
         */

        T Find<T>(T predicate) where T : class, IEntity;

        ICollection<T> FindMultiple<T>(T predicate) where T : class, IEntity;

        /// <summary>
        /// Remember to call Save!
        /// </summary>
        bool Update<T>(T element) where T : class, IEntity;

        /// <summary>
        /// Remember to call Save!
        /// </summary>
        bool Delete<T>(T element) where T : class, IEntity;

        /// <summary>
        /// Remember to call Save!
        /// </summary>
        bool Add<T>(T element) where T : class, IEntity;

        /// <summary>
        /// Remember to call Save!
        /// </summary>
        string AddMultiple<T>(ICollection<T> elements) where T : class, IEntity;
    }
}
