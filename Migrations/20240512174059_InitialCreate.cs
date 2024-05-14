using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tabClientes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", nullable: true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Cpf = table.Column<string>(type: "TEXT", nullable: true),
                    Vip = table.Column<bool>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabClientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tabEventos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", nullable: true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Organizacao = table.Column<string>(type: "TEXT", nullable: false),
                    Local = table.Column<string>(type: "TEXT", nullable: false),
                    EstiloMusical = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabEventos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tabFuncionarios",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", nullable: true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Cpf = table.Column<string>(type: "TEXT", nullable: true),
                    Funcao = table.Column<string>(type: "TEXT", nullable: true),
                    EventosId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tabFuncionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tabFuncionarios_tabEventos_EventosId",
                        column: x => x.EventosId,
                        principalTable: "tabEventos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tabFuncionarios_EventosId",
                table: "tabFuncionarios",
                column: "EventosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tabClientes");

            migrationBuilder.DropTable(
                name: "tabFuncionarios");

            migrationBuilder.DropTable(
                name: "tabEventos");
        }
    }
}
