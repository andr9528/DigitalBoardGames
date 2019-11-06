using Chess.Lib.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.Repository.EntityFramework.Config
{
    public class GameConfig : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(x => x.Id).HasColumnName("GameId");

            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.HasOne(x => x.Board).WithOne(x => (Game) x.Game).HasForeignKey<Game>(x => x.BoardId).HasForeignKey<Board>(x => x.GameId);
            builder.HasOne(x => x.RuleSet).WithOne().HasForeignKey<Game>(x => x.RuleSetId);
        }
    }
}