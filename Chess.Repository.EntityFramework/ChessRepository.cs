using Chess.Lib.Concrete;
using Chess.Repository.EntityFramework.Config;
using Microsoft.EntityFrameworkCore;

namespace Chess.Repository.EntityFramework
{
    public class ChessRepository : DbContext
    {
        private readonly DbContextOptions<ChessRepository> options;
        private readonly bool useLazyLoading;
        public ChessRepository(DbContextOptions<ChessRepository> options) : base(options)
        {
            this.options = options;
            useLazyLoading = true;

            //Database.Migrate();
        }

        // Underneath create as many DbSet' as you have domain classes you wish to persist.
        // Each DbSet should have a Config file aplied in the method 'OnModelCreating'

        // e.g
        // public virtual DbSet<YourDomainClass> YourDomainClassInPlural { get; set; }

        public virtual DbSet<Piece> Pieces { get; set; }
        public virtual DbSet<RuleSet> RuleSets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // To Lazy Load properties they require the keyword Virtual.
            // Making use of Lazy load means that the property only loads as it is about to be used,
            // which improves performance of the program
            optionsBuilder.UseLazyLoadingProxies(useLazyLoading);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Create a new class under Config, with the name of the domain class you wish to persist,
            // ending it in Config, to differentiate it from the actual class

            // e.g
            // modelBuilder.ApplyConfiguration(new YourDomainClassConfig());

            modelBuilder.ApplyConfiguration(new PieceConfig());
            modelBuilder.ApplyConfiguration(new RuleSetConfig());
        }
    }
}
