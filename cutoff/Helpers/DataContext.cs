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

    public virtual DbSet<EpisodeDTO> Episodes { get; set; }

    public virtual DbSet<GenreDTO> Genres { get; set; }

    public virtual DbSet<NetworkDTO> Networks { get; set; }

    public virtual DbSet<SeasonDTO> Seasons { get; set; }

    public virtual DbSet<ShowDTO> Shows { get; set; }

    public virtual DbSet<ShowEpisodeDTO> ShowEpisodes { get; set; }

    public virtual DbSet<ShowGenreDTO> ShowGenres { get; set; }

    public virtual DbSet<ShowNetworkDTO> ShowNetworks { get; set; }

    public virtual DbSet<ShowSeasonDTO> ShowSeasons { get; set; }

    public virtual DbSet<UserDTO> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=./Database/cutoff.db;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EpisodeDTO>(entity =>
        {
            entity.HasKey(e => e.EpisodeNumber);

            entity.ToTable("Episode");

            entity.Property(e => e.EpisodeNumber)
                .ValueGeneratedNever()
                .HasColumnType("INT");
        });

        modelBuilder.Entity<GenreDTO>(entity =>
        {
            entity.HasKey(e => e.GenreId);

            entity.ToTable("Genre");

            entity.Property(e => e.GenreId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("GenreID");
            entity.Property(e => e.GenreName).HasColumnType("VARCHAR(100)");
        });

        modelBuilder.Entity<NetworkDTO>(entity =>
        {
            entity.HasKey(e => e.NetworkId);

            entity.ToTable("Network");

            entity.Property(e => e.NetworkId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("NetworkID");
            entity.Property(e => e.NetworkName).HasColumnType("VARCHAR(150)");
        });

        modelBuilder.Entity<SeasonDTO>(entity =>
        {
            entity.HasKey(e => e.SeasonNumber);

            entity.ToTable("Season");

            entity.Property(e => e.SeasonNumber)
                .ValueGeneratedNever()
                .HasColumnType("INT");
        });

        modelBuilder.Entity<ShowDTO>(entity =>
        {
            entity.HasKey(e => e.ShowId);

            entity.ToTable("Show");

            entity.Property(e => e.ShowId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("ShowID");
            entity.Property(e => e.ShowName).HasColumnType("VARCHAR(200)");
        });

        modelBuilder.Entity<ShowEpisodeDTO>(entity =>
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

        modelBuilder.Entity<ShowGenreDTO>(entity =>
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

        modelBuilder.Entity<ShowNetworkDTO>(entity =>
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

        modelBuilder.Entity<ShowSeasonDTO>(entity =>
        {
            entity.HasKey(e => new { e.ShowId, e.SeasonNumber });

            entity.ToTable("ShowSeason");

            entity.Property(e => e.ShowId)
                .HasColumnType("INT")
                .HasColumnName("ShowID");
            entity.Property(e => e.SeasonNumber).HasColumnType("INT");
        });

        modelBuilder.Entity<UserDTO>(entity =>
        {
            entity.HasKey(e => e.UserName);

            entity.ToTable("User");

            entity.Property(e => e.UserName).HasColumnType("VARCHAR(30)");
            entity.Property(e => e.UserFirst).HasColumnType("VARCHAR(50)");
            entity.Property(e => e.UserLast).HasColumnType("VARCHAR(50)");
            entity.Property(e => e.UserEmail).HasColumnType("VARCHAR(65)");
            entity.Property(e => e.UserPassword).HasColumnType("VARCHAR(60)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
