using System;
using System.Linq;
using Chess.Repository.EntityFramework;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Repository.Core;
using Utilities.Extensions.EntityFramework;

namespace Utilities.Factories
{
    public class ContextFactory : IDisposable
    {
        #region IDisposable Support  
        private bool _disposedValue; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

        public T CreateMemoryContext<T>() where T : DbContext
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var option = new DbContextOptionsBuilder<T>().UseSqlite(connection).Options;

            var context = (T) Activator.CreateInstance(typeof(T), option);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            return context;
        }
        /// <summary>
        /// Any entities specified to copy with aggregate data should have one of the following things:
        /// - A navigational property.
        /// - A separate specified entity with enough taken that ensures all foreign keys are copied.
        ///
        /// Giving a -1 to an 'amount' will have it take all.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="physicalContext"></param>
        /// <param name="entitiesToCopy"></param>
        /// <returns></returns>
        public T CopyFromContext<T>(T physicalContext, params (Type entityType, int amount)[] entitiesToCopy) where T : DbContext
        {
            if (physicalContext == null) throw new ArgumentNullException(nameof(physicalContext));

            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var option = new DbContextOptionsBuilder<T>().UseSqlite(connection).Options;

            var memoryContext = (T)Activator.CreateInstance(typeof(T), option);

            memoryContext.Database.EnsureDeleted();
            memoryContext.Database.EnsureCreated();

            foreach (var (type, amount) in entitiesToCopy)
            {
                if (!typeof(IEntity).IsAssignableFrom(type.ReflectedType))
                {
                    throw new ArgumentException($"{type.ReflectedType} Does not implement Interface {typeof(IEntity).Name}");
                }

                var memoryDbSet = memoryContext.Set(Activator.CreateInstance(type.ReflectedType ?? throw new InvalidOperationException()));

                if (amount == -1)
                {
                    var copiedElements = physicalContext.Set(Activator.CreateInstance(type.ReflectedType)).ToList();
                    
                    foreach (var element in copiedElements)
                    {
                        memoryDbSet.Append(element);
                    }
                }
                else
                {
                    var copiedElements = physicalContext.Set(Activator.CreateInstance(type.ReflectedType)).Take(amount);
                    
                    foreach (var element in copiedElements)
                    {
                        memoryDbSet.Append(element);
                    }
                }

                memoryContext.SaveChanges();
            }

            return memoryContext;
        }

        public IGenericRepository GetHandler<T>(T context) where T : DbContext
        {
            IGenericRepository handler = null;
            if(typeof(T) == typeof(ChessRepository))
                handler = new GenericRepositoryHandler(context as ChessRepository);
            if(handler != null)
                return handler;
            throw new ArgumentException("Imputed context doesn't match any known Handlers", nameof(context));
        }
    }
}