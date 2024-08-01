using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QL_QuanBi_a_API.Models;

public partial class QlBidaContext : DbContext
{
    public QlBidaContext()
    {
    }

    public QlBidaContext(DbContextOptions<QlBidaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ban> Bans { get; set; }

    public virtual DbSet<Bienlai> Bienlais { get; set; }

    public virtual DbSet<Chitietdv> Chitietdvs { get; set; }

    public virtual DbSet<Datban> Datbans { get; set; }

    public virtual DbSet<Dichvu> Dichvus { get; set; }

    public virtual DbSet<Khachhang> Khachhangs { get; set; }

    public virtual DbSet<Nhanvien> Nhanviens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-H2CP5290\\SQLEXPRESS22;Initial Catalog=QL_Bida;Persist Security Info=True;User ID=sa;Password=123;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ban>(entity =>
        {
            entity.HasKey(e => e.Maban).HasName("PK__BAN__4033B61AB060875D");

            entity.ToTable("BAN");

            entity.Property(e => e.Maban).HasColumnName("MABAN");
            entity.Property(e => e.Giathue)
                .HasDefaultValue(100000.0)
                .HasColumnName("GIATHUE");
            entity.Property(e => e.Khuvuc).HasColumnName("KHUVUC");
            entity.Property(e => e.Loaiban).HasColumnName("LOAIBAN");
            entity.Property(e => e.Tenban)
                .HasMaxLength(30)
                .HasColumnName("TENBAN");
            entity.Property(e => e.Tinhtrang).HasColumnName("TINHTRANG");
        });

        modelBuilder.Entity<Bienlai>(entity =>
        {
            entity.HasKey(e => e.Mabienlai).HasName("PK__BIENLAI__2239FFA551939E7D");

            entity.ToTable("BIENLAI", tb =>
                {
                    tb.HasTrigger("TRIGGER_TINHTRANGBAN1");
                    tb.HasTrigger("TRIGGER_TINHTRANGBAN2");
                });

            entity.Property(e => e.Mabienlai).HasColumnName("MABIENLAI");
            entity.Property(e => e.Giobd)
                .HasColumnType("datetime")
                .HasColumnName("GIOBD");
            entity.Property(e => e.Giokt)
                .HasColumnType("datetime")
                .HasColumnName("GIOKT");
            entity.Property(e => e.Maban).HasColumnName("MABAN");
            entity.Property(e => e.Makh).HasColumnName("MAKH");
            entity.Property(e => e.Manhanvien)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MANHANVIEN");
            entity.Property(e => e.Ngaylap)
                .HasColumnType("datetime")
                .HasColumnName("NGAYLAP");
            entity.Property(e => e.Tongtien).HasColumnName("TONGTIEN");

            entity.HasOne(d => d.MabanNavigation).WithMany(p => p.Bienlais)
                .HasForeignKey(d => d.Maban)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BIENLAI_BAN");

            entity.HasOne(d => d.MakhNavigation).WithMany(p => p.Bienlais)
                .HasForeignKey(d => d.Makh)
                .HasConstraintName("FK_BIENLAI_KHACHHANG");

            entity.HasOne(d => d.ManhanvienNavigation).WithMany(p => p.Bienlais)
                .HasForeignKey(d => d.Manhanvien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_BIENLAI_NHANVIEN");
        });

        modelBuilder.Entity<Chitietdv>(entity =>
        {
            entity.HasKey(e => new { e.Mabienlai, e.Madv });

            entity.ToTable("CHITIETDV");

            entity.Property(e => e.Mabienlai).HasColumnName("MABIENLAI");
            entity.Property(e => e.Madv).HasColumnName("MADV");
            entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

            entity.HasOne(d => d.MabienlaiNavigation).WithMany(p => p.Chitietdvs)
                .HasForeignKey(d => d.Mabienlai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CHITIETDV_BIENLAI");

            entity.HasOne(d => d.MadvNavigation).WithMany(p => p.Chitietdvs)
                .HasForeignKey(d => d.Madv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CHITIETDV_DV");
        });

        modelBuilder.Entity<Datban>(entity =>
        {
            entity.HasKey(e => e.Madatban).HasName("PK__DATBAN__D97F9C7DB2327143");

            entity.ToTable("DATBAN");

            entity.Property(e => e.Madatban).HasColumnName("MADATBAN");
            entity.Property(e => e.Ghichu)
                .HasMaxLength(500)
                .HasColumnName("GHICHU");
            entity.Property(e => e.Maban).HasColumnName("MABAN");
            entity.Property(e => e.Sdt)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SDT");
            entity.Property(e => e.Tenkh)
                .HasMaxLength(50)
                .HasColumnName("TENKH");
            entity.Property(e => e.Thoigianden)
                .HasColumnType("datetime")
                .HasColumnName("THOIGIANDEN");
            entity.Property(e => e.Trangthai)
                .HasDefaultValue(false)
                .HasColumnName("TRANGTHAI");

            entity.HasOne(d => d.MabanNavigation).WithMany(p => p.Datbans)
                .HasForeignKey(d => d.Maban)
                .HasConstraintName("FK_DATBAN_BAN");
        });

        modelBuilder.Entity<Dichvu>(entity =>
        {
            entity.HasKey(e => e.Madv).HasName("PK__DICHVU__603F005514768222");

            entity.ToTable("DICHVU");

            entity.Property(e => e.Madv).HasColumnName("MADV");
            entity.Property(e => e.Dongia).HasColumnName("DONGIA");
            entity.Property(e => e.Donvitinh)
                .HasMaxLength(20)
                .HasColumnName("DONVITINH");
            entity.Property(e => e.Tendv)
                .HasMaxLength(50)
                .HasColumnName("TENDV");
        });

        modelBuilder.Entity<Khachhang>(entity =>
        {
            entity.HasKey(e => e.Makh).HasName("PK__KHACHHAN__603F592C333F3D54");

            entity.ToTable("KHACHHANG");

            entity.Property(e => e.Makh).HasColumnName("MAKH");
            entity.Property(e => e.Sdt)
                .HasMaxLength(50)
                .HasColumnName("SDT");
            entity.Property(e => e.Tenkh)
                .HasMaxLength(100)
                .HasColumnName("TENKH");
        });

        modelBuilder.Entity<Nhanvien>(entity =>
        {
            entity.HasKey(e => e.Manhanvien).HasName("PK__NHANVIEN__7E46DD91830CF9A8");

            entity.ToTable("NHANVIEN");

            entity.Property(e => e.Manhanvien)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MANHANVIEN");
            entity.Property(e => e.Calam).HasColumnName("CALAM");
            entity.Property(e => e.Passnv)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PASSNV");
            entity.Property(e => e.Quyen)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValue("USER")
                .IsFixedLength()
                .HasColumnName("QUYEN");
            entity.Property(e => e.Tennv)
                .HasMaxLength(50)
                .HasColumnName("TENNV");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
