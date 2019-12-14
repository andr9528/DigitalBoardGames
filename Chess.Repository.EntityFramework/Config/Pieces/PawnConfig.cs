using Chess.Lib.Concrete;
using Chess.Lib.Concrete.Pieces;
using Chess.Repository.EntityFramework.Config.AbstractConfig;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.Repository.EntityFramework.Config.Pieces
{
    public class PawnConfig : AbstractPieceConfig<Pawn>
    {
        public override void Configure(EntityTypeBuilder<Pawn> builder)
        {
            base.Configure(builder);

            builder.HasDiscriminator(x => x.Discriminator).HasValue(nameof(Pawn));
        }
    }
}