using Chess.Lib.Concrete;
using Chess.Lib.Concrete.Pieces;
using Chess.Repository.EntityFramework.Config.AbstractConfig;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.Repository.EntityFramework.Config.Pieces
{
    public class KingConfig : AbstractPieceConfig<King>
    {
        public override void Configure(EntityTypeBuilder<King> builder)
        {
            base.Configure(builder);

            builder.HasDiscriminator(x => x.Discriminator).HasValue(nameof(King));
        }
    }
}