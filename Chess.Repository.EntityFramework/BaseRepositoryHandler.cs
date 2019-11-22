using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Core.Internal;
using Chess.Lib.Concrete;
using Chess.Lib.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repository.Core;
using Utilities.Extensions.Exceptions;

namespace Chess.Repository.EntityFramework
{
    /// <summary>  
    ///  This class should be accessed via the Generic or Serializable classes that inherit from it.  
    /// </summary>   
    public abstract class BaseRepositoryHandler : IBaseRepository
    {
        internal ChessRepository Repo = null;

        protected BaseRepositoryHandler(ChessRepository repo)
        {
            Repo = repo;
        }

        public void Save()
        {
            Repo.SaveChanges();
        }

        #region Help Methods
        internal EntityState CheckEntryState(EntityState state, EntityEntry entry)
        {
            if (entry != null)
                state = entry.State;
            return state;
        }

        internal bool VerifyEntryState(EntityState actualState, EntityState desiredState)
        {
            return actualState == desiredState ? true : false;
        }

        internal string GetAmountAdded(ICollection<bool> results)
        {
            return string.Format("Added {0} out of {1}.", results.Where(b => b).Count(), results.Count);
        }
        #endregion

        #region Find Query Builders

        // There should be one query for each case in either 'Find' or 'FindMultiple',
        // meaning if there is a case to find YourDomainClass in both methods,
        // then there should be one query builder, meant to build queries for YourDomainClass
        // as both find methods make use of the same query, only the amount of elements returned are different.
        /*
        private IQueryable<YourDomainClass> BuildFindYourDomainClassQuery(IYourDomainClass y, IQueryable<YourDomainClass> query)
        {
            Check whether or not a property has been set, if it has been set, add a where to the query including the property.

            // e.g
            if (y.PropertyA != default(PropertyAType))
                query = query.Where(x => x.PropertyA == y.PropertyA);

            // If it is a string then use the method 'IsNullOrEmpty' and the method 'Contains'

            if (!y.PropertyB.IsNullOrEmpty())
                query = query.Where(x => x.PropertyB.Contains(y.PropertyB));
            return query;
        }
        */

        private IQueryable<Piece> BuildQuery(IPiece p, IQueryable<Piece> query)
        {
            query = query.Include(x => x.Field);

            if (p.FieldId != default) query = query.Where(x => x.Field.Id == p.FieldId);
            if (p.PlayerBoardId != default) query = query.Where(x => x.PlayerBoardId == p.PlayerBoardId);
            if (p.RuleSetId != default) query = query.Where(x => x.RuleSetId == p.RuleSetId);
            if (p.Id != default) query = query.Where(x => x.Id == p.Id);
            
            if (!p.Discriminator.IsNullOrEmpty()) query = query.Where(x => x.Discriminator.Contains(p.Discriminator));
            
            return query;
        }

