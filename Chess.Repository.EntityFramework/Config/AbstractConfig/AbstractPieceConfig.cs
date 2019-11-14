using Chess.Lib.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chess.Repository.EntityFramework.Config.AbstractConfig
{
    public abstract class AbstractPieceConfig<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity: Piece
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasBaseType<Piece>();
            
        }
    }
}