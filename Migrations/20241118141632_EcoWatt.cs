using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoWatt.Migrations
{
    /// <inheritdoc />
    public partial class EcoWatt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consumos",
                columns: table => new
                {
                    ConsumoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Data_Consumo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Hora_Consumo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Quantidade_Watts = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumos", x => x.ConsumoId);
                });

            migrationBuilder.CreateTable(
                name: "Eletrodomesticos",
                columns: table => new
                {
                    EletrodomesticosId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome_Aparelho = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Valor_Consumo_Watts = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Categoria = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Modelo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eletrodomesticos", x => x.EletrodomesticosId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Senha = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CEP = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consumos");

            migrationBuilder.DropTable(
                name: "Eletrodomesticos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
