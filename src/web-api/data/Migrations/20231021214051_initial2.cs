using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace data.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cep = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: true),
                    Complemento = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    Bairro = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    NomeMunicipio = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    SiglaUf = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(250)", unicode: false, nullable: false),
                    Instagram = table.Column<string>(type: "varchar(250)", unicode: false, nullable: false),
                    TipoCadastro = table.Column<int>(type: "int", nullable: false),
                    TipoSituacao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoSituacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NomeTipoSituacao = table.Column<string>(type: "varchar(250)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoSituacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    NomeFantasia = table.Column<string>(type: "varchar(250)", unicode: false, nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(500)", unicode: false, nullable: false),
                    Cnpj = table.Column<string>(type: "varchar(14)", unicode: false, nullable: false),
                    Email = table.Column<string>(type: "varchar(250)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresa_Organizacao_Id",
                        column: x => x.Id,
                        principalTable: "Organizacao",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(200)", unicode: false, nullable: false),
                    Apelido = table.Column<string>(type: "varchar(50)", unicode: false, nullable: false),
                    CPF = table.Column<string>(type: "varchar(14)", unicode: false, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(15)", unicode: false, nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", unicode: false, nullable: false),
                    Imagem = table.Column<string>(type: "varchar(1000)", unicode: false, nullable: false),
                    TipoCadastro = table.Column<int>(type: "int", nullable: false),
                    IdOrganizacao = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Organizacao_IdOrganizacao",
                        column: x => x.IdOrganizacao,
                        principalTable: "Organizacao",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "TipoSituacao",
                columns: new[] { "Id", "NomeTipoSituacao" },
                values: new object[,]
                {
                    { 0, "EmElaboracao" },
                    { 1, "Ativado" },
                    { 2, "Desativado" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_Cnpj",
                table: "Empresa",
                column: "Cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdOrganizacao",
                table: "Usuario",
                column: "IdOrganizacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "TipoSituacao");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Organizacao");
        }
    }
}
