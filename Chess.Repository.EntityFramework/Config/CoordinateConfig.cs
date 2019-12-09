using Chess.Lib.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.Repository.EntityFramework.Config
{
    public class CoordinateConfig : IEntityTypeConfiguration<Coordinate>
    {
        public void Configure(EntityTypeBuilder<Coordinate> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(x => x.Id).HasColumnName("CoordinateId");

            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.HasOne(x => (Game) x.Game).WithMany().HasForeignKey(x => x.GameId);
        }
    }
}