        private IQueryable<Board> BuildQuery(IBoard b, IQueryable<Board> query)
        {
            if (b.RuleSetId != default) query = query.Where(x => x.RuleSetId == b.RuleSetId);
            if (b.GameId != default) query = query.Where(x => x.GameId == b.GameId);
            if (b.Id != default) query = query.Where(x => x.Id == b.Id);

            if (!b.Discriminator.IsNullOrEmpty()) query = query.Where(x => x.Discriminator.Contains(b.Discriminator));

            return query;
        }
        private IQueryable<PlayerBoard> BuildQuery(IPlayerBoard b, IQueryable<PlayerBoard> query)
        {
            if (b.BoardId != default) query = query.Where(x => x.BoardId == b.BoardId);
            if (b.PlayerId != default) query = query.Where(x => x.PlayerId == b.PlayerId);
            if (b.Id != default) query = query.Where(x => x.Id == b.Id);
            
            if (b.Facing != default) query = query.Where(x => x.Facing == b.Facing);
            if (b.Colour != default) query = query.Where(x => x.Colour == b.Colour);

            return query;
        }
        private IQueryable<Game> BuildQuery(IGame g, IQueryable<Game> query)
        {
            if (g.RuleSetId != default) query = query.Where(x => x.RuleSetId == g.RuleSetId);
            if (g.Turn != default) query = query.Where(x => x.Turn == g.Turn);
            if (g.Id != default) query = query.Where(x => x.Id == g.Id);

            return query;
        }
        private IQueryable<RuleSet> BuildQuery(IRuleSet r, IQueryable<RuleSet> query)
        {
            if (r.Id != default) query = query.Where(x => x.Id == r.Id);

            if (r.Type != default) query = query.Where(x => x.Type == r.Type);

            if (!r.TypeName.IsNullOrEmpty()) query = query.Where(x => x.TypeName.Contains(r.TypeName));
            if (!r.BoardTypeName.IsNullOrEmpty()) query = query.Where(x => x.BoardTypeName.Contains(r.BoardTypeName));
            
            return query;
        }
        private IQueryable<Player> BuildQuery(IPlayer p, IQueryable<Player> query)
        {
            if (p.Id != default) query = query.Where(x => x.Id == p.Id);

            if (!p.Name.IsNullOrEmpty()) query = query.Where(x => x.Name.Contains(p.Name));

            return query;   
        }
        private IQueryable<Field> BuildQuery(IField f, IQueryable<Field> query)
        {
            query = query.Include(x => x.Coordinate);
            query = query.Include(x => x.Piece);

            if (f.Id != default) query = query.Where(x => x.Id == f.Id);
            if (f.CoordinateId != default) query = query.Where(x => x.CoordinateId == f.CoordinateId);
            if (f.PieceId != default) query = query.Where(x => x.Piece.Id == f.PieceId);
            if (f.BoardId != default) query = query.Where(x => x.BoardId == f.BoardId);

            if (f.Coordinate != default) 
            {
                if (f.Coordinate.X != default) query = query.Where(x => x.Coordinate.X == f.Coordinate.X);
                if (f.Coordinate.Y != default) query = query.Where(x => x.Coordinate.Y == f.Coordinate.Y);
            };

            return query;
        }

        #endregion

        #region Find Multiple Methods

        private ICollection<T> FindMultipleResults<T>(IQueryable<T> query) where T : class, IEntity
        {
            var result = query.ToList();
            if (result.Any())
                return new List<T>(result);
            throw IncorrectResultCountException.Constructor<T>(1, result.Count);
        }
        // Create methods for all the different classes, where you should be able to get multiple specific elements.

        // e.g
        /*
        internal ICollection<YourDomainClass> FindMultipleYourDomainClass(IYourDomainClass y)
        {
            var query = Repo.YourDomainClassInPlural.AsQueryable();
            query = BuildFindYourDomainClassQuery(y, query);

            return FindMultipleResults(query);
        }
        */

        internal ICollection<Piece> FindMultiplePieces(IPiece p)
        {
            var query = Repo.Pieces.AsQueryable();
            query = BuildQuery(p, query);  

            return FindMultipleResults(query);
        }
        internal ICollection<Board> FindMultipleBoards(IBoard b)
        {
            var query = Repo.Boards.AsQueryable();
            query = BuildQuery(b, query);

            return FindMultipleResults(query);
        }
        internal ICollection<PlayerBoard> FindMultiplePlayerBoards(IPlayerBoard b)
        {
            var query = Repo.PlayerBoards.AsQueryable();
            query = BuildQuery(b, query);

            return FindMultipleResults(query);  
        }
        internal ICollection<Game> FindMultipleGames(IGame g)
        {
            var query = Repo.Games.AsQueryable();
            query = BuildQuery(g, query);
                    
            return FindMultipleResults(query);
        }
        internal ICollection<RuleSet> FindMultipleRuleSets(IRuleSet r)
        {
            var query = Repo.RuleSets.AsQueryable();
            query = BuildQuery(r, query);

            return FindMultipleResults(query);
        }
        internal ICollection<Player> FindMultiplePlayers(IPlayer p)
        {
            var query = Repo.Players.AsQueryable();
            query = BuildQuery(p, query);

            return FindMultipleResults(query);
        }
        internal ICollection<Field> FindMultipleFields(IField p)
        {
            var query = Repo.Fields.AsQueryable();
            query = BuildQuery(p, query);

            return FindMultipleResults(query);
        }

