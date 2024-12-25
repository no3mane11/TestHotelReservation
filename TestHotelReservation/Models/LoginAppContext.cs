using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestHotelReservation.Models;

public partial class LoginAppContext : DbContext
{
    public LoginAppContext()
    {
    }

    public LoginAppContext(DbContextOptions<LoginAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chambre> Chambres { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Employe> Employes { get; set; }

    public virtual DbSet<HistoriqueExport> HistoriqueExports { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Paiement> Paiements { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<TabDeleted> TabDeleteds { get; set; }

    public virtual DbSet<TypeChambre> TypeChambres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=desktop-tgrj1nj\\sqlexpress;Database=loginApp;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chambre>(entity =>
        {
            entity.HasKey(e => e.ChambreId).HasName("PK__Chambre__59A3B1261F3055F7");

            entity.ToTable("Chambre");

            entity.HasIndex(e => e.NumeroChambre, "UQ__Chambre__381617CB89A39476").IsUnique();

            entity.Property(e => e.ChambreId).HasColumnName("ChambreID");
            entity.Property(e => e.EstDisponible)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.NumeroChambre).HasMaxLength(10);
            entity.Property(e => e.TypeChambreId).HasColumnName("TypeChambreID");

            entity.HasOne(d => d.TypeChambre).WithMany(p => p.Chambres)
                .HasForeignKey(d => d.TypeChambreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Chambre__TypeCha__4316F928");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__Client__E67E1A043FC7F16A");

            entity.ToTable("Client");

            entity.HasIndex(e => e.Email, "UQ__Client__A9D105346FF020BB").IsUnique();

            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.Adresse).HasMaxLength(255);
            entity.Property(e => e.DateInscription)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.MotDePasse).HasMaxLength(255);
            entity.Property(e => e.Nom).HasMaxLength(100);
            entity.Property(e => e.Prenom).HasMaxLength(100);
            entity.Property(e => e.Telephone).HasMaxLength(15);
        });

        modelBuilder.Entity<Employe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__loginTab__3214EC27DF82FC53");

            entity.ToTable("Employe");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Actif)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.DateEmbauche).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Prenom).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.Telephone).HasMaxLength(15);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<HistoriqueExport>(entity =>
        {
            entity.HasKey(e => e.ExportId).HasName("PK__Historiq__E5C997A4ECCECB51");

            entity.ToTable("HistoriqueExport");

            entity.Property(e => e.ExportId).HasColumnName("ExportID");
            entity.Property(e => e.CheminFichier).HasMaxLength(255);
            entity.Property(e => e.DateExport)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TypeFichier).HasMaxLength(50);

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.HistoriqueExports)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HistoriqueEx__ID__571DF1D5");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E32537E9CC6");

            entity.ToTable("Notification");

            entity.Property(e => e.NotificationId).HasColumnName("NotificationID");
            entity.Property(e => e.DateEnvoi)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Message).HasMaxLength(500);
            entity.Property(e => e.TypeUtilisateur).HasMaxLength(50);
            entity.Property(e => e.UtilisateurId).HasColumnName("UtilisateurID");
        });

        modelBuilder.Entity<Paiement>(entity =>
        {
            entity.HasKey(e => e.PaiementId).HasName("PK__Paiement__A8FB0857442DE033");

            entity.ToTable("Paiement");

            entity.Property(e => e.PaiementId).HasColumnName("PaiementID");
            entity.Property(e => e.DatePaiement)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ModePaiement).HasMaxLength(50);
            entity.Property(e => e.Montant).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ReservationId).HasColumnName("ReservationID");

            entity.HasOne(d => d.Reservation).WithMany(p => p.Paiements)
                .HasForeignKey(d => d.ReservationId)
                .HasConstraintName("FK_Paiement_Reservation");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__Reservat__B7EE5F04B76ED26F");

            entity.ToTable("Reservation");

            entity.Property(e => e.ReservationId).HasColumnName("ReservationID");
            entity.Property(e => e.ChambreId).HasColumnName("ChambreID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.DateCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDebut).HasColumnType("date");
            entity.Property(e => e.DateFin).HasColumnType("date");
            entity.Property(e => e.EtatReservation)
                .HasMaxLength(50)
                .HasDefaultValueSql("('En attente')");
            entity.Property(e => e.TarifParNuit).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Chambre).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.ChambreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__Chamb__5DCAEF64");

            entity.HasOne(d => d.Client).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__Clien__5CD6CB2B");
        });

        modelBuilder.Entity<TabDeleted>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__Reservat__B7EE5F048508868F");

            entity.ToTable("tabDeleted");

            entity.Property(e => e.ReservationId).HasColumnName("ReservationID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.DateCreation)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DateDebut).HasColumnType("date");
            entity.Property(e => e.DateFin).HasColumnType("date");
            entity.Property(e => e.EtatReservation)
                .HasMaxLength(50)
                .HasDefaultValueSql("('En attente')");
        });

        modelBuilder.Entity<TypeChambre>(entity =>
        {
            entity.HasKey(e => e.TypeChambreId).HasName("PK__TypeCham__DD784473F83ECA8F");

            entity.ToTable("TypeChambre");

            entity.Property(e => e.TypeChambreId).HasColumnName("TypeChambreID");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Nom).HasMaxLength(100);
            entity.Property(e => e.TarifParNuit).HasColumnType("decimal(10, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
