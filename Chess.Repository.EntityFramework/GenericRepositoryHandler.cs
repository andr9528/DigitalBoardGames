﻿using System;
using System.Collections.Generic;
using Chess.Lib.Core;
using Repository.Core;

namespace Chess.Repository.EntityFramework
{
    public class GenericRepositoryHandler : BaseRepositoryHandler, IGenericRepository
    {
        public GenericRepositoryHandler(ChessRepository repository) : base(repository)
        {

        }

        bool IGenericRepository.Add<T>(T element)
        {
            bool result = false;

            switch (element)
            {
                // Create cases for all the different classes that should be addable to the database.
                // Remember to setup Uniqueness for columns that are not allowed to contain duplicates

                // Example:
                // case IYourDomainClass y:
                //    result = AddYourDomainClass(y);
                //    break;
                case IPiece p:
                    throw new InvalidOperationException(
                        "You are not allowed to add a Piece directly. Add it by creating and adding a 'Game' as it chains down to all the needed Entities.");
                case IBoard b:
                    throw new InvalidOperationException(
                        "You are not allowed to add a Board directly. Add it by creating and adding a 'Game' as it chains down to all the needed Entities.");
                case IPlayerBoard p:
                    throw new InvalidOperationException(
                        "You are not allowed to add a PlayerBoard directly. Add it by creating and adding a 'Game' as it chains down to all the needed Entities.");
                case IField f:
                    throw new InvalidOperationException(
                        "You are not allowed to add a Field directly. Add it by creating and adding a 'Game' as it chains down to all the needed Entities.");
                case IRule r:
                    throw new InvalidOperationException(
                        "You are not allowed to add a Rule directly. Add it by creating and adding a 'Game' as it chains down to all the needed Entities.");
                case IPlayer p:
                    throw new InvalidOperationException(
                        "You are not allowed to add a Player directly. Add it by creating and adding a 'Game' as it chains down to all the needed Entities.");
                case ICoordinate c:
                    throw new InvalidOperationException(
                        "You are not allowed to add a Coordinate directly. Add it by creating and adding a 'Game' as it chains down to all the needed Entities.");
                case IGame g:
                    result = AddGame(g);
                    break;
                case IRuleSet r:
                    result = AddRuleSet(r);
                    break;
                default:
                    throw new Exception("ERROR ERROR ERROR");
            }

            return result;
        }

        string IGenericRepository.AddMultiple<T>(ICollection<T> elements)
        {
            List<bool> results = new List<bool>();

            foreach (var element in elements)
            {
                results.Add((this as IGenericRepository).Add(element));
            }

            return GetAmountAdded(results);
        }

        bool IGenericRepository.Delete<T>(T element)
        {
            if (element.Id == 0)
                throw new Exception(string.Format("I need an Id to figure out what to remove"), new ArgumentException("Id of predicate can't be 0"));
            bool result = false;

            switch (element)
            {
                //Create cases for all the different classes that should be updateable in the database.

                // Example:
                // case IYourDomainClass y:
                //    result = DeleteYourDomainClass(y);
                //    break;
                default:
                    throw new Exception("ERROR ERROR ERROR");
            }

            return result;
        }

       

        T IGenericRepository.Find<T>(T predicate)
        {
            IEntity entity = null;
            switch (predicate)
            {
                // Create cases for all the different classes that should be retriable from the database

                // Example:
                // case IYourDomainClass y:
                //    entity = FindYourDomainClass(y);
                //    break;
                default:
                    throw new Exception("ERROR ERROR ERROR");
            }

            return entity as T;
        }

        ICollection<T> IGenericRepository.FindMultiple<T>(T predicate)
        {
            ICollection<T> entities = null;
            switch (predicate)
            {
                // Create cases for all the different classes that should be retriable from the database

                // Example:
                // case IYourDomainClass y:
                //    entities = FindMultipleYourDomainClassInPlural(y) as ICollection<T>;
                //    break;
                default:
                    throw new Exception("ERROR ERROR ERROR");
            }

            return entities;
        }

        bool IGenericRepository.Update<T>(T element)
        {
            if (element.Id == 0)
                throw new Exception(string.Format("I need an Id to figure out what to update"), new ArgumentException("Id of predicate can not be 0"));
            bool result = false;

            switch (element)
            {
                //Create cases for all the differnet classes that should be updateable in the database.

                // Example:
                // case IYourDomainClass y:
                //    result = UpdateYourDomainClass(y);
                //    break;
                default:
                    throw new Exception("ERROR ERROR ERROR");
            }
            
            return result;
        }


    }
}
