using System;
using System.Collections.Generic;
using Chess.Lib.Core;
using Chess.Lib.Enum;
using Repository.Core;
using Utilities.Extensions.Enum;

namespace Chess.Lib.Concrete.Boards
{
    public class TwoPlayers : Board
    {
        private readonly IGenericRepository _handler;

        /// <summary>
        /// This Constructor is to be used when creating a new game.
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="players"></param>
        public TwoPlayers(IGenericRepository handler, params Player[] players)
        {
            _handler = handler;
            IsInstantiated = true;

            if (players.Length != 2)
                throw new ArgumentException(
                    "There is either too few or too many players given to the constructor of the class. There need to be exactly 2, no more no less",
                    nameof(players));

            var (colour1, colour2) = GetColours();

            var (facing1, facing2) = GetFacing();

            Players = new List<IPlayerBoard>()
            {
                new PlayerBoard(_handler, this) {Player = players[0], Facing = facing1, Colour = colour1},
                new PlayerBoard(_handler, this) {Player = players[1], Facing = facing2, Colour = colour2}
            };
        }

        /// <summary>
        /// This Constructor is to be used by...
        ///  - Entity Framework
        ///  - As input to 'GenericRepositoryHandler' Methods.
        /// </summary>
        public TwoPlayers()
        {
            
        }

        public override bool VerifyMove(IMove move, PlayerFacing directionFacing)
        {
            throw new System.NotImplementedException();
        }

        private (PlayerColour colour1, PlayerColour colour2) GetColours()
        {
            var colour1 = EnumExtensions.RandomEnumValue<PlayerColour>();
            var colour2 = PlayerColour.Null;

            while (colour2 == colour1 || colour2 == PlayerColour.Null)
            {
                colour2 = EnumExtensions.RandomEnumValue<PlayerColour>();
            }

            return (colour1, colour2);
        }

        private (PlayerFacing facing1, PlayerFacing facing2) GetFacing()
        {
            var facing1 = PlayerFacing.Null;

            while (facing1 == PlayerFacing.Null && (facing1 != PlayerFacing.Down || facing1 != PlayerFacing.Up))
            {
                facing1 = EnumExtensions.RandomEnumValue<PlayerFacing>();
            }

            var facing2 = PlayerFacing.Null;

            while ((facing2 == facing1 || facing2 == PlayerFacing.Null) && (facing2 != PlayerFacing.Down || facing2 != PlayerFacing.Up))
            {
                facing2 = EnumExtensions.RandomEnumValue<PlayerFacing>();
            }

            return (facing1, facing2);
        }
    }
}