using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CrawlingConsoleApp.Models
{
    public partial class CrawlingInfoContext : DbContext
    {
        public  CrawlingInfoContext()
        {
        }

        public  CrawlingInfoContext(DbContextOptions<CrawlingInfoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Auctions> Auctions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-DGENJK4\\SQLEXPRESS;DataBase=CrawlingInfo;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auctions>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EndMonth)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EndYear)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Link)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StartMonth)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime)
                    .HasColumnName("startTime")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StartYear)
                    .HasColumnName("startYear")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
