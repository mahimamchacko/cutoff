using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using cutoff.Models;

namespace cutoff.Helpers;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Episode> Episodes { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Network> Networks { get; set; }

    public virtual DbSet<Season> Seasons { get; set; }

    public virtual DbSet<Show> Shows { get; set; }

    public virtual DbSet<ShowEpisode> ShowEpisodes { get; set; }

    public virtual DbSet<ShowGenre> ShowGenres { get; set; }

    public virtual DbSet<ShowNetwork> ShowNetworks { get; set; }

    public virtual DbSet<ShowSeason> ShowSeasons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=./Database/cutoff.db;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Episode>(entity =>
        {
            entity.HasKey(e => e.EpisodeNumber);

            entity.ToTable("Episode");

            entity.Property(e => e.EpisodeNumber)
                .ValueGeneratedNever()
                .HasColumnType("INT");
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.ToTable("Genre");

            entity.Property(e => e.GenreId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("GenreID");
            entity.Property(e => e.GenreName).HasColumnType("VARCHAR(100)");
        });

        modelBuilder.Entity<Network>(entity =>
        {
            entity.ToTable("Network");

            entity.Property(e => e.NetworkId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("NetworkID");
            entity.Property(e => e.NetworkName).HasColumnType("VARCHAR(150)");
        });

        modelBuilder.Entity<Season>(entity =>
        {
            entity.HasKey(e => e.SeasonNumber);

            entity.ToTable("Season");

            entity.Property(e => e.SeasonNumber)
                .ValueGeneratedNever()
                .HasColumnType("INT");
        });

        modelBuilder.Entity<Show>(entity =>
        {
            entity.ToTable("Show");

            entity.Property(e => e.ShowId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("ShowID");
            entity.Property(e => e.ShowName).HasColumnType("VARCHAR(200)");
        });

        modelBuilder.Entity<ShowEpisode>(entity =>
        {
            entity.HasKey(e => new { e.ShowId, e.SeasonNumber, e.EpisodeNumber });

            entity.ToTable("ShowEpisode");

            entity.Property(e => e.ShowId)
                .HasColumnType("INT")
                .HasColumnName("ShowID");
            entity.Property(e => e.SeasonNumber).HasColumnType("INT");
            entity.Property(e => e.EpisodeNumber).HasColumnType("INT");
            entity.Property(e => e.EpisodeName).HasColumnType("VARCHAR(300)");
        });

        modelBuilder.Entity<ShowGenre>(entity =>
        {
            entity.HasKey(e => new { e.ShowId, e.GenreId });

            entity.ToTable("ShowGenre");

            entity.Property(e => e.ShowId)
                .HasColumnType("INT")
                .HasColumnName("ShowID");
            entity.Property(e => e.GenreId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("GenreID");
        });

        modelBuilder.Entity<ShowNetwork>(entity =>
        {
            entity.HasKey(e => new { e.ShowId, e.NetworkId });

            entity.ToTable("ShowNetwork");

            entity.Property(e => e.ShowId)
                .HasColumnType("INT")
                .HasColumnName("ShowID");
            entity.Property(e => e.NetworkId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("NetworkID");
        });

        modelBuilder.Entity<ShowSeason>(entity =>
        {
            entity.HasKey(e => new { e.ShowId, e.SeasonNumber });

            entity.ToTable("ShowSeason");

            entity.Property(e => e.ShowId)
                .HasColumnType("INT")
                .HasColumnName("ShowID");
            entity.Property(e => e.SeasonNumber).HasColumnType("INT");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
