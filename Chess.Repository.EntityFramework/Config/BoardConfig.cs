using Chess.Lib.Concrete;
using Chess.Lib.Concrete.Boards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.Repository.EntityFramework.Config
{
    public class BoardConfig : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("BoardId");

            builder.Property(x => x.RowVersion).IsRowVersion();

            builder.HasOne(x => (RuleSet)x.RuleSet).WithOne().HasForeignKey<Board>(x => x.RuleSetId);
        }
    }
}