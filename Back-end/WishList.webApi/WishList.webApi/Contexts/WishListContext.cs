using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WishList.webApi.Domains;

#nullable disable

namespace WishList.webApi.Contexts
{
    public partial class WishListContext : DbContext
    {
        public WishListContext()
        {
        }

        public WishListContext(DbContextOptions<WishListContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Desejo> Desejos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-4MFDOSC\\SQLEXPRESS; initial catalog=WishList; user Id=sa; pwd=1297;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Desejo>(entity =>
            {
                entity.HasKey(e => e.IdDesejo)
                    .HasName("PK__Desejos__5DB1341FE928C997");

                entity.Property(e => e.IdDesejo).HasColumnName("idDesejo");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__645723A63ABDCE76");

                entity.HasIndex(e => e.Email, "UQ__Usuarios__AB6E61647E744E7C")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdDesejo).HasColumnName("idDesejo");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdDesejoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdDesejo)
                    .HasConstraintName("FK__Usuarios__idDese__2B3F6F97");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
