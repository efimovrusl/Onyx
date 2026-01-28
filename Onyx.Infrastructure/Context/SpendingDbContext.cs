using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Onyx.Infrastructure.DbModels;

namespace Onyx.Infrastructure.Context;

public partial class SpendingDbContext : DbContext
{
    public SpendingDbContext(DbContextOptions<SpendingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<ExpensesConsumer> ExpensesConsumers { get; set; }

    public virtual DbSet<ExpensesPayer> ExpensesPayers { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupsUser> GroupsUsers { get; set; }

    public virtual DbSet<LoginSecret> LoginSecrets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum("currency_type", new[] { "GBP", "EUR", "USD", "CAD", "PLN", "UAH" });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("expenses_pkey");

            entity.ToTable("expenses");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(64)
                .HasColumnName("description");
            entity.Property(e => e.GroupId).HasColumnName("group_id");

            entity.HasOne(d => d.Group).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("expenses_group_id_fkey");
        });

        modelBuilder.Entity<ExpensesConsumer>(entity =>
        {
            entity.HasKey(e => new { e.ExpenseId, e.ConsumerId }).HasName("expenses_consumers_pkey");

            entity.ToTable("expenses_consumers");

            entity.Property(e => e.ExpenseId).HasColumnName("expense_id");
            entity.Property(e => e.ConsumerId).HasColumnName("consumer_id");
            entity.Property(e => e.DebtShare).HasColumnName("debt_share");

            entity.HasOne(d => d.Consumer).WithMany(p => p.ExpensesConsumers)
                .HasForeignKey(d => d.ConsumerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("expenses_consumers_consumer_id_fkey");

            entity.HasOne(d => d.Expense).WithMany(p => p.ExpensesConsumers)
                .HasForeignKey(d => d.ExpenseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("expenses_consumers_expense_id_fkey");
        });

        modelBuilder.Entity<ExpensesPayer>(entity =>
        {
            entity.HasKey(e => new { e.ExpenseId, e.PayerId }).HasName("expenses_payers_pkey");

            entity.ToTable("expenses_payers");

            entity.Property(e => e.ExpenseId).HasColumnName("expense_id");
            entity.Property(e => e.PayerId).HasColumnName("payer_id");
            entity.Property(e => e.Amount).HasColumnName("amount");

            entity.HasOne(d => d.Expense).WithMany(p => p.ExpensesPayers)
                .HasForeignKey(d => d.ExpenseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("expenses_payers_expense_id_fkey");

            entity.HasOne(d => d.Payer).WithMany(p => p.ExpensesPayers)
                .HasForeignKey(d => d.PayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("expenses_payers_payer_id_fkey");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("groups_pkey");

            entity.ToTable("groups");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(32)
                .HasColumnName("name");
        });

        modelBuilder.Entity<GroupsUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("groups_users");

            entity.HasIndex(e => new { e.UserId, e.GroupId }, "groups_users_user_id_group_id_key").IsUnique();

            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Group).WithMany()
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("groups_users_group_id_fkey");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("groups_users_user_id_fkey");
        });

        modelBuilder.Entity<LoginSecret>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("login_secrets_pkey");

            entity.ToTable("login_secrets");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.HashedPassword)
                .HasMaxLength(32)
                .HasColumnName("hashed_password");

            entity.HasOne(d => d.User).WithOne(p => p.LoginSecret)
                .HasForeignKey<LoginSecret>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("login_secrets_user_id_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("now()")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(64)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(32)
                .HasColumnName("first_name");
            entity.Property(e => e.IsDeleted)
                .HasDefaultValue(false)
                .HasColumnName("is_deleted");
            entity.Property(e => e.LastName)
                .HasMaxLength(32)
                .HasColumnName("last_name");
            entity.Property(e => e.Username)
                .HasMaxLength(32)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
