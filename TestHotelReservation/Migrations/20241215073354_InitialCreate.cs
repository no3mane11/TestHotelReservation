using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestHotelReservation.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    MotDePasse = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DateInscription = table.Column<DateTime>(type: "date", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Client__E67E1A043FC7F16A", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "Employe",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DateEmbauche = table.Column<DateTime>(type: "date", nullable: true),
                    Actif = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))"),
                    Prenom = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__loginTab__3214EC27DF82FC53", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    NotificationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilisateurID = table.Column<int>(type: "int", nullable: true),
                    TypeUtilisateur = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DateEnvoi = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    EstLu = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Notifica__20CF2E32537E9CC6", x => x.NotificationID);
                });

            migrationBuilder.CreateTable(
                name: "tabDeleted",
                columns: table => new
                {
                    ReservationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "date", nullable: false),
                    DateFin = table.Column<DateTime>(type: "date", nullable: false),
                    EtatReservation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('En attente')"),
                    DateCreation = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reservat__B7EE5F048508868F", x => x.ReservationID);
                });

            migrationBuilder.CreateTable(
                name: "TypeChambre",
                columns: table => new
                {
                    TypeChambreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TarifParNuit = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TypeCham__DD784473F83ECA8F", x => x.TypeChambreID);
                });

            migrationBuilder.CreateTable(
                name: "HistoriqueExport",
                columns: table => new
                {
                    ExportID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID = table.Column<int>(type: "int", nullable: false),
                    TypeFichier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateExport = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    CheminFichier = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Historiq__E5C997A4ECCECB51", x => x.ExportID);
                    table.ForeignKey(
                        name: "FK__HistoriqueEx__ID__571DF1D5",
                        column: x => x.ID,
                        principalTable: "Employe",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Chambre",
                columns: table => new
                {
                    ChambreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroChambre = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TypeChambreID = table.Column<int>(type: "int", nullable: false),
                    EstDisponible = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Chambre__59A3B1261F3055F7", x => x.ChambreID);
                    table.ForeignKey(
                        name: "FK__Chambre__TypeCha__4316F928",
                        column: x => x.TypeChambreID,
                        principalTable: "TypeChambre",
                        principalColumn: "TypeChambreID");
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ReservationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    ChambreID = table.Column<int>(type: "int", nullable: false),
                    DateDebut = table.Column<DateTime>(type: "date", nullable: false),
                    DateFin = table.Column<DateTime>(type: "date", nullable: false),
                    TarifParNuit = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    EtatReservation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValueSql: "('En attente')"),
                    DateCreation = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reservat__B7EE5F04B76ED26F", x => x.ReservationID);
                    table.ForeignKey(
                        name: "FK__Reservati__Chamb__5DCAEF64",
                        column: x => x.ChambreID,
                        principalTable: "Chambre",
                        principalColumn: "ChambreID");
                    table.ForeignKey(
                        name: "FK__Reservati__Clien__5CD6CB2B",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID");
                });

            migrationBuilder.CreateTable(
                name: "Paiement",
                columns: table => new
                {
                    PaiementID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Montant = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DatePaiement = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ModePaiement = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ReservationID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Paiement__A8FB0857442DE033", x => x.PaiementID);
                    table.ForeignKey(
                        name: "FK_Paiement_Reservation",
                        column: x => x.ReservationID,
                        principalTable: "Reservation",
                        principalColumn: "ReservationID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chambre_TypeChambreID",
                table: "Chambre",
                column: "TypeChambreID");

            migrationBuilder.CreateIndex(
                name: "UQ__Chambre__381617CB89A39476",
                table: "Chambre",
                column: "NumeroChambre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Client__A9D105346FF020BB",
                table: "Client",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistoriqueExport_ID",
                table: "HistoriqueExport",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Paiement_ReservationID",
                table: "Paiement",
                column: "ReservationID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ChambreID",
                table: "Reservation",
                column: "ChambreID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ClientID",
                table: "Reservation",
                column: "ClientID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistoriqueExport");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Paiement");

            migrationBuilder.DropTable(
                name: "tabDeleted");

            migrationBuilder.DropTable(
                name: "Employe");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "Chambre");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "TypeChambre");
        }
    }
}
