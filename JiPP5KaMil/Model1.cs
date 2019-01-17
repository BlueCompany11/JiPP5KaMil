namespace JiPP5KaMil
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model13")
        {
        }

        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Scoreboard> Scoreboards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasMany(e => e.Scoreboards)
                .WithRequired(e => e.Player)
                .HasForeignKey(e => e.idGracza)
                .WillCascadeOnDelete(false);
        }
    }
}
