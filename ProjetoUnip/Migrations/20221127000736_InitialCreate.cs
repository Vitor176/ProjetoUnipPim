using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoUnip.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logradouro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_TipoTelefone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_TipoTelefone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Telefone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDeTelefone = table.Column<int>(type: "int", nullable: false),
                    DDD = table.Column<int>(type: "int", nullable: false),
                    Id_FKTipoTelefone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Telefone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TelefoneTipoTelefone",
                        column: x => x.Id_FKTipoTelefone,
                        principalTable: "Tb_TipoTelefone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPF = table.Column<long>(type: "bigint", nullable: false),
                    Id_Endereco = table.Column<int>(type: "int", nullable: false),
                    Id_Telefone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Pessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PessoasEndereco",
                        column: x => x.Id_Endereco,
                        principalTable: "Tb_Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PessoasTelefone",
                        column: x => x.Id_Telefone,
                        principalTable: "Tb_Telefone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Pessoa_Id_Endereco",
                table: "tb_Pessoa",
                column: "Id_Endereco");

            migrationBuilder.CreateIndex(
                name: "IX_tb_Pessoa_Id_Telefone",
                table: "tb_Pessoa",
                column: "Id_Telefone");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Telefone_Id_FKTipoTelefone",
                table: "Tb_Telefone",
                column: "Id_FKTipoTelefone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_Pessoa");

            migrationBuilder.DropTable(
                name: "Tb_Endereco");

            migrationBuilder.DropTable(
                name: "Tb_Telefone");

            migrationBuilder.DropTable(
                name: "Tb_TipoTelefone");
        }
    }
}
