using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KanBanDev.Models
{
    public partial class KanBanContext : DbContext
    {
        public KanBanContext()
        {
        }

        public KanBanContext(DbContextOptions<KanBanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<HistoricoTarefa> HistoricoTarefa { get; set; }
        public virtual DbSet<Permissao> Permissao { get; set; }
        public virtual DbSet<PermissaoUsuario> PermissaoUsuario { get; set; }
        public virtual DbSet<Quadro> Quadro { get; set; }
        public virtual DbSet<SituacaoTarefa> SituacaoTarefa { get; set; }
        public virtual DbSet<Tarefa> Tarefa { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=18.231.101.44;Initial Catalog=KanBanDev; user id=GioDevAdmin; password=GioDevDb2020;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HistoricoTarefa>(entity =>
            {
                entity.Property(e => e.HistoricoTarefaId).HasColumnName("HistoricoTarefaID");

                entity.Property(e => e.HistoricoDtCriacao).HasColumnType("datetime");

                entity.Property(e => e.SituacaoTarefaId).HasColumnName("SituacaoTarefaID");

                entity.Property(e => e.TarefaDescricao)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TarefaId).HasColumnName("TarefaID");

                entity.Property(e => e.TarefaTitulo)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.SituacaoTarefa)
                    .WithMany(p => p.HistoricoTarefa)
                    .HasForeignKey(d => d.SituacaoTarefaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SituacaoTarefa_HistoricoTarefa");

                entity.HasOne(d => d.Tarefa)
                    .WithMany(p => p.HistoricoTarefa)
                    .HasForeignKey(d => d.TarefaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Tarefa_HistoricoTarefa");
            });

            modelBuilder.Entity<Permissao>(entity =>
            {
                entity.Property(e => e.PermissaoId).HasColumnName("PermissaoID");

                entity.Property(e => e.PermissaoDescricao)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PermissaoUsuario>(entity =>
            {
                entity.Property(e => e.PermissaoUsuarioId).HasColumnName("PermissaoUsuarioID");

                entity.Property(e => e.PermissaoId).HasColumnName("PermissaoID");

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.Permissao)
                    .WithMany(p => p.PermissaoUsuario)
                    .HasForeignKey(d => d.PermissaoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Permissao_PermissaoUsuario");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.PermissaoUsuario)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuario_PermissaoUsuario");
            });

            modelBuilder.Entity<Quadro>(entity =>
            {
                entity.Property(e => e.QuadroId).HasColumnName("QuadroID");

                entity.Property(e => e.QuadroDescricao)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.QuadroDtCriacao).HasColumnType("datetime");

                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.Quadro)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Usuario_Quadro");
            });

            modelBuilder.Entity<SituacaoTarefa>(entity =>
            {
                entity.Property(e => e.SituacaoTarefaId).HasColumnName("SituacaoTarefaID");

                entity.Property(e => e.SituacaoTarefaDescricao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tarefa>(entity =>
            {
                entity.Property(e => e.TarefaId).HasColumnName("TarefaID");

                entity.Property(e => e.QuadroId).HasColumnName("QuadroID");

                entity.Property(e => e.SituacaoTarefaId).HasColumnName("SituacaoTarefaID");

                entity.Property(e => e.TarefaDescricao)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.TarefaDtCriacao).HasColumnType("datetime");

                entity.Property(e => e.TarefaTitulo)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Quadro)
                    .WithMany(p => p.Tarefa)
                    .HasForeignKey(d => d.QuadroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Quadro_Tarefa");

                entity.HasOne(d => d.SituacaoTarefa)
                    .WithMany(p => p.Tarefa)
                    .HasForeignKey(d => d.SituacaoTarefaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("SituacaoTarefa_Tarefa");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

                entity.Property(e => e.UsuarioDtCadastro).HasColumnType("datetime");

                entity.Property(e => e.UsuarioDtUltimoAcesso).HasColumnType("datetime");

                entity.Property(e => e.UsuarioEmail)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioNome)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UsuarioSenha)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
