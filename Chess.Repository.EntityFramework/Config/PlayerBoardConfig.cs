using System.Collections.Generic;
using Chess.Lib.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.Repository.EntityFramework.Config
{
    public class PlayerBoardConfig : IEntityTypeConfiguration<PlayerBoard>
    {
        public void Configure(EntityTypeBuilder<PlayerBoard> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(x => x.Id).HasColumnName("PlayerBoardId");

            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.HasOne(x => x.Board).WithMany(x => (ICollection<PlayerBoard>)x.Players).HasForeignKey(x => x.BoardId);
            builder.HasOne(x => x.Player).WithMany(x => (ICollection<PlayerBoard>)x.Boards).HasForeignKey(x => x.PlayerId);
            builder.HasMany(x => x.Pieces).WithOne(x => (PlayerBoard)x.PlayerBoard).HasForeignKey(x => x.PlayerBoardId);
        }
    }
}