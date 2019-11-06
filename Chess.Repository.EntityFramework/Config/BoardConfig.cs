using Chess.Lib.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.Repository.EntityFramework.Config
{
    public class BoardConfig : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(x => x.Id).HasColumnName("BoardId");

            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.HasDiscriminator(x => x.Discriminator);

            builder.HasOne(x => x.RuleSet).WithOne().HasForeignKey<Board>(x => x.RuleSetId);
        }
    }
}