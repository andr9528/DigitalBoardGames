using Chess.Lib.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.Repository.EntityFramework.Config
{
    public class PieceConfig : IEntityTypeConfiguration<Piece>
    {
        public void Configure(EntityTypeBuilder<Piece> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(x => x.Id).HasColumnName("PieceId");

            // Defining Version as RowVersion -->
            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.HasDiscriminator(x => x.Discriminator);
        }
    }
}