        #endregion

        #region Find Single Methods

        private T FindAResult<T>(IQueryable<T> query) where T : class, IEntity
        {
            var result = query.ToList();
            if (result.Count() == 1)
                return result.First();
            if (result.Count() > 1)
                throw IncorrectResultCountException.Constructor<T>(1,result.Count, true);
            throw IncorrectResultCountException.Constructor<T>(1, result.Count);
        }
        // Create methods for all the different classes, where you should be able to get one specific element.

        // e.g
        /*
        internal IYourDomainClass FindYourDomainClass(IYourDomainClass y)
        {
            var query = Repo.YourDomainClassAsPlural.AsQueryable();
            query = BuildFindYourDomainClassQuery(y, query);

            return FindAResult(query);
        }
        */
        internal IPiece FindPiece(IPiece p)
        {
            var query = Repo.Pieces.AsQueryable();
            query = BuildQuery(p, query);

            return FindAResult(query);
        }
        internal IBoard FindBoard(IBoard b)
        {
            var query = Repo.Boards.AsQueryable();
            query = BuildQuery(b, query);

            return FindAResult(query);
        }
        internal IPlayerBoard FindPlayerBoard(IPlayerBoard b)
        {
            var query = Repo.PlayerBoards.AsQueryable();
            query = BuildQuery(b, query);

            return FindAResult(query);
        }
        internal IGame FindGame(IGame g)
        {
            var query = Repo.Games.AsQueryable();
            query = BuildQuery(g, query);

            return FindAResult(query);
        }
        internal IRuleSet FindRuleSet(IRuleSet r)
        {
            var query = Repo.RuleSets.AsQueryable();
            query = BuildQuery(r, query);

            return FindAResult(query);
        }
        internal IPlayer FindPlayer(IPlayer p)
        {
            var query = Repo.Players.AsQueryable();
            query = BuildQuery(p, query);

            return FindAResult(query);
        }
        internal IField FindField(IField f)
        {
            var query = Repo.Fields.AsQueryable();
            query = BuildQuery(f, query);

            return FindAResult(query);
        }

        #endregion

        #region Add Methods

        // There should be one method for each case in the switch on the Generic version, or each overload in the Serializable version

        // e.g
        /*
        internal bool AddYourDomainClass(IYourDomainClass y)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;
            
            entry = Repo.Add(y);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Added);
        }        
         */

        internal bool AddGame(IGame x)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;

            entry = Repo.Add(x);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Added);
        }

        internal bool AddRuleSet(IRuleSet x)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;

            entry = Repo.Add(x);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Added);
        }

        #endregion

        #region Update Methods

        // There should be one method for each case in the switch on the Generic version, or each overload in the Serializable version

        // e.g
        /*
        internal bool UpdateYourDomainClass(IYourDomainClass y)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;
            
            entry = Repo.Update(y);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Modified);
        }        
         */
        internal bool UpdatePiece(IPiece p)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;

            entry = Repo.Update(p);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Modified);
        }
        internal bool UpdateBoard(IBoard b)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;

            entry = Repo.Update(b);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Modified);
        }
        internal bool UpdatePlayerBoard(IPlayerBoard b)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;

            entry = Repo.Update(b);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Modified);
        }
        internal bool UpdateGame(IGame g)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;

            entry = Repo.Update(g);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Modified);
        }
        internal bool UpdatePlayer(IPlayer p)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;

            entry = Repo.Update(p);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Modified);
        }
        internal bool UpdateField(IField f)
        {
            EntityEntry entry = null;   
            EntityState state = EntityState.Unchanged;

            entry = Repo.Update(f);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Modified);
        }

        #endregion

        #region Delete Methods

        // There should be one method for each case in the switch on the Generic version, or each overload in the Serializable version

        // e.g
        /*
        internal bool DeleteYourDomainClass(IYourDomainClass y)
        {
            EntityEntry entry = null;
            EntityState state = EntityState.Unchanged;
            
            entry = repo.Remove(y);

            state = CheckEntryState(state, entry);
            return VerifyEntryState(state, EntityState.Deleted);
        }        
         */


        #endregion
    }
}
