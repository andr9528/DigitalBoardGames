using Chess.Lib.Concrete;
using Chess.Lib.Concrete.Boards;
using Chess.Repository.EntityFramework.Config.AbstractConfig;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.Repository.EntityFramework.Config.Boards
{
    public class TwoPlayerConfig : AbstractBoardConfig<TwoPlayers>
    {
        public override void Configure(EntityTypeBuilder<TwoPlayers> builder)
        {
            base.Configure(builder);

            builder.HasDiscriminator(x => x.Discriminator).HasValue(nameof(TwoPlayers));

            
        }
    }
}