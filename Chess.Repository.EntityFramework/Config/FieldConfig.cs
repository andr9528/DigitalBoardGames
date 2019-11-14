using System.Collections;
using System.Collections.Generic;
using Chess.Lib.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.Repository.EntityFramework.Config
{
    public class FieldConfig : IEntityTypeConfiguration<Field>
    {
        public void Configure(EntityTypeBuilder<Field> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(x => x.Id).HasColumnName("FieldId");

            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.HasOne(x => (Piece)x.Piece).WithOne().HasForeignKey<Field>(x => x.PieceId);
            builder.HasOne(x => (Coordinate)x.Coordinate).WithOne().HasForeignKey<Field>(x => x.CoordinateId);
            builder.HasOne(x => (Board)x.Board).WithMany(x => (ICollection<Field>)x.Fields).HasForeignKey(x => x.BoardId);
        }
    }
}