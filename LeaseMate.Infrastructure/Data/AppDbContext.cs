using LeaseMate.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeaseMate.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Contract> Contracts => Set<Contract>();
    public DbSet<ContractAttachment> ContractAttachments => Set<ContractAttachment>();
    public DbSet<GeneratedDocument> GeneratedDocuments => Set<GeneratedDocument>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.ToTable("Contracts");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.ContractNumber)
                .HasMaxLength(50);

            entity.Property(x => x.LessorName)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(x => x.LesseeName)
                .HasMaxLength(200)
                .IsRequired();

            entity.Property(x => x.MonthlyRentAmount)
                .HasColumnType("decimal(18,2)");

            entity.Property(x => x.AdvanceAmount)
                .HasColumnType("decimal(18,2)");

            entity.Property(x => x.SecurityDepositAmount)
                .HasColumnType("decimal(18,2)");

            entity.Property(x => x.TotalPaymentReceived)
                .HasColumnType("decimal(18,2)");

            entity.Property(x => x.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Draft");

            entity.HasMany(x => x.Attachments)
                .WithOne(x => x.Contract)
                .HasForeignKey(x => x.ContractId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(x => x.GeneratedDocuments)
                .WithOne(x => x.Contract)
                .HasForeignKey(x => x.ContractId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<ContractAttachment>(entity =>
        {
            entity.ToTable("ContractAttachments");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.FileName)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(x => x.StoredFileName)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(x => x.AttachmentType)
                .HasMaxLength(100);
        });

        modelBuilder.Entity<GeneratedDocument>(entity =>
        {
            entity.ToTable("GeneratedDocuments");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.DocumentType)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(x => x.FileName)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(x => x.StoredFileName)
                .HasMaxLength(255)
                .IsRequired();
        });
    }
}