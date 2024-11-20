using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcoWatt.Migrations
{
    /// <inheritdoc />
    public partial class GSEcoWatt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Senha",
                table: "Usuarios",
                newName: "cd_senha");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Usuarios",
                newName: "nm_nome");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Usuarios",
                newName: "ds_email");

            migrationBuilder.RenameColumn(
                name: "CEP",
                table: "Usuarios",
                newName: "cd_cep");

            migrationBuilder.RenameColumn(
                name: "Valor_Consumo_Watts",
                table: "Eletrodomesticos",
                newName: "vl_aparelho_consumo_watts");

            migrationBuilder.RenameColumn(
                name: "Nome_Aparelho",
                table: "Eletrodomesticos",
                newName: "nm_nome");

            migrationBuilder.RenameColumn(
                name: "Modelo",
                table: "Eletrodomesticos",
                newName: "ds_modelo");

            migrationBuilder.RenameColumn(
                name: "Categoria",
                table: "Eletrodomesticos",
                newName: "ds_categoria");

            migrationBuilder.RenameColumn(
                name: "Quantidade_Watts",
                table: "Consumos",
                newName: "vl_consumo_watts");

            migrationBuilder.RenameColumn(
                name: "Hora_Consumo",
                table: "Consumos",
                newName: "qt_horas_uso");

            migrationBuilder.RenameColumn(
                name: "Data_Consumo",
                table: "Consumos",
                newName: "dt_consumo");

            migrationBuilder.AlterColumn<string>(
                name: "qt_horas_uso",
                table: "Consumos",
                type: "NVARCHAR2(2000)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nm_nome",
                table: "Usuarios",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "ds_email",
                table: "Usuarios",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "cd_senha",
                table: "Usuarios",
                newName: "Senha");

            migrationBuilder.RenameColumn(
                name: "cd_cep",
                table: "Usuarios",
                newName: "CEP");

            migrationBuilder.RenameColumn(
                name: "vl_aparelho_consumo_watts",
                table: "Eletrodomesticos",
                newName: "Valor_Consumo_Watts");

            migrationBuilder.RenameColumn(
                name: "nm_nome",
                table: "Eletrodomesticos",
                newName: "Nome_Aparelho");

            migrationBuilder.RenameColumn(
                name: "ds_modelo",
                table: "Eletrodomesticos",
                newName: "Modelo");

            migrationBuilder.RenameColumn(
                name: "ds_categoria",
                table: "Eletrodomesticos",
                newName: "Categoria");

            migrationBuilder.RenameColumn(
                name: "vl_consumo_watts",
                table: "Consumos",
                newName: "Quantidade_Watts");

            migrationBuilder.RenameColumn(
                name: "qt_horas_uso",
                table: "Consumos",
                newName: "Hora_Consumo");

            migrationBuilder.RenameColumn(
                name: "dt_consumo",
                table: "Consumos",
                newName: "Data_Consumo");

            migrationBuilder.AlterColumn<int>(
                name: "Hora_Consumo",
                table: "Consumos",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");
        }
    }
}
