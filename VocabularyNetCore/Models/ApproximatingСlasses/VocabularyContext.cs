﻿using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VocabularyNetCore.Models.ApproximatingСlasses
{
    public partial class VocabularyContext : DbContext
    {
        public VocabularyContext()
        {
        }

        public VocabularyContext(DbContextOptions<VocabularyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ContextTable> ContextTable { get; set; }
        public virtual DbSet<ExamplesTable> ExamplesTable { get; set; }
        public virtual DbSet<IrregularVerbsTable> IrregularVerbsTable { get; set; }
        public virtual DbSet<PriorityTable> PriorityTable { get; set; }
        public virtual DbSet<UsersTable> UsersTable { get; set; }
        public virtual DbSet<WordsTable> WordsTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Vocabulary;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContextTable>(entity =>
            {
                entity.HasKey(e => new { e.IdWord, e.IdExample })
                    .HasName("PK_ConnectingTable");

                entity.Property(e => e.IdWord).ValueGeneratedNever();

                entity.Property(e => e.ContextualTranslation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdExampleNavigation)
                    .WithMany(p => p.ContextTable)
                    .HasForeignKey(d => d.IdExample)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConnectingTable_ExamplesTable");

                entity.HasOne(d => d.IdWordNavigation)
                    .WithMany(p => p.ContextTable)
                    .HasForeignKey(d => d.IdWord)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConnectingTable_WordsTable");
            });

            modelBuilder.Entity<ExamplesTable>(entity =>
            {
                entity.HasKey(e => e.IdExample);

                entity.Property(e => e.Example)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ExampleTranslation)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<IrregularVerbsTable>(entity =>
            {
                entity.HasKey(e => e.IdWord)
                    .HasName("PK_VerbsTable");

                entity.Property(e => e.IdWord).ValueGeneratedNever();

                entity.Property(e => e.PastParticiple)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.PastSimple)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.IdWordNavigation)
                    .WithOne(p => p.IrregularVerbsTable)
                    .HasForeignKey<IrregularVerbsTable>(d => d.IdWord)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VerbsTable_WordsTable");
            });

            modelBuilder.Entity<PriorityTable>(entity =>
            {
                entity.HasKey(e => new { e.IdUser, e.IdWord });

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.PriorityTable)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PriorityTable_UsersTable");

                entity.HasOne(d => d.IdWordNavigation)
                    .WithMany(p => p.PriorityTable)
                    .HasForeignKey(d => d.IdWord)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PriorityTable_WordsTable");
            });

            modelBuilder.Entity<UsersTable>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.Property(e => e.IdUser).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<WordsTable>(entity =>
            {
                entity.HasKey(e => e.IdWord)
                    .HasName("PK_WordsTable_1");

                entity.HasIndex(e => e.IdWord)
                    .HasName("IX_WordsTable");

                entity.Property(e => e.PartOfSpeech).HasMaxLength(20);

                entity.Property(e => e.Word)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.WordTranslation)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
