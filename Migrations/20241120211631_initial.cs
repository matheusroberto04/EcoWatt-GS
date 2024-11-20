using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoWatt.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_Consumo",
                columns: table => new
                {
                    ConsumoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    dt_consumo = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    qt_horas_uso = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    vl_consumo_watts = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Consumo", x => x.ConsumoId);
                });

            migrationBuilder.CreateTable(
                name: "_Eletrodomesticos",
                columns: table => new
                {
                    EletrodomesticosId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    vl_aparelho_consumo_watts = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ds_categoria = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ds_modelo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Eletrodomesticos", x => x.EletrodomesticosId);
                });

            migrationBuilder.CreateTable(
                name: "_Usuario",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nm_nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ds_email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    cd_senha = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    cd_cep = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario", x => x.UsuarioId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_Consumo");

            migrationBuilder.DropTable(
                name: "_Eletrodomesticos");

            migrationBuilder.DropTable(
                name: "_Usuario");
        }
    }
}
