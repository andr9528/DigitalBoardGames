using Chess.Lib.Concrete;
using Chess.Lib.Concrete.Pieces;
using Chess.Repository.EntityFramework.Config.AbstractConfig;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.Repository.EntityFramework.Config.Pieces
{
    public class BishopConfig : AbstractPieceConfig<Bishop>
    {
        public override void Configure(EntityTypeBuilder<Bishop> builder)
        {
            base.Configure(builder);

            builder.HasDiscriminator(x => x.Discriminator).HasValue(nameof(Bishop));

            //builder.HasOne(x => (RuleSet)x.RuleSet).WithOne().HasForeignKey<Bishop>(x => x.RuleSetId);
        }
    }
}