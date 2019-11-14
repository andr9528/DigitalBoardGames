using System.Collections;
using System.Collections.Generic;
using Chess.Lib.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.Repository.EntityFramework.Config
{
    public class MoveConfig : IEntityTypeConfiguration<Move>
    {
        public void Configure(EntityTypeBuilder<Move> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(x => x.Id).HasColumnName("MoveId");

            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.HasOne(x => (Coordinate)x.From).WithOne().HasForeignKey<Move>(x => x.CoordinateFromId);
            builder.HasOne(x => (Coordinate)x.To).WithOne().HasForeignKey<Move>(x => x.CoordinateToId);
            builder.HasOne(x => (Piece)x.Piece).WithMany(x => (ICollection<Move>)x.MoveHistory).HasForeignKey(x => x.PieceId);
        }
    }
}