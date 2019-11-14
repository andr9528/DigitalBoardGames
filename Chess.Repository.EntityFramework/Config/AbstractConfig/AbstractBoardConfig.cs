using Chess.Lib.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.Repository.EntityFramework.Config.AbstractConfig
{
    public abstract class AbstractBoardConfig<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Board
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasBaseType<Board>();
          
        }
    }
}