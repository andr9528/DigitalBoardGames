using System;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Utilities.Extensions.EntityFramework
{
    public static class ContextExtensions
    {
        // Source: https://stackoverflow.com/questions/21533506/find-a-specified-generic-dbset-in-a-dbcontext-dynamically-when-i-have-an-entity

        #region Deprecated
        //public static IQueryable<object> Set(this DbContext context, Type T)
        //{

        //    // Get the generic type definition
        //    var method =
        //        typeof(DbContext).GetMethod(nameof(DbContext.Set), BindingFlags.Public | BindingFlags.Instance);

        //    // Build a method with the specific type argument you're interested in
        //    method = method.MakeGenericMethod(T);

        //    return method.Invoke(context, null) as IQueryable<object>;
        //} 
        #endregion

        public static IQueryable<T> Set<T>(this DbContext context, T type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            // Get the generic type definition 
            var method =
                typeof(DbContext).GetMethod(nameof(DbContext.Set), BindingFlags.Public | BindingFlags.Instance);

            // Build a method with the specific type argument you're interested in 
            method = method.MakeGenericMethod(typeof(T));

            return method.Invoke(context, null) as IQueryable<T>;
        }
    }
}