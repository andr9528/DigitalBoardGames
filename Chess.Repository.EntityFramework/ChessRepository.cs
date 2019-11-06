using Chess.Lib.Concrete;
using Chess.Repository.EntityFramework.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Chess.Repository.EntityFramework
{
    public class ChessRepository : DbContext
    {
        private readonly DbContextOptions<ChessRepository> options;
        private readonly bool _useLazyLoading;
        public ChessRepository(DbContextOptions<ChessRepository> options) : base(options)
        {
            this.options = options;
            _useLazyLoading = true;

            //ChangeTracker.AutoDetectChangesEnabled = true;
        }

        // Underneath create as many DbSet' as you have domain classes you wish to persist.
        // Each DbSet should have a Config file applied in the method 'OnModelCreating'

        // e.g
        // public virtual DbSet<YourDomainClass> YourDomainClassInPlural { get; set; }

        public virtual DbSet<Piece> Pieces { get; set; }
        public virtual DbSet<RuleSet> RuleSets { get; set; }
        public virtual DbSet<Rule> Rules { get; set; }
        public virtual DbSet<PlayerBoard> PlayerBoards { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Field> Fields { get; set; }
        public virtual DbSet<Move> Moves { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Board> Boards { get; set; }
        public virtual DbSet<Coordinate> Coordinates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // To Lazy Load properties they require the keyword Virtual.
            // Making use of Lazy load means that the property only loads as it is about to be used,
            // which improves performance of the program
            optionsBuilder.UseLazyLoadingProxies(_useLazyLoading);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Create a new class under Config, with the name of the domain class you wish to persist,
            // ending it in Config, to differentiate it from the actual class

            // e.g
            // modelBuilder.ApplyConfiguration(new YourDomainClassConfig());

            modelBuilder.ApplyConfiguration(new PieceConfig());
            modelBuilder.ApplyConfiguration(new RuleSetConfig());
            modelBuilder.ApplyConfiguration(new RuleConfig());
            modelBuilder.ApplyConfiguration(new PlayerBoardConfig());
            modelBuilder.ApplyConfiguration(new PlayerConfig());
            modelBuilder.ApplyConfiguration(new FieldConfig());
            modelBuilder.ApplyConfiguration(new MoveConfig());
            modelBuilder.ApplyConfiguration(new GameConfig());
            modelBuilder.ApplyConfiguration(new BoardConfig());
            modelBuilder.ApplyConfiguration(new CoordinateConfig());

        }
    }
}
