using Chess.Lib.Concrete;
using Chess.Lib.Concrete.Pieces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.Repository.EntityFramework.Config
{
    public class PieceConfig : IEntityTypeConfiguration<Piece>
    {
        public void Configure(EntityTypeBuilder<Piece> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("PieceId");

            builder.Property(x => x.RowVersion).IsRowVersion();
            builder.Ignore(x => x.FieldId);

            builder.HasOne(x => (RuleSet)x.RuleSet).WithMany().HasForeignKey(x => x.RuleSetId);

            builder.HasOne(x => (FieldPiece) x.Field).WithOne(x => (Piece) x.Piece).HasForeignKey<FieldPiece>(x => x.PieceId).IsRequired(false);
        }
    }
}