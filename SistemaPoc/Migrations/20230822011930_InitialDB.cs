using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaPoc.Migrations
{
    public partial class InitialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advogado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    OAB = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advogado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reclamada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reclamada", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reclamante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reclamante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Processo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdvogadoId = table.Column<int>(type: "int", nullable: false),
                    ReclamanteId = table.Column<int>(type: "int", nullable: false),
                    ReclamadaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Processo_Advogado_AdvogadoId",
                        column: x => x.AdvogadoId,
                        principalTable: "Advogado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Processo_Reclamada_ReclamadaId",
                        column: x => x.ReclamadaId,
                        principalTable: "Reclamada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Processo_Reclamante_ReclamanteId",
                        column: x => x.ReclamanteId,
                        principalTable: "Reclamante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Processo_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Processo_AdvogadoId",
                table: "Processo",
                column: "AdvogadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Processo_ReclamadaId",
                table: "Processo",
                column: "ReclamadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Processo_ReclamanteId",
                table: "Processo",
                column: "ReclamanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Processo_UsuarioId",
                table: "Processo",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Processo");

            migrationBuilder.DropTable(
                name: "Advogado");

            migrationBuilder.DropTable(
                name: "Reclamada");

            migrationBuilder.DropTable(
                name: "Reclamante");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
