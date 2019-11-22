using Chess.Lib.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.Repository.EntityFramework.Config
{
    public class FieldPieceConfig : IEntityTypeConfiguration<FieldPiece>
    {
        public void Configure(EntityTypeBuilder<FieldPiece> builder)
        {
            builder.HasKey(s => new {s.Id, s.FieldId, s.PieceId});
            builder.Property(x => x.Id).HasColumnName("FieldPieceId");
        }
    }
}