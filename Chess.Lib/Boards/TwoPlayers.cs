using System;
using System.Collections.Generic;
using System.Linq;
using Chess.Lib.Concrete.Pieces;
using Chess.Lib.Core;
using Chess.Lib.Enum;
using Repository.Core;
using Utilities.Extensions.Enum;

namespace Chess.Lib.Concrete.Boards
{
    public class TwoPlayers : Board
    {
        /// <summary>
        /// This Constructor is to be used when creating a new game.
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="players"></param>
        public TwoPlayers(IGenericRepository handler, params Player[] players) : base()
        {
            if (players.Length != 2)
                throw new ArgumentException(
                    "There is either too few or too many players given to the constructor of the class. There need to be exactly 2, no more no less",
                    nameof(players));

            var (colour1, colour2) = GetColours();
            var (facing1, facing2) = GetFacing();

            Players = new List<IPlayerBoard>()
            {
                new PlayerBoard(handler, this) {Player = players[0], Facing = facing1, Colour = colour1},
                new PlayerBoard(handler, this) {Player = players[1], Facing = facing2, Colour = colour2}
            };

            SetupRuleSet();

            CreateFieldsWithAssignedPieces();
        }

        private void CreateFieldsWithAssignedPieces()
        {
            Fields = new List<IField>();

            for (int y = 1; y <= 8; y++)
            {
                for (int x = 1; x <= 8; x++)
                {
                    var field = AssignPieceIfApplicable(new Field() { Coordinate = new Coordinate() { X = x, Y = y } });

                    Fields.Add(field);
                }
            }
        }

        private IField AssignPieceIfApplicable(IField field)
        {
            if (field.Coordinate.Y == 1 || field.Coordinate.Y == 2)
            {
                var player = Players.First(x => x.Facing == PlayerFacing.Up);

                field = field.Coordinate.Y == 1 ? AssignNonPawns(field, player) : AssignPawns(field, player);
            }
            else if (field.Coordinate.Y == 7 || field.Coordinate.Y == 8)
            {
                var player = Players.First(x => x.Facing == PlayerFacing.Down);

                field = field.Coordinate.Y == 8 ? AssignNonPawns(field, player) : AssignPawns(field, player);
            }

            return field;
        }

        private IField AssignPawns(IField field, IPlayerBoard player)
        {
            field.Piece.Piece =
                player.Pieces.Select(x => x).Where(x => x.Discriminator == nameof(Pawn)).ToList()[
                    field.Coordinate.X - 1];

            return field;
        }

        private IField AssignNonPawns(IField field, IPlayerBoard player)
        {
            field.Piece.Piece = field.Coordinate.X switch
            {
                1 => player.Pieces.First(x => x.Discriminator == nameof(Rook)),
                2 => player.Pieces.First(x => x.Discriminator == nameof(Knight)),
                3 => player.Pieces.First(x => x.Discriminator == nameof(Bishop)),
                4 => player.Pieces.First(x => x.Discriminator == nameof(Queen)),
                5 => player.Pieces.First(x => x.Discriminator == nameof(King)),
                6 => player.Pieces.Last(x => x.Discriminator == nameof(Bishop)),
                7 => player.Pieces.Last(x => x.Discriminator == nameof(Knight)),
                8 => player.Pieces.Last(x => x.Discriminator == nameof(Rook)),
                _ => throw new ArgumentException("Invalid Y coordinate value of 'Field'", nameof(field))
            };

            return field;
        }

        private void SetupRuleSet()
        {
            var rules = new List<IRule>()
            {
                new Rule("Castling - King", "If both the King and a Rook has not moved yet, and no pieces exist between them",
                    "Move the king Two spaces toward the chosen Rook.")
                {
                    Type = RuleType.Movement, Movement = RuleMovement.MonoAxis, Case = RuleCase.Unique,
                    Value = 2, Target = $"{nameof(King)}",
                    Obstruction = RuleObstruction.Care, Requirement = RuleRequirement.FirstMove
                },

                new Rule("Castling - Far Rook", "If both the King and a Rook has not moved yet, and no pieces exist between them",
                    "Move the Rook Three spaces towards the King.")
                {
                    Type = RuleType.Movement, Movement = RuleMovement.MonoAxis, Case = RuleCase.Unique,
                    Value = 3, Target = $"{nameof(Rook)}",
                    Obstruction = RuleObstruction.Care, Requirement = RuleRequirement.FirstMove
                },

                new Rule("Castling - Close Rook", "If both the King and a Rook has not moved yet, and no pieces exist between them",
                    "Move the Rook Two spaces towards the King.")
                {
                    Type = RuleType.Movement, Movement = RuleMovement.MonoAxis, Case = RuleCase.Unique,
                    Value = 2, Target = $"{nameof(Rook)}",
                    Obstruction = RuleObstruction.Care, Requirement = RuleRequirement.FirstMove
                }
            };

            RuleSet = new RuleSet(GetType(), rules) { Type = SetType.Board};
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