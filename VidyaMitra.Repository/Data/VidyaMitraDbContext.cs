using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using VidyaMitra.Domain.Entities;

namespace VidyaMitra.Repository.Data;

public partial class VidyaMitraDbContext : DbContext
{
    public VidyaMitraDbContext()
    {
    }

    public VidyaMitraDbContext(DbContextOptions<VidyaMitraDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<StudentContactDetail> StudentContactDetails { get; set; }

    public virtual DbSet<StudentEmeregencyContact> StudentEmeregencyContacts { get; set; }

    public virtual DbSet<StudentNotification> StudentNotifications { get; set; }

    public virtual DbSet<StudentParentDetail> StudentParentDetails { get; set; }

    public virtual DbSet<StudentProfile> StudentProfiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
 //   => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=VidyaMitraDb;Username=postgres;Password=HumTum");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentContactDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("StudentContactDetail");

            entity.Property(e => e.AlternatePhoneNumber).HasMaxLength(10);
            entity.Property(e => e.CAddressLine)
                .HasMaxLength(500)
                .HasColumnName("C_AddressLine");
            entity.Property(e => e.CCity)
                .HasMaxLength(25)
                .HasColumnName("C_City");
            entity.Property(e => e.CCountry)
                .HasMaxLength(25)
                .HasColumnName("C_Country");
            entity.Property(e => e.CPinCode)
                .HasMaxLength(5)
                .HasColumnName("C_PinCode");
            entity.Property(e => e.CState)
                .HasMaxLength(25)
                .HasColumnName("C_State");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.PAddressLine1)
                .HasMaxLength(200)
                .HasColumnName("P_AddressLine1");
            entity.Property(e => e.PAddressLine2)
                .HasMaxLength(200)
                .HasColumnName("P_AddressLine2");
            entity.Property(e => e.PAddressLine3)
                .HasMaxLength(200)
                .HasColumnName("P_AddressLine3");
            entity.Property(e => e.PCity)
                .HasMaxLength(25)
                .HasColumnName("P_City");
            entity.Property(e => e.PCountry)
                .HasMaxLength(25)
                .HasColumnName("P_Country");
            entity.Property(e => e.PPinCode)
                .HasMaxLength(5)
                .HasColumnName("P_PinCode");
            entity.Property(e => e.PState)
                .HasMaxLength(25)
                .HasColumnName("P_State");
            entity.Property(e => e.PhoneNumber).HasMaxLength(10);
            entity.Property(e => e.PrimaryEmailId).HasMaxLength(50);
            entity.Property(e => e.SecondaryEmailId).HasMaxLength(50);
        });

        modelBuilder.Entity<StudentEmeregencyContact>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("StudentEmeregencyContact");

            entity.Property(e => e.AddressLine).HasMaxLength(200);
            entity.Property(e => e.City).HasMaxLength(25);
            entity.Property(e => e.Country).HasMaxLength(25);
            entity.Property(e => e.EmailId).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasMaxLength(10);
            entity.Property(e => e.PinCode).HasMaxLength(5);
            entity.Property(e => e.RelationShip).HasMaxLength(15);
            entity.Property(e => e.State).HasMaxLength(25);
        });

        modelBuilder.Entity<StudentNotification>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("StudentNotification");

            entity.Property(e => e.Smsalert).HasColumnName("SMSAlert");
        });

        modelBuilder.Entity<StudentParentDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("StudentParentDetail");

            entity.Property(e => e.AddressLine).HasMaxLength(200);
            entity.Property(e => e.City).HasMaxLength(25);
            entity.Property(e => e.Country).HasMaxLength(25);
            entity.Property(e => e.Email).HasMaxLength(25);
            entity.Property(e => e.FatherName).HasMaxLength(50);
            entity.Property(e => e.GuardianName).HasMaxLength(50);
            entity.Property(e => e.MotherName).HasMaxLength(50);
            entity.Property(e => e.ParentId).HasColumnName("ParentID");
            entity.Property(e => e.PhoneNumber).HasMaxLength(10);
            entity.Property(e => e.PinCode).HasMaxLength(5);
            entity.Property(e => e.State).HasMaxLength(25);
        });

        modelBuilder.Entity<StudentProfile>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("StudentProfile");

            entity.Property(e => e.AadharNumber).HasMaxLength(16);
            entity.Property(e => e.BloodGroup).HasMaxLength(10);
            entity.Property(e => e.EnrollmentNumber).HasMaxLength(15);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.GitHubId).HasMaxLength(25);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.LinkedInId).HasMaxLength(25);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.Nationality).HasMaxLength(15);
            entity.Property(e => e.Religion).HasMaxLength(15);
            entity.Property(e => e.Title).HasMaxLength(15);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
