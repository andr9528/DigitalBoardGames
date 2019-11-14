using Chess.Lib.Concrete;
using Chess.Lib.Concrete.Pieces;
using Chess.Repository.EntityFramework.Config.AbstractConfig;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.Repository.EntityFramework.Config.Pieces
{
    public class QueenConfig : AbstractPieceConfig<Queen>
    {
        public override void Configure(EntityTypeBuilder<Queen> builder)
        {
            base.Configure(builder);

            builder.HasDiscriminator(x => x.Discriminator).HasValue(nameof(Queen));

            //builder.HasOne(x => (RuleSet)x.RuleSet).WithOne().HasForeignKey<Queen>(x => x.RuleSetId);
        }
    }
}