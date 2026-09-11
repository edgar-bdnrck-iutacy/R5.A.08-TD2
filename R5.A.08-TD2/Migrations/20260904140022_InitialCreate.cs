using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace R5.A._08_TD2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marques",
                columns: table => new
                {
                    IdMarque = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomMarque = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marques", x => x.IdMarque);
                });

            migrationBuilder.CreateTable(
                name: "TypesProduit",
                columns: table => new
                {
                    IdTypeProduit = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomTypeProduit = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesProduit", x => x.IdTypeProduit);
                });

            migrationBuilder.CreateTable(
                name: "Produits",
                columns: table => new
                {
                    IdProduit = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomProduit = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    NomPhoto = table.Column<string>(type: "text", nullable: true),
                    UriPhoto = table.Column<string>(type: "text", nullable: true),
                    IdTypeProduit = table.Column<int>(type: "integer", nullable: false),
                    IdMarque = table.Column<int>(type: "integer", nullable: false),
                    StockReel = table.Column<int>(type: "integer", nullable: false),
                    StockMin = table.Column<int>(type: "integer", nullable: false),
                    StockMax = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produits", x => x.IdProduit);
                    table.ForeignKey(
                        name: "FK_Produits_Marques_IdMarque",
                        column: x => x.IdMarque,
                        principalTable: "Marques",
                        principalColumn: "IdMarque",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produits_TypesProduit_IdTypeProduit",
                        column: x => x.IdTypeProduit,
                        principalTable: "TypesProduit",
                        principalColumn: "IdTypeProduit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produits_IdMarque",
                table: "Produits",
                column: "IdMarque");

            migrationBuilder.CreateIndex(
                name: "IX_Produits_IdTypeProduit",
                table: "Produits",
                column: "IdTypeProduit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produits");

            migrationBuilder.DropTable(
                name: "Marques");

            migrationBuilder.DropTable(
                name: "TypesProduit");
        }
    }
}
