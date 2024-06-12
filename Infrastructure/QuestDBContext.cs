using Microsoft.EntityFrameworkCore;
using QuestSystem.Domain.Aggregates;

namespace QuestSystem.Infrastructure;

public class QuestDbContext : DbContext
{
     public DbSet<User> Users { get; set; }

        public DbSet<Quest> Quests { get; set; }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<UserQuest> UserQuests { get; set; }

        public QuestDbContext(DbContextOptions<QuestDbContext> options) : base(options)
        {
        }

        public QuestDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(k => k.Id);

            modelBuilder.Entity<User>().ToTable(nameof(User));

            modelBuilder.Entity<User>().Property(r => r.Id).ValueGeneratedNever();

            // modelBuilder.Entity<User>(entity =>
            // {
            //     entity
            //         .HasMany(user => user.VisitedQuests)
            //         .WithOne(publication => publication.User);
            // });
            
            modelBuilder.Entity<UserQuest>(entity =>
            {
                entity.HasKey(source => new { source.UserId, source.QuestId });
            });
            
            modelBuilder.Entity<User>().OwnsOne(x => x.UserName,
                a =>
                {
                    a.Property(p => p.FirstName)
                        .HasColumnName(nameof(User.UserName.FirstName))
                        .HasMaxLength(50)
                        .IsRequired();
                });

            modelBuilder.Entity<User>().OwnsOne(x => x.UserName,
                a =>
                {
                    a.Property(p => p.LastName)
                        .HasColumnName(nameof(User.UserName.LastName))
                        .HasMaxLength(50)
                        .IsRequired();
                });

           modelBuilder.Entity<User>().OwnsOne(x => x.Email,
                a =>
                {
                    a.Property(p => p.Email)
                        .HasColumnName(nameof(User.Email))
                        .HasMaxLength(50)
                        .IsRequired();
                });
           
           modelBuilder.Entity<Booking>().OwnsOne(x => x.Address,
               a =>
               {
                   a.Property(p => p.Value)
                       .HasColumnName(nameof(Booking.Address))
                       .HasMaxLength(100)
                       .IsRequired();
               });
           
           modelBuilder.Entity<Booking>().OwnsOne(x => x.DateBooking,
               a =>
               {
                   a.Property(p => p.Value)
                       .HasColumnName(nameof(Booking.DateBooking))
                       .HasMaxLength(100)
                       .IsRequired();
               });
           
           modelBuilder.Entity<Booking>().OwnsOne(x => x.OrderNumber,
               a =>
               {
                   a.Property(p => p.Value)
                       .HasColumnName(nameof(Booking.OrderNumber))
                       .HasMaxLength(100)
                       .IsRequired();
               });
           
           modelBuilder.Entity<Booking>().OwnsOne(x => x.Price,
               a =>
               {
                   a.Property(p => p.Value)
                       .HasColumnName(nameof(Booking.Price))
                       .IsRequired();
               });
           
           modelBuilder.Entity<Quest>().OwnsOne(x => x.Address,
               a =>
               {
                   a.Property(p => p.Value)
                       .HasColumnName(nameof(Quest.Address))
                       .IsRequired();
               });
           
           modelBuilder.Entity<Quest>().OwnsOne(x => x.Price,
               a =>
               {
                   a.Property(p => p.Value)
                       .HasColumnName(nameof(Quest.Price))
                       .IsRequired();
               });
           
           modelBuilder.Entity<UserQuest>(entity =>
           {
               entity.HasKey(source => new { source.UserId, source.QuestId });
           });

        }
}