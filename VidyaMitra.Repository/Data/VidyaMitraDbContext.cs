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
    { 
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Server=BHAVYA;Database=VidyaMitraDB;Trusted_Connection=True;TrustServerCertificate=True;Persist Security Info=True;User ID=sa;Password=HumTum;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentContactDetail>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK_ContactDetail");

            entity.ToTable("StudentContactDetail");

            entity.Property(e => e.AlternatePhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.CAddressLine)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("C_AddressLine");
            entity.Property(e => e.CCity)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("C_City");
            entity.Property(e => e.CCountry)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("C_Country");
            entity.Property(e => e.CPinCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("C_PinCode");
            entity.Property(e => e.CState)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("C_State");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PAddressLine)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("P_AddressLine");
            entity.Property(e => e.PCity)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("P_City");
            entity.Property(e => e.PCountry)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("P_Country");
            entity.Property(e => e.PPinCode)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("P_PinCode");
            entity.Property(e => e.PState)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("P_State");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PrimaryEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SecondaryEmail)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Profile).WithMany(p => p.StudentContactDetails)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("fk_StuContactDetail");
        });

        modelBuilder.Entity<StudentEmeregencyContact>(entity =>
        {
            entity.HasKey(e => e.EcontactId).HasName("PK_EmeregencyContact");

            entity.ToTable("StudentEmeregencyContact");

            entity.Property(e => e.EcontactId).HasColumnName("EContactId");
            entity.Property(e => e.AddressLine)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PinCode)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.RelationShip)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.HasOne(d => d.Profile).WithMany(p => p.StudentEmeregencyContacts)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("fk_StuEmeregencyContact");
        });

        modelBuilder.Entity<StudentNotification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK_NotificationSetting");

            entity.ToTable("StudentNotification");

            entity.Property(e => e.Smsalert).HasColumnName("SMSAlert");

            entity.HasOne(d => d.Profile).WithMany(p => p.StudentNotifications)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("fk_StuNotification");
        });

        modelBuilder.Entity<StudentParentDetail>(entity =>
        {
            entity.HasKey(e => e.ParentId).HasName("PK_ParentDetail");

            entity.ToTable("StudentParentDetail");

            entity.Property(e => e.ParentId).HasColumnName("ParentID");
            entity.Property(e => e.AddressLine)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FatherName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.GuardianName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MotherName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PinCode)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.HasOne(d => d.Profile).WithMany(p => p.StudentParentDetails)
                .HasForeignKey(d => d.ProfileId)
                .HasConstraintName("fk_StuParentDetail");
        });

        modelBuilder.Entity<StudentProfile>(entity =>
        {
            entity.HasKey(e => e.ProfileId).HasName("PK_StudentData");

            entity.ToTable("StudentProfile");

            entity.Property(e => e.AadharNumber)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.BloodGroup)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.DigitalSignature).HasColumnType("image");
            entity.Property(e => e.EnrollmentNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.GitHubId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LinkedInId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LoginEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Nationality)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.ProfilePicture).HasColumnType("image");
            entity.Property(e => e.Religion)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasMaxLength(450);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
