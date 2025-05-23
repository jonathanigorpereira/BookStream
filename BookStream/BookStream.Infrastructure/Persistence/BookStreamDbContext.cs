﻿using BookStream.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStream.Infrastructure.Persistence;
public class BookStreamDbContext : DbContext
{
    public BookStreamDbContext(DbContextOptions<BookStreamDbContext> options)
        : base(options)
    {

    }

    public DbSet<Book> Books { get; set; }
    public DbSet<BookGenre> Genres { get; set; }
    public DbSet<Author> Authors { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<BookGenre>(b =>
            {
                b.HasKey(b => b.Id);
            });

        builder
            .Entity<AgeRating>(a =>
            {
                a.HasKey(a => a.Id);
            });

        builder
            .Entity<Author>(a =>
            {
                a.HasKey(a => a.Id);

                a.HasMany(a=>a.Books)
                    .WithOne(b=>b.Author)
                    .HasForeignKey(b=>b.AuthorId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        builder
            .Entity<Book>(s =>
            {
                s.HasKey(s=> s.Id);

                //s.HasOne(g => g.Author)
                //   .WithMany()
                //   .HasForeignKey(g => g.AuthorId)
                //   .OnDelete(DeleteBehavior.Restrict);

                s.HasOne(g => g.Genre)
                    .WithMany()
                    .HasForeignKey(g => g.IdGenre)
                    .OnDelete(DeleteBehavior.Restrict);

                s.HasOne(a=>a.AgeRating)
                    .WithMany()
                    .HasForeignKey(a=>a.IdAgeRating)
                    .OnDelete(DeleteBehavior.Restrict);
            });

        base.OnModelCreating(builder);
    }
